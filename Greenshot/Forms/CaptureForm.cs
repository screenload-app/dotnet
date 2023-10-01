﻿/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Greenshot.Drawing;
using Greenshot.Helpers;
using Greenshot.IniFile;
using Greenshot.Plugin;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;
using GreenshotPlugin.UnmanagedHelpers;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace Greenshot
{
    /// <summary>
    /// The capture form is used to select a part of the capture
    /// </summary>
    public sealed partial class CaptureForm : AnimatingForm
    {
        private enum FixMode
        {
            None,
            Initiated,
            Horizontal,
            Vertical
        };

        //private enum ColorTransformKind
        //{
        //    None,
        //    Invert,
        //    BlackWhite
        //}

        private static readonly ILog Log = LogManager.GetLogger(typeof(CaptureForm));

        private static readonly CoreConfiguration Conf = IniConfig.GetIniSection<CoreConfiguration>();

        //private static readonly Brush GreenOverlayBrush = new SolidBrush(Color.FromArgb(50, Color.MediumSeaGreen));
        //private static readonly Pen OverlayPen = new Pen(Color.FromArgb(50, Color.Black));
        private static CaptureForm _currentForm;
        private static readonly Brush BackgroundBrush;

        private static readonly HatchStyle BorderHatchStyle = HatchStyle.Percent50;
        private static readonly Color BorderForeColor = Color.White;
        private static readonly Color BorderBackColor = Color.Black;

        private static readonly Color SizeLabelForeColor = Color.White;
        private static readonly Color SizeLabelBackColor = Color.FromArgb(102, Color.Black);
        private const string SizeLabelFontFamily = "Microsoft Sans Serif";
        private const int SizeLabelFontSize = 25;
        private const int SizeLabelMargin = 8;

        private readonly Color? _overlayColor;

        /// <summary>
        /// Initialize the background brush
        /// </summary>
        static CaptureForm()
        {
            var backgroundForTransparency = GreenshotResources.Checkerboard_Image;
            BackgroundBrush = new TextureBrush(backgroundForTransparency, WrapMode.Tile);
        }

        private int _mX;
        private int _mY;
        private Point _mouseMovePos = Point.Empty;
        private Point _cursorPos;
        private CaptureMode _captureMode;
        private readonly List<WindowDetails> _windows;
        private WindowDetails _selectedCaptureWindow;
        private bool _mouseDown;
        private Rectangle _captureRect = Rectangle.Empty;
        private readonly ICapture _capture;
        private Point _previousMousePos = Point.Empty;
        private FixMode _fixMode = FixMode.None;
        private RectangleAnimator _windowAnimator;
        private RectangleAnimator _zoomAnimator;
        private readonly bool _isZoomerTransparent = Conf.ZoomerOpacity < 1;
        private bool _isCtrlPressed;
        private bool _showDebugInfo;

        /// <summary>
        /// Property to access the selected capture rectangle
        /// </summary>
        public Rectangle CaptureRectangle => _captureRect;

        /// <summary>
        /// Property to access the used capture mode
        /// </summary>
        public CaptureMode UsedCaptureMode => _captureMode;

        /// <summary>
        /// Get the selected window
        /// </summary>
        public WindowDetails SelectedCaptureWindow => _selectedCaptureWindow;

        public QuickImageEditorResult QuickImageEditorResult { get; private set; }

        /// <summary>
        /// This should prevent childs to draw backgrounds
        /// </summary>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        private void ClosedHandler(object sender, EventArgs e)
        {
            _currentForm = null;
            Log.Debug("Remove CaptureForm from currentForm");
        }

        private void ClosingHandler(object sender, EventArgs e)
        {
            Log.Debug("Closing captureform");
            WindowDetails.UnregisterIgnoreHandle(Handle);
        }

        /// <summary>
        /// This creates the capture form
        /// </summary>
        /// <param name="capture"></param>
        /// <param name="windows"></param>
        public CaptureForm(ICapture capture, List<WindowDetails> windows)
        {
            if (_currentForm != null)
            {
                Log.Warn("Found currentForm, Closing already opened CaptureForm");
                _currentForm.Close();
                _currentForm = null;
                Application.DoEvents();
            }

            _currentForm = this;

            // Enable the AnimatingForm
            EnableAnimation = true;

            // clean up
            FormClosed += ClosedHandler;

            _capture = capture ?? throw new ArgumentNullException(nameof(capture));
            _windows = windows;
            _captureMode = capture.CaptureDetails.CaptureMode;

            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            if (coreConfiguration.IsCaptureAreaColorUsed)
                _overlayColor = Color.FromArgb(102, coreConfiguration.CaptureAreaColor);

            // Only double-buffer when we are not in a TerminalServerSession
            DoubleBuffered = !IsTerminalServerSession;
            Text = @"Greenshot capture form";

            // Make sure we never capture the captureform
            WindowDetails.RegisterIgnoreHandle(Handle);
            // Unregister at close
            FormClosing += ClosingHandler;

            // set cursor location
            _cursorPos = WindowCapture.GetCursorLocationRelativeToScreenBounds();

            // Initialize the animations, the window capture zooms out from the cursor to the window under the cursor 
            if (_captureMode == CaptureMode.Window)
            {
                _windowAnimator = new RectangleAnimator(new Rectangle(_cursorPos, Size.Empty), _captureRect,
                    FramesForMillis(700), EasingType.Quintic, EasingMode.EaseOut);
            }

            // Set the zoomer animation
            InitializeZoomer(Conf.ZoomerEnabled);

            SuspendLayout();
            Bounds = capture.ScreenBounds;
            ResumeLayout();

            // Fix missing focus
            ToFront = true;
            TopMost = true;
        }

        public void MakeInvisibleWithDelay()
        {
            new Thread(() =>
            {
                Thread.Sleep(250);

                void MakeInvisible()
                {
                    if (IsDisposed)
                        return;

                    Opacity = 0;
                }

                Invoke((Action)MakeInvisible);
            }) {IsBackground = true}.Start();
        }

        /// <summary>
        /// Create an animation for the zoomer, depending on if it's active or not.
        /// </summary>
        private void InitializeZoomer(bool isOn)
        {
            if (isOn)
            {
                // Initialize the zoom with a invalid position
                _zoomAnimator = new RectangleAnimator(Rectangle.Empty, new Rectangle(int.MaxValue, int.MaxValue, 0, 0),
                    FramesForMillis(1000), EasingType.Quintic, EasingMode.EaseOut);
                VerifyZoomAnimation(_cursorPos, false);
            }
            else
            {
                _zoomAnimator?.ChangeDestination(new Rectangle(Point.Empty, Size.Empty), FramesForMillis(1000));
            }
        }

        #region key handling		

        private void CaptureFormKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ShiftKey:
                    _fixMode = FixMode.None;
                    break;
                case Keys.ControlKey:
                    _isCtrlPressed = false;
                    break;
            }
        }

        /// <summary>
        /// Handle the key down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureFormKeyDown(object sender, KeyEventArgs e)
        {
            int step = _isCtrlPressed ? 10 : 1;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - step);
                    break;
                case Keys.Down:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + step);
                    break;
                case Keys.Left:
                    Cursor.Position = new Point(Cursor.Position.X - step, Cursor.Position.Y);
                    break;
                case Keys.Right:
                    Cursor.Position = new Point(Cursor.Position.X + step, Cursor.Position.Y);
                    break;
                case Keys.ShiftKey:
                    // Fixmode
                    if (_fixMode == FixMode.None)
                    {
                        _fixMode = FixMode.Initiated;
                    }

                    break;
                case Keys.ControlKey:
                    _isCtrlPressed = true;
                    break;
                case Keys.Escape:
                    // Cancel
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.M:
                    // Toggle mouse cursor
                    _capture.CursorVisible = !_capture.CursorVisible;
                    Invalidate();
                    break;
                //// TODO: Enable when the screen capture code works reliable
                //case Keys.V:
                //	// Video
                //	if (capture.CaptureDetails.CaptureMode != CaptureMode.Video) {
                //		capture.CaptureDetails.CaptureMode = CaptureMode.Video;
                //	} else {
                //		capture.CaptureDetails.CaptureMode = captureMode;
                //	}
                //	Invalidate();
                //	break;
                case Keys.Z:
                    if (_captureMode == CaptureMode.Region)
                    {
                        // Toggle zoom
                        Conf.ZoomerEnabled = !Conf.ZoomerEnabled;
                        InitializeZoomer(Conf.ZoomerEnabled);
                        Invalidate();
                    }

                    break;
                case Keys.D:
                    if (_captureMode == CaptureMode.Window)
                    {
                        // Toggle debug
                        _showDebugInfo = !_showDebugInfo;
                        Invalidate();
                    }

                    break;
                case Keys.Space:
                    // Toggle capture mode
                    switch (_captureMode)
                    {
                        case CaptureMode.Region:
                            // Set the window capture mode
                            _captureMode = CaptureMode.Window;
                            // "Fade out" Zoom
                            InitializeZoomer(false);
                            // "Fade in" window
                            _windowAnimator = new RectangleAnimator(new Rectangle(_cursorPos, Size.Empty), _captureRect,
                                FramesForMillis(700), EasingType.Quintic, EasingMode.EaseOut);
                            _captureRect = Rectangle.Empty;
                            Invalidate();
                            break;
                        case CaptureMode.Window:
                            // Set the region capture mode
                            _captureMode = CaptureMode.Region;
                            // "Fade out" window
                            _windowAnimator.ChangeDestination(new Rectangle(_cursorPos, Size.Empty),
                                FramesForMillis(700));
                            // Fade in zoom
                            InitializeZoomer(Conf.ZoomerEnabled);
                            _captureRect = Rectangle.Empty;
                            Invalidate();
                            break;
                    }

                    _selectedCaptureWindow = null;
                    OnMouseMove(this,
                        new MouseEventArgs(MouseButtons.None, 0, Cursor.Position.X, Cursor.Position.Y, 0));
                    break;
                case Keys.Return:
                    // Confirm
                    if (_captureMode == CaptureMode.Window)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else if (!_mouseDown)
                    {
                        HandleMouseDown();
                    }
                    else if (_mouseDown)
                    {
                        HandleMouseUp();
                    }

                    break;
                case Keys.F:
                    ToFront = !ToFront;
                    TopMost = !TopMost;
                    break;
            }
        }

        #endregion

        #region events

        /// <summary>
        /// The mousedown handler of the capture form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HandleMouseDown();
            }
        }

        private void HandleMouseDown()
        {
            Point tmpCursorLocation = WindowCapture.GetCursorLocationRelativeToScreenBounds();
            _mX = tmpCursorLocation.X;
            _mY = tmpCursorLocation.Y;
            _mouseDown = true;
            OnMouseMove(this, null);
            Invalidate();
        }

        private void HandleMouseUp()
        {
            // If the mouse goes up we set down to false (nice logic!)
            _mouseDown = false;
            // Check if anything is selected
            if (_captureMode == CaptureMode.Window && _selectedCaptureWindow != null)
            {
                // Go and process the capture
                DialogResult = DialogResult.OK;
            }
            else if (_captureRect.Height > 0 && _captureRect.Width > 0)
            {
                // correct the GUI width to real width if Region mode
                if (_captureMode == CaptureMode.Region)
                {
                    _captureRect.Width += 1;
                    _captureRect.Height += 1;
                }

                if (null != SelectedCaptureWindow)
                    _capture.CaptureDetails.Title = SelectedCaptureWindow.Text;

                if (coreConfiguration.UseQuickEditMode)
                {
                    var quickImageEditorResult =
                        QuickImageEditorForm.ShowQuickImageEditor(_capture, _captureRect, this);

                    if (QuickImageEditorAction.None == quickImageEditorResult.Action)
                        DialogResult = DialogResult.Cancel;

                    QuickImageEditorResult = quickImageEditorResult;
                }

                // Go and process the capture
                DialogResult = DialogResult.OK;
            }
            else
            {
                Invalidate();
            }
        }

        /// <summary>
        /// The mouse up handler of the capture form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                HandleMouseUp();
            }
        }

        /// <summary>
        /// This method is used to "fix" the mouse coordinates when keeping shift/ctrl pressed
        /// </summary>
        /// <param name="currentMouse"></param>
        /// <returns></returns>
        private Point FixMouseCoordinates(Point currentMouse)
        {
            if (_fixMode == FixMode.Initiated)
            {
                if (_previousMousePos.X != currentMouse.X)
                {
                    _fixMode = FixMode.Vertical;
                }
                else if (_previousMousePos.Y != currentMouse.Y)
                {
                    _fixMode = FixMode.Horizontal;
                }
            }
            else if (_fixMode == FixMode.Vertical)
            {
                currentMouse = new Point(currentMouse.X, _previousMousePos.Y);
            }
            else if (_fixMode == FixMode.Horizontal)
            {
                currentMouse = new Point(_previousMousePos.X, currentMouse.Y);
            }

            _previousMousePos = currentMouse;
            return currentMouse;
        }

        /// <summary>
        /// The mouse move handler of the capture form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // Make sure the mouse coordinates are fixed, when pressing shift
            _mouseMovePos = FixMouseCoordinates(User32.GetCursorLocation());
            _mouseMovePos = WindowCapture.GetLocationRelativeToScreenBounds(_mouseMovePos);
        }

        /// <summary>
        /// Helper method to simplify check
        /// </summary>
        /// <param name="animator"></param>
        /// <returns></returns>
        private bool IsAnimating(IAnimator animator)
        {
            if (animator == null)
            {
                return false;
            }

            return animator.HasNext;
        }

        /// <summary>
        /// update the frame, this only invalidates
        /// </summary>
        protected override void Animate()
        {
            Point lastPos = _cursorPos;
            _cursorPos = _mouseMovePos;

            if (_selectedCaptureWindow != null && lastPos.Equals(_cursorPos) && !IsAnimating(_zoomAnimator) &&
                !IsAnimating(_windowAnimator))
                return;

            WindowDetails lastWindow = _selectedCaptureWindow;
            //bool horizontalMove = false;
            //bool verticalMove = false;

            //if (lastPos.X != _cursorPos.X)
            //{
            //    horizontalMove = true;
            //}

            //if (lastPos.Y != _cursorPos.Y)
            //{
            //    verticalMove = true;
            //}

            if (_captureMode == CaptureMode.Region && _mouseDown)
            {
                _captureRect =
                    GuiRectangle.GetGuiRectangle(_cursorPos.X, _cursorPos.Y, _mX - _cursorPos.X, _mY - _cursorPos.Y);
            }

            // Iterate over the found windows and check if the current location is inside a window
            Point cursorPosition = Cursor.Position;
            _selectedCaptureWindow = null;
            lock (_windows)
            {
                foreach (var window in _windows)
                {
                    if (!window.Contains(cursorPosition))
                    {
                        continue;
                    }

                    // Only go over the children if we are in window mode
                    _selectedCaptureWindow = CaptureMode.Window == _captureMode
                        ? window.FindChildUnderPoint(cursorPosition)
                        : window;
                    break;
                }
            }

            if (_selectedCaptureWindow != null && !_selectedCaptureWindow.Equals(lastWindow))
            {
                _capture.CaptureDetails.Title = _selectedCaptureWindow.Text;
                _capture.CaptureDetails.AddMetaData("windowtitle", _selectedCaptureWindow.Text);
                if (_captureMode == CaptureMode.Window)
                {
                    // Here we want to capture the window which is under the mouse
                    _captureRect = _selectedCaptureWindow.WindowRectangle;
                    // As the ClientRectangle is not in Bitmap coordinates, we need to correct.
                    _captureRect.Offset(-_capture.ScreenBounds.Location.X, -_capture.ScreenBounds.Location.Y);
                }
            }

            //Rectangle invalidateRectangle;

            //if (_captureMode != CaptureMode.Window)
            //{
            //    // Оси (которые на весь экран)
            //    if (!IsTerminalServerSession)
            //    {
            //        Rectangle allScreenBounds = WindowCapture.GetScreenBounds();
            //        allScreenBounds.Location =
            //            WindowCapture.GetLocationRelativeToScreenBounds(allScreenBounds.Location);
            //        if (verticalMove)
            //        {
            //            // Before
            //            invalidateRectangle =
            //                GuiRectangle.GetGuiRectangle(allScreenBounds.Left, lastPos.Y - 2, Width + 2, 45);
            //            Invalidate(invalidateRectangle);
            //            // After
            //            invalidateRectangle =
            //                GuiRectangle.GetGuiRectangle(allScreenBounds.Left, _cursorPos.Y - 2, Width + 2, 45);
            //            Invalidate(invalidateRectangle);
            //        }

            //        if (horizontalMove)
            //        {
            //            // Before
            //            invalidateRectangle =
            //                GuiRectangle.GetGuiRectangle(lastPos.X - 2, allScreenBounds.Top, 75, Height + 2);
            //            Invalidate(invalidateRectangle);
            //            // After
            //            invalidateRectangle =
            //                GuiRectangle.GetGuiRectangle(_cursorPos.X - 2, allScreenBounds.Top, 75, Height + 2);
            //            Invalidate(invalidateRectangle);
            //        }
            //    }

            //    if (_mouseDown)
            //    {
            //        // Прямоугольник (надпись в центре + заливака, если установлено)
            //        int x1 = Math.Min(_mX, lastPos.X);
            //        int x2 = Math.Max(_mX, lastPos.X);
            //        int y1 = Math.Min(_mY, lastPos.Y);
            //        int y2 = Math.Max(_mY, lastPos.Y);

            //        x1 = Math.Min(x1, _cursorPos.X);
            //        x2 = Math.Max(x2, _cursorPos.X);
            //        y1 = Math.Min(y1, _cursorPos.Y);
            //        y2 = Math.Max(y2, _cursorPos.Y);

            //        // Safety correction
            //        x2 += 2;
            //        y2 += 2;

            //        // Here we correct for text-size

            //        // Calculate the size
            //        //int textForWidth = Math.Max(Math.Abs(_mX - _cursorPos.X), Math.Abs(_mX - lastPos.X));
            //        //int textForHeight = Math.Max(Math.Abs(_mY - _cursorPos.Y), Math.Abs(_mY - lastPos.Y));

            //        //using (Font rulerFont = new Font(FontFamily.GenericSansSerif, 8))
            //        //{
            //        //    Size measureWidth =
            //        //        TextRenderer.MeasureText(textForWidth.ToString(CultureInfo.InvariantCulture), rulerFont);
            //        //    x1 -= measureWidth.Width + 15;

            //        //    Size measureHeight = TextRenderer.MeasureText(textForHeight.ToString(CultureInfo.InvariantCulture),
            //        //        rulerFont);
            //        //    y1 -= measureHeight.Height + 10;
            //        //}

            //        Size textSize;

            //        using (var font = new Font(new FontFamily(SizeLabelFontFamily), SizeLabelFontSize))
            //        {
            //            var text = GetSizeLabelText();
            //            textSize =
            //                TextRenderer.MeasureText(text, font);

            //            textSize = new Size(textSize.Width + SizeLabelMargin, textSize.Height + SizeLabelMargin);
            //        }

            //        invalidateRectangle = new Rectangle(x1 - 1, y1 - 1, x2 - x1 + 1, y2 - y1 + 1);
            //        invalidateRectangle.Inflate(textSize.Width + 1, textSize.Height + 1);
            //        Invalidate(invalidateRectangle);
            //    }
            //}
            //else
            //{
            //    if (_selectedCaptureWindow != null && !_selectedCaptureWindow.Equals(lastWindow))
            //    {
            //        // Window changes, make new animation from current to target
            //        _windowAnimator.ChangeDestination(_captureRect, FramesForMillis(700));
            //    }
            //}

            //// always animate the Window area through to the last frame, so we see the fade-in/out untill the end
            //// Using a safety "offset" to make sure the text is invalidated too
            //const int safetySize = 30;
            //// Check if the animation needs to be drawn
            //if (IsAnimating(_windowAnimator))
            //{
            //    invalidateRectangle = _windowAnimator.Current;
            //    invalidateRectangle.Inflate(safetySize, safetySize);
            //    Invalidate(invalidateRectangle);
            //    invalidateRectangle = _windowAnimator.Next();
            //    invalidateRectangle.Inflate(safetySize, safetySize);
            //    Invalidate(invalidateRectangle);
            //    // Check if this was the last of the windows animations in the normal region capture.
            //    if (_captureMode != CaptureMode.Window && !IsAnimating(_windowAnimator))
            //    {
            //        Invalidate();
            //    }
            //}

            //if (_zoomAnimator != null && (IsAnimating(_zoomAnimator) || _captureMode != CaptureMode.Window))
            //{
            //    // Make sure we invalidate the old zoom area
            //    invalidateRectangle = _zoomAnimator.Current;
            //    invalidateRectangle.Offset(lastPos);
            //    Invalidate(invalidateRectangle);
            //    // Only verify if we are really showing the zoom, not the outgoing animation
            //    if (Conf.ZoomerEnabled && _captureMode != CaptureMode.Window)
            //    {
            //        VerifyZoomAnimation(_cursorPos, false);
            //    }

            //    // The following logic is not needed, next always returns the current if there are no frames left
            //    // but it makes more sense if we want to change something in the logic
            //    invalidateRectangle = IsAnimating(_zoomAnimator) ? _zoomAnimator.Next() : _zoomAnimator.Current;
            //    invalidateRectangle.Offset(_cursorPos);
            //    Invalidate(invalidateRectangle);
            //}

            Invalidate();
            // Force update "now"
            Update();
        }

        /// <summary>
        /// This makes sure there is no background painted, as we have complete "paint" control it doesn't make sense to do otherwise.
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        /// <summary>
        /// Paint the actual visible parts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle clipRectangle = e.ClipRectangle;
            //graphics.BitBlt((Bitmap)buffer, Point.Empty);
            graphics.DrawImageUnscaled(_capture.Image, Point.Empty);
            // Only draw Cursor if it's (partly) visible

            if (_capture.Cursor != null && _capture.CursorVisible &&
                clipRectangle.IntersectsWith(new Rectangle(_capture.CursorLocation, _capture.Cursor.Size)))
            {
                graphics.DrawIcon(_capture.Cursor, _capture.CursorLocation.X, _capture.CursorLocation.Y);
            }

            if (_mouseDown || _captureMode == CaptureMode.Window || IsAnimating(_windowAnimator))
            {
                _captureRect.Intersect(new Rectangle(Point.Empty,
                    _capture.ScreenBounds.Size)); // crop what is outside the screen

                var fixedRect = IsAnimating(_windowAnimator) ? _windowAnimator.Current : _captureRect;

                // TODO: enable when the screen capture code works reliable
                //if (capture.CaptureDetails.CaptureMode == CaptureMode.Video) {
                //	graphics.FillRectangle(RedOverlayBrush, fixedRect);
                //} else {

                if (_overlayColor.HasValue)
                    using (var brush = new SolidBrush(_overlayColor.Value))
                    {
                        graphics.FillRectangle(brush, fixedRect);
                    }

                Rectangle screenBounds = _capture.ScreenBounds;

                using (Brush brush = new HatchBrush(BorderHatchStyle, BorderForeColor, BorderBackColor))
                using (Pen pen = new Pen(brush))
                {
                    graphics.DrawLine(pen, screenBounds.X, _mY, screenBounds.Width, _mY);
                    graphics.DrawLine(pen, _mX, screenBounds.Y, _mX, screenBounds.Height);
                    graphics.DrawLine(pen, screenBounds.X, _cursorPos.Y, screenBounds.Width, _cursorPos.Y);
                    graphics.DrawLine(pen, _cursorPos.X, screenBounds.Y, _cursorPos.X, screenBounds.Height);
                }

                //using (Brush brush = new HatchBrush(BorderHatchStyle, BorderForeColor, BorderBackColor))
                //using (Pen pen = new Pen(brush))
                //{
                //    graphics.DrawRectangle(pen, fixedRect);
                //}

                //DrawRulers(graphics, fixedRect);

                if (!fixedRect.IsEmpty)
                    DrawSize(graphics, fixedRect);
            }
            else
            {
                if (!IsTerminalServerSession)
                {
                    Rectangle screenBounds = _capture.ScreenBounds;

                    // Оси координат (до нажатия кнопки мыши).

                    using (Brush brush = new HatchBrush(BorderHatchStyle, BorderForeColor, BorderBackColor))
                    using (Pen pen = new Pen(brush))
                    {
                        graphics.DrawLine(pen, _cursorPos.X, screenBounds.Y, _cursorPos.X, screenBounds.Height);
                        graphics.DrawLine(pen, screenBounds.X, _cursorPos.Y, screenBounds.Width, _cursorPos.Y);
                    }

                    // Координаты
                    string xy = _cursorPos.X + " x " + _cursorPos.Y;

                    using (Font font = new Font(FontFamily.GenericSansSerif, 8))
                    {
                        Size xySize = TextRenderer.MeasureText(xy, font);
                        using (GraphicsPath gp = RoundedRectangle.Create2(_cursorPos.X + 5, _cursorPos.Y + 5,
                            xySize.Width - 3, xySize.Height, 3))
                        {
                            using (Brush bgBrush = new SolidBrush(_overlayColor ?? Color.White))
                            {
                                graphics.FillPath(bgBrush, gp);
                            }

                            using (Pen pen = new Pen(Color.Black))
                            {
                                graphics.DrawPath(pen, gp);

                                var coordinatePosition = new Point(_cursorPos.X + 5, _cursorPos.Y + 5);
                                graphics.DrawString(xy, font, pen.Brush, coordinatePosition);
                            }
                        }
                    }
                }
            }

            // Zoom
            if (_zoomAnimator != null && (IsAnimating(_zoomAnimator) || _captureMode != CaptureMode.Window))
            {
                const int zoomSourceWidth = 25;
                const int zoomSourceHeight = 25;

                Rectangle sourceRectangle = new Rectangle(_cursorPos.X - zoomSourceWidth / 2,
                    _cursorPos.Y - zoomSourceHeight / 2, zoomSourceWidth, zoomSourceHeight);

                Rectangle destinationRectangle = _zoomAnimator.Current;
                destinationRectangle.Offset(_cursorPos);
                DrawZoom(graphics, sourceRectangle, destinationRectangle);
            }
        }

        //private void DrawRulers(Graphics graphics, Rectangle fixedRect)
        //{
        //    // rulers
        //    const int dist = 8;

        //    string captureWidth;
        //    string captureHeight;
        //    // The following fixes the very old incorrect size information bug
        //    if (_captureMode == CaptureMode.Window)
        //    {
        //        captureWidth = _captureRect.Width.ToString(CultureInfo.InvariantCulture);
        //        captureHeight = _captureRect.Height.ToString(CultureInfo.InvariantCulture);
        //    }
        //    else
        //    {
        //        captureWidth = (_captureRect.Width + 1).ToString(CultureInfo.InvariantCulture);
        //        captureHeight = (_captureRect.Height + 1).ToString(CultureInfo.InvariantCulture);
        //    }

        //    using (Font rulerFont = new Font(FontFamily.GenericSansSerif, 8))
        //    {
        //        Size measureWidth = TextRenderer.MeasureText(captureWidth, rulerFont);
        //        Size measureHeight = TextRenderer.MeasureText(captureHeight, rulerFont);
        //        int hSpace = measureWidth.Width + 3;
        //        int vSpace = measureHeight.Height + 3;
        //        //Brush bgBrush = new SolidBrush(Color.FromArgb(200, 217, 240, 227));
        //        Brush bgBrush = new SolidBrush(Color.Transparent);

        //        var rulerBrush = new SolidBrush(Color.Black);
        //        Pen rulerPen = new Pen(rulerBrush);

        //        // horizontal ruler
        //        if (fixedRect.Width > hSpace + 3)
        //        {
        //            using (GraphicsPath p = RoundedRectangle.Create2(
        //                fixedRect.X + (fixedRect.Width / 2 - hSpace / 2) + 3,
        //                fixedRect.Y - dist - 7,
        //                measureWidth.Width - 3,
        //                measureWidth.Height,
        //                3))
        //            {
        //                graphics.FillPath(bgBrush, p);
        //                graphics.DrawPath(rulerPen, p);
        //                graphics.DrawString(captureWidth, rulerFont, rulerPen.Brush,
        //                    fixedRect.X + (fixedRect.Width / 2 - hSpace / 2) + 3, fixedRect.Y - dist - 7);
        //                graphics.DrawLine(rulerPen, fixedRect.X, fixedRect.Y - dist,
        //                    fixedRect.X + (fixedRect.Width / 2 - hSpace / 2), fixedRect.Y - dist);
        //                graphics.DrawLine(rulerPen, fixedRect.X + fixedRect.Width / 2 + hSpace / 2,
        //                    fixedRect.Y - dist, fixedRect.X + fixedRect.Width, fixedRect.Y - dist);
        //                graphics.DrawLine(rulerPen, fixedRect.X, fixedRect.Y - dist - 3, fixedRect.X,
        //                    fixedRect.Y - dist + 3);
        //                graphics.DrawLine(rulerPen, fixedRect.X + fixedRect.Width, fixedRect.Y - dist - 3,
        //                    fixedRect.X + fixedRect.Width, fixedRect.Y - dist + 3);
        //            }
        //        }

        //        // vertical ruler
        //        if (fixedRect.Height > vSpace + 3)
        //        {
        //            using (GraphicsPath p = RoundedRectangle.Create2(
        //                fixedRect.X - measureHeight.Width + 1,
        //                fixedRect.Y + (fixedRect.Height / 2 - vSpace / 2) + 2,
        //                measureHeight.Width - 3,
        //                measureHeight.Height - 1,
        //                3))
        //            {
        //                graphics.FillPath(bgBrush, p);
        //                graphics.DrawPath(rulerPen, p);
        //                graphics.DrawString(captureHeight, rulerFont, rulerPen.Brush,
        //                    fixedRect.X - measureHeight.Width + 1,
        //                    fixedRect.Y + (fixedRect.Height / 2 - vSpace / 2) + 2);
        //                graphics.DrawLine(rulerPen, fixedRect.X - dist, fixedRect.Y, fixedRect.X - dist,
        //                    fixedRect.Y + (fixedRect.Height / 2 - vSpace / 2));
        //                graphics.DrawLine(rulerPen, fixedRect.X - dist,
        //                    fixedRect.Y + fixedRect.Height / 2 + vSpace / 2, fixedRect.X - dist,
        //                    fixedRect.Y + fixedRect.Height);
        //                graphics.DrawLine(rulerPen, fixedRect.X - dist - 3, fixedRect.Y, fixedRect.X - dist + 3,
        //                    fixedRect.Y);
        //                graphics.DrawLine(rulerPen, fixedRect.X - dist - 3, fixedRect.Y + fixedRect.Height,
        //                    fixedRect.X - dist + 3, fixedRect.Y + fixedRect.Height);
        //            }
        //        }

        //        rulerBrush.Dispose();
        //        rulerPen.Dispose();
        //        bgBrush.Dispose();
        //    }
        //}

        #region Размер выделенной области (надпись в центре)

        //private SizeF GetLabelSize(Graphics graphics)
        //{
        //    using (var font = new Font(new FontFamily("Microsoft Sans Serif"), 25))
        //    {
        //        string text = GetText();
        //        return graphics?.MeasureString(text, font) ?? TextRenderer.MeasureText(text, font);
        //    }
        //}

        private string GetSizeLabelText()
        {
            string text;

            if (CaptureMode.Region == _captureMode)
                text = _captureRect.Width + 1 + "x" +
                       (_captureRect.Height + 1);
            else
                text = _captureRect.Width + "x" + _captureRect.Height;

            return text;
        }

        private void DrawSize(Graphics graphics, Rectangle fixedRect)
        {
            using (var font = new Font(new FontFamily(SizeLabelFontFamily), SizeLabelFontSize))
            {
                var text = GetSizeLabelText();
                var textSize = graphics.MeasureString(text, font);

                int sizeLabelLeft = fixedRect.X;
                int sizeLabelTop = fixedRect.Y - (int) textSize.Height - SizeLabelMargin;

                var screenBounds = _capture.ScreenBounds;

                if (sizeLabelTop < screenBounds.Y)
                {
                    sizeLabelLeft = fixedRect.X + SizeLabelMargin + 1;
                    sizeLabelTop = fixedRect.Y + SizeLabelMargin + 1;
                }

                if (sizeLabelLeft + textSize.Width > screenBounds.Width)
                    sizeLabelLeft = fixedRect.X - (int) textSize.Width - SizeLabelMargin;

                var sizeRectangle = new Rectangle(sizeLabelLeft, sizeLabelTop, (int) textSize.Width + 1,
                    (int) textSize.Height + 1);

                using (var backBrush = new SolidBrush(SizeLabelBackColor))
                using (var rectanglePen = new Pen(SizeLabelForeColor, 1))
                using (var foreBrush = new SolidBrush(SizeLabelForeColor))
                {
                    graphics.FillRectangle(backBrush, sizeRectangle);
                    graphics.DrawRectangle(rectanglePen, sizeRectangle);
                    graphics.DrawString(text, font, foreBrush, new PointF(sizeRectangle.X, sizeRectangle.Y));
                }
            }

            //// Display size of selected rectangle
            //// Prepare the font and text.
            //using (Font sizeFont = new Font(FontFamily.GenericSansSerif, 12))
            //{
            //    // When capturing a Region we need to add 1 to the height/width for correction
            //    string sizeText;
            //    if (_captureMode == CaptureMode.Region)
            //        sizeText = _captureRect.Width + 1 + " x " +
            //                   (_captureRect.Height + 1); // correct the GUI width to real width for the shown size
            //    else
            //        sizeText = _captureRect.Width + " x " + _captureRect.Height;

            //    // Calculate the scaled font size.
            //    SizeF extent = graphics.MeasureString(sizeText, sizeFont);
            //    float hRatio = _captureRect.Height / (extent.Height * 2);
            //    float wRatio = _captureRect.Width / (extent.Width * 2);
            //    float ratio = hRatio < wRatio ? hRatio : wRatio;
            //    float newSize = sizeFont.Size * ratio;

            //    if (newSize >= 4)
            //    {
            //        // Only show if 4pt or larger.
            //        if (newSize > 32)
            //            newSize = 32;

            //        // Draw the size.
            //        using (Font newSizeFont = new Font(FontFamily.GenericSansSerif, newSize, FontStyle.Bold))
            //        {
            //            var textSizeF = graphics.MeasureString(sizeText, newSizeFont);
            //            var textSize = new Size((int)textSizeF.Width, (int)textSizeF.Height);

            //            Point sizeLabelLocation =
            //                new Point((int)(fixedRect.X + _captureRect.Width / 2f - textSize.Width / 2f),
            //                    (int)(fixedRect.Y + _captureRect.Height / 2f - textSize.Height / 2f));

            //            // ====================================== > Outline < ======================================
            //            using (var graphicsPath = new GraphicsPath())
            //            {
            //                graphicsPath.AddString(
            //                    sizeText,
            //                    FontFamily.GenericSansSerif,
            //                    (int)FontStyle.Regular,
            //                    graphics.DpiY * newSize / 72,
            //                    sizeLabelLocation,
            //                    new StringFormat());

            //                using (Brush brush = new SolidBrush(SizeLabelForeColor))
            //                {
            //                    graphics.FillPath(brush, graphicsPath);
            //                }

            //                if (!_overlayColor.HasValue)
            //                    graphics.DrawPath(Pens.Black, graphicsPath);
            //            }
            //            // ========================================= > END < =========================================

            //            // ===================================== > HatchBrush < =====================================
            //            //using (Brush brush = _overlayColor.HasValue
            //            //    ? (Brush)new SolidBrush(SizeLabelForeColor)
            //            //    : new HatchBrush(BorderHatchStyle, BorderForeColor, BorderBackColor))
            //            //{
            //            //    graphics.DrawString(sizeText, newSizeFont, brush, sizeLabelLocation);
            //            //}
            //            // ========================================= > END < =========================================


            //            // ===================================== > TextureBrush #1 < =====================================
            //            //using (Brush brush = _overlayColor.HasValue
            //            //    ? (Brush)new SolidBrush(SizeLabelForeColor)
            //            //    : new TextureBrush(_capture.Image, new RectangleF(0, 0, sizeLabelLocation.X + textSize.Width, sizeLabelLocation.Y + textSize.Height), GetImageAttributes()))
            //            //{
            //            //    graphics.DrawString(sizeText, newSizeFont, brush, sizeLabelLocation);
            //            //}
            //            // =========================================== > END < ===========================================

            //            // ===================================== > TextureBrush #2 < =====================================
            //            //var backgroundRectangle = new Rectangle(sizeLabelLocation, textSize);
            //            //var background = CreateSizeLabelBackground(backgroundRectangle);

            //            //using (Brush brush = _overlayColor.HasValue
            //            //    ? (Brush)new SolidBrush(SizeLabelForeColor)
            //            //    : new TextureBrush(background, new RectangleF(0, 0, background.Width, background.Height),
            //            //        GetImageAttributes()))
            //            //{
            //            //    using (var backgroundGraphics = Graphics.FromImage(background))
            //            //    {
            //            //        backgroundGraphics.DrawString(sizeText, newSizeFont, brush, 0, 0);
            //            //    }

            //            //    graphics.DrawImage(background, sizeLabelLocation);
            //            //}
            //            // =========================================== > END < ===========================================

            //            // ===================================== > TextureBrush #3 < =====================================
            //            //var backgroundRectangle = new Rectangle(sizeLabelLocation, textSize);

            //            //var background = CreateSizeLabelBackground(backgroundRectangle);
            //            //var transformedBackground = CreateSizeLabelBackground(backgroundRectangle, ColorTransformKind.Invert);

            //            //using (Brush brush = _overlayColor.HasValue
            //            //    ? (Brush)new SolidBrush(SizeLabelForeColor)
            //            //    : new TextureBrush(transformedBackground, new RectangleF(0, 0, background.Width, background.Height)))
            //            //{
            //            //    using (var backgroundGraphics = Graphics.FromImage(background))
            //            //    {
            //            //        backgroundGraphics.DrawString(sizeText, newSizeFont, brush, 0, 0);
            //            //    }

            //            //    graphics.DrawImage(background, sizeLabelLocation);
            //            //}
            //            // =========================================== > END < ===========================================

            //            //if (_showDebugInfo && _selectedCaptureWindow != null)
            //            //{
            //            //    string title =
            //            //        $"#{_selectedCaptureWindow.Handle.ToInt64():X} - {(_selectedCaptureWindow.Text.Length > 0 ? _selectedCaptureWindow.Text : _selectedCaptureWindow.Process.ProcessName)}";
            //            //    PointF debugLocation = new PointF(fixedRect.X, fixedRect.Y);
            //            //    graphics.DrawString(title, sizeFont, Brushes.DarkOrange, debugLocation);
            //            //}
            //        }
            //    }
            //}
        }

        //// https://stackoverflow.com/questions/734930/how-to-crop-an-image-using-c
        //private Image CreateSizeLabelBackground(Rectangle rectangle,
        //    ColorTransformKind colorTransformKind = ColorTransformKind.None)
        //{
        //    var bitmap = new Bitmap(_capture.Image);
        //    bitmap = bitmap.Clone(rectangle, bitmap.PixelFormat);

        //    if (ColorTransformKind.None != colorTransformKind)
        //        TransformColors(bitmap, colorTransformKind);

        //    return bitmap;
        //}

        //// https://stackoverflow.com/questions/11779809/inverting-image-returns-a-black-image/11781561#11781561
        //private static void TransformColors(Bitmap bitmapImage, ColorTransformKind colorTransformKind)
        //{
        //    var bitmapRead = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height),
        //        ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
        //    var bitmapLength = bitmapRead.Stride * bitmapRead.Height;
        //    var bitmapBgra = new byte[bitmapLength];

        //    Marshal.Copy(bitmapRead.Scan0, bitmapBgra, 0, bitmapLength);

        //    bitmapImage.UnlockBits(bitmapRead);

        //    for (int i = 0; i < bitmapLength; i += 4)
        //    {
        //        switch (colorTransformKind)
        //        {
        //            case ColorTransformKind.Invert:
        //                bitmapBgra[i] = (byte)(255 - bitmapBgra[i]);
        //                bitmapBgra[i + 1] = (byte)(255 - bitmapBgra[i + 1]);
        //                bitmapBgra[i + 2] = (byte)(255 - bitmapBgra[i + 2]);
        //                break;
        //            case ColorTransformKind.BlackWhite:
        //            {
        //                const byte threshold = 100;

        //                byte r = bitmapBgra[i + 2];
        //                byte g = bitmapBgra[i + 1];
        //                byte b = bitmapBgra[i];

        //                r = r > threshold && g > threshold && b > threshold ? (byte) 0 : (byte) 255;

        //                bitmapBgra[i] = r;
        //                bitmapBgra[i + 1] = r;
        //                bitmapBgra[i + 2] = r;
        //            }
        //                break;
        //        }
        //    }

        //    var bitmapWrite = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height),
        //        ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
        //    Marshal.Copy(bitmapBgra, 0, bitmapWrite.Scan0, bitmapLength);
        //    bitmapImage.UnlockBits(bitmapWrite);
        //}

        //private ImageAttributes GetImageAttributes()
        //{
        //    float[][] colorMatrixElements =
        //    {
        //        new float[] {-1, 0, 0, 0, 0},
        //        new float[] {0, -1, 0, 0, 0},
        //        new float[] {0, 0, -1, 0, 0},
        //        new float[] {0, 0, 0, 1, 0},
        //        new float[] {1, 1, 1, 0, 0}
        //    };

        //    //float[][] colorMatrixElements =
        //    //{
        //    //    new float[] {-0.333f, -0.333f, -0.333f, 0, 0},
        //    //    new float[] {-0.333f, -0.333f, -0.333f, 0, 0},
        //    //    new float[] {-0.333f, -0.333f, -0.333f, 0, 0},
        //    //    new float[] {0, 0, 0, 1, 0},
        //    //    new float[] {1, 1, 1, 0, 1}
        //    //};

        //    var colorMatrix = new ColorMatrix(colorMatrixElements);

        //    var imageAttributes = new ImageAttributes();
        //    imageAttributes.SetColorMatrix(colorMatrix);

        //    return imageAttributes;
        //}

        #endregion

        #endregion

        #region Zoom

        /// <summary>
        /// Checks if the Zoom area can move there where it wants to go, change direction if not.
        /// </summary>
        /// <param name="pos">preferred destination location for the zoom area</param>
        /// <param name="allowZoomOverCaptureRect">false to try to find a location which is neither out of screen bounds nor intersects with the selected rectangle</param>
        private void VerifyZoomAnimation(Point pos, bool allowZoomOverCaptureRect)
        {
            Rectangle screenBounds = Screen.GetBounds(MousePosition);
            // convert to be relative to top left corner of all screen bounds
            screenBounds.Location = WindowCapture.GetLocationRelativeToScreenBounds(screenBounds.Location);
            int relativeZoomSize = Math.Min(screenBounds.Width, screenBounds.Height) / 5;
            // Make sure the final size is a plural of 4, this makes it look better
            relativeZoomSize = relativeZoomSize - relativeZoomSize % 4;
            Size zoomSize = new Size(relativeZoomSize, relativeZoomSize);
            Point zoomOffset = new Point(20, 20);

            Rectangle targetRectangle = _zoomAnimator.Final;
            targetRectangle.Offset(pos);
            if (!screenBounds.Contains(targetRectangle) ||
                (!allowZoomOverCaptureRect && _captureRect.IntersectsWith(targetRectangle)))
            {
                Point destinationLocation = Point.Empty;
                Rectangle tl = new Rectangle(pos.X - (zoomOffset.X + zoomSize.Width),
                    pos.Y - (zoomOffset.Y + zoomSize.Height), zoomSize.Width, zoomSize.Height);
                Rectangle tr = new Rectangle(pos.X + zoomOffset.X, pos.Y - (zoomOffset.Y + zoomSize.Height),
                    zoomSize.Width, zoomSize.Height);
                Rectangle bl = new Rectangle(pos.X - (zoomOffset.X + zoomSize.Width), pos.Y + zoomOffset.Y,
                    zoomSize.Width, zoomSize.Height);
                Rectangle br = new Rectangle(pos.X + zoomOffset.X, pos.Y + zoomOffset.Y, zoomSize.Width,
                    zoomSize.Height);
                if (screenBounds.Contains(br) && (allowZoomOverCaptureRect || !_captureRect.IntersectsWith(br)))
                {
                    destinationLocation = new Point(zoomOffset.X, zoomOffset.Y);
                }
                else if (screenBounds.Contains(bl) && (allowZoomOverCaptureRect || !_captureRect.IntersectsWith(bl)))
                {
                    destinationLocation = new Point(-zoomOffset.X - zoomSize.Width, zoomOffset.Y);
                }
                else if (screenBounds.Contains(tr) && (allowZoomOverCaptureRect || !_captureRect.IntersectsWith(tr)))
                {
                    destinationLocation = new Point(zoomOffset.X, -zoomOffset.Y - zoomSize.Width);
                }
                else if (screenBounds.Contains(tl) && (allowZoomOverCaptureRect || !_captureRect.IntersectsWith(tl)))
                {
                    destinationLocation = new Point(-zoomOffset.X - zoomSize.Width, -zoomOffset.Y - zoomSize.Width);
                }

                if (destinationLocation == Point.Empty && !allowZoomOverCaptureRect)
                {
                    VerifyZoomAnimation(pos, true);
                }
                else
                {
                    _zoomAnimator.ChangeDestination(new Rectangle(destinationLocation, zoomSize));
                }
            }
        }

        /// <summary>
        /// Draw the zoomed area
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="sourceRectangle"></param>
        /// <param name="destinationRectangle"></param>
        private void DrawZoom(Graphics graphics, Rectangle sourceRectangle, Rectangle destinationRectangle)
        {
            if (_capture.Image == null)
            {
                return;
            }

            ImageAttributes attributes;

            if (_isZoomerTransparent)
            {
                //create a color matrix object to change the opacy
                ColorMatrix opacyMatrix = new ColorMatrix
                {
                    Matrix33 = Conf.ZoomerOpacity
                };
                attributes = new ImageAttributes();
                attributes.SetColorMatrix(opacyMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            }
            else
            {
                attributes = null;
            }

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(destinationRectangle);
                graphics.SetClip(path);
                if (!_isZoomerTransparent)
                {
                    graphics.FillRectangle(BackgroundBrush, destinationRectangle);
                    graphics.DrawImage(_capture.Image, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                else
                {
                    graphics.DrawImage(_capture.Image, destinationRectangle, sourceRectangle.X, sourceRectangle.Y,
                        sourceRectangle.Width, sourceRectangle.Height, GraphicsUnit.Pixel, attributes);
                }
            }

            int alpha = (int)(255 * Conf.ZoomerOpacity);
            Color opacyWhite = Color.FromArgb(alpha, 255, 255, 255);
            Color opacyBlack = Color.FromArgb(alpha, 0, 0, 0);

            // Draw the circle around the zoomer
            using (Pen pen = new Pen(opacyWhite, 2))
            {
                graphics.DrawEllipse(pen, destinationRectangle);
            }

            // Make sure we don't have a pixeloffsetmode/smoothingmode when drawing the crosshair
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.PixelOffsetMode = PixelOffsetMode.None;

            // Calculate some values
            int pixelThickness = destinationRectangle.Width / sourceRectangle.Width;
            int halfWidth = destinationRectangle.Width / 2;
            int halfWidthEnd = destinationRectangle.Width / 2 - pixelThickness / 2;
            int halfHeight = destinationRectangle.Height / 2;
            int halfHeightEnd = destinationRectangle.Height / 2 - pixelThickness / 2;

            int drawAtHeight = destinationRectangle.Y + halfHeight;
            int drawAtWidth = destinationRectangle.X + halfWidth;
            int padding = pixelThickness;

            // Pen to draw
            using (Pen pen = new Pen(opacyBlack, pixelThickness))
            {
                // Draw the croshair-lines
                // Vertical top to middle
                graphics.DrawLine(pen, drawAtWidth, destinationRectangle.Y + padding, drawAtWidth,
                    destinationRectangle.Y + halfHeightEnd - padding);
                // Vertical middle + 1 to bottom
                graphics.DrawLine(pen, drawAtWidth, destinationRectangle.Y + halfHeightEnd + 2 * padding, drawAtWidth,
                    destinationRectangle.Y + destinationRectangle.Width - padding);
                // Horizontal left to middle
                graphics.DrawLine(pen, destinationRectangle.X + padding, drawAtHeight,
                    destinationRectangle.X + halfWidthEnd - padding, drawAtHeight);
                // Horizontal middle + 1 to right
                graphics.DrawLine(pen, destinationRectangle.X + halfWidthEnd + 2 * padding, drawAtHeight,
                    destinationRectangle.X + destinationRectangle.Width - padding, drawAtHeight);

                // Fix offset for drawing the white rectangle around the crosshair-lines
                drawAtHeight -= pixelThickness / 2;
                drawAtWidth -= pixelThickness / 2;
                // Fix off by one error with the DrawRectangle
                pixelThickness -= 1;
                // Change the color and the pen width
                pen.Color = opacyWhite;
                pen.Width = 1;
                // Vertical top to middle
                graphics.DrawRectangle(pen, drawAtWidth, destinationRectangle.Y + padding, pixelThickness,
                    halfHeightEnd - 2 * padding - 1);
                // Vertical middle + 1 to bottom
                graphics.DrawRectangle(pen, drawAtWidth, destinationRectangle.Y + halfHeightEnd + 2 * padding,
                    pixelThickness, halfHeightEnd - 2 * padding - 1);
                // Horizontal left to middle
                graphics.DrawRectangle(pen, destinationRectangle.X + padding, drawAtHeight,
                    halfWidthEnd - 2 * padding - 1, pixelThickness);
                // Horizontal middle + 1 to right
                graphics.DrawRectangle(pen, destinationRectangle.X + halfWidthEnd + 2 * padding, drawAtHeight,
                    halfWidthEnd - 2 * padding - 1, pixelThickness);
            }

            attributes?.Dispose();
        }

        #endregion
    }
}