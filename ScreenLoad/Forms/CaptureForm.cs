using ScreenLoad.Drawing;
using ScreenLoad.Helpers;
using ScreenLoad.IniFile;
using ScreenLoad.Plugin;
using ScreenLoadPlugin.Controls;
using ScreenLoadPlugin.Core;
using ScreenLoadPlugin.UnmanagedHelpers;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace ScreenLoad
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
        }

        private struct Invalidation
        {
            private Rectangle _current;

            public Rectangle Before { get; set; }

            public Rectangle Current
            {
                get => _current;
                set
                {
                    Before = _current;
                    _current = value;
                }
            }

            public bool IsEmpty => Current.IsEmpty;

            public void Invalidate(Control control, int inflate = 0)
            {
                var before = Before;
                var current = Current;

                if (0 != inflate)
                {
                    before.Inflate(inflate, inflate);
                    current.Inflate(inflate, inflate);
                }

                if (!before.IsEmpty)
                    control.Invalidate(before);

                if (!current.IsEmpty)
                    control.Invalidate(current);
            }

            public void DrawLine(Graphics graphics, Pen pen)
            {
                if (Current.IsEmpty)
                    return;

                int x2;
                int y2;

                if (1 == Current.Width)
                {
                    x2 = Current.X;
                    y2 = Current.Y + Current.Height;
                }
                else if (1 == Current.Height)
                {
                    x2 = Current.X + Current.Width;
                    y2 = Current.Y;
                }
                else
                    throw new InvalidOperationException();

                graphics.DrawLine(pen, Current.X, Current.Y, x2, y2);
            }
        }

        private static readonly ILog Log = LogManager.GetLogger(typeof(CaptureForm));

        private static readonly CoreConfiguration Conf = IniConfig.GetIniSection<CoreConfiguration>();


        private static CaptureForm _currentForm;
        private static readonly Brush BackgroundBrush;

        private static readonly HatchStyle BorderHatchStyle = HatchStyle.Percent50;
        private static readonly Color BorderForeColor = Color.White;
        private static readonly Color BorderBackColor = Color.Black;

        private static readonly Color SizeLabelForeColor = Color.White;
        private static readonly Color SizeLabelBackColor = Color.FromArgb(102, Color.Black);
        private const string SizeLabelFontFamily = "Microsoft Sans Serif";
        private const int SizeLabelFontSize = 25;
        private const int SizeLabelMargin = 7;

        private readonly Color? _overlayColor;

        /// <summary>
        /// Initialize the background brush
        /// </summary>
        static CaptureForm()
        {
            var backgroundForTransparency = ScreenLoadResources.Checkerboard_Image;
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

        private Invalidation _horizontalAxle1Invalidation;
        private Invalidation _verticalAxle1Invalidation;

        private string _coordinatesText;
        private Invalidation _coordinatesInvalidation;

        private Invalidation _horizontalAxle2Invalidation;
        private Invalidation _verticalAxle2Invalidation;

        private Invalidation _holeInvalidation;

        private string _sizeLabelText;
        private Invalidation _sizeLabelInvalidation;

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

            // TODO $MarketKernel Быстрое решение: сначала захыватываем маленькие окна.
            //windows = windows.OrderBy(w => w.Size.Width * w.Size.Height).ToList();

            _currentForm = this;

            // Enable the AnimatingForm
            EnableAnimation = true;

            // clean up
            FormClosed += (sender, args) => { _currentForm = null; };

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
            Text = @"ScreenLoad capture form";

            // Make sure we never capture the captureform
            WindowDetails.RegisterIgnoreHandle(Handle);
            // Unregister at close
            FormClosing += (sender, args) => { WindowDetails.UnregisterIgnoreHandle(Handle); };

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

                this.InvokeAction(() =>
                {
                    if (IsDisposed)
                        return;

                    Opacity = 0;
                });
            })
            { IsBackground = true }.Start();
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

        #endregion

        #region mouse handling

        /// <summary>
        /// The mousedown handler of the capture form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                HandleMouseDown();
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

        /// <summary>
        /// The mouse move handler of the capture form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // This method is used to "fix" the mouse coordinates when keeping shift/ctrl pressed
            Point FixMouseCoordinates(Point currentMouse)
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

            // Make sure the mouse coordinates are fixed, when pressing shift
            _mouseMovePos = FixMouseCoordinates(User32.GetCursorLocation());
            _mouseMovePos = WindowCapture.GetLocationRelativeToScreenBounds(_mouseMovePos);
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

        #endregion

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

        protected override void Animate()
        {
            Point lastPos = _cursorPos;
            _cursorPos = _mouseMovePos;

            if (_selectedCaptureWindow != null &&
                lastPos.Equals(_cursorPos) &&
                !IsAnimating(_zoomAnimator) &&
                !IsAnimating(_windowAnimator))
                return;

            WindowDetails lastWindow = _selectedCaptureWindow;

            if (_captureMode == CaptureMode.Region && _mouseDown)
                _captureRect =
                    GuiRectangle.GetGuiRectangle(_cursorPos.X, _cursorPos.Y, _mX - _cursorPos.X, _mY - _cursorPos.Y);

            // Iterate over the found windows and check if the current location is inside a window
            Point cursorPosition = Cursor.Position;
            _selectedCaptureWindow = null;

            lock (_windows)
            {
                foreach (var window in _windows)
                {
                    if (!window.Contains(cursorPosition))
                        continue;

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

            var screenBounds = _capture.ScreenBounds;

            Rectangle holeRectangle;

            if (!_mouseDown)
            {
                if (CaptureMode.Window != _captureMode)
                {
                    if (!IsTerminalServerSession)
                    {
                        _horizontalAxle1Invalidation.Current =
                            new Rectangle(screenBounds.X, _cursorPos.Y, screenBounds.Width, 1);
                        _verticalAxle1Invalidation.Current =
                            new Rectangle(_cursorPos.X, screenBounds.Y, 1, screenBounds.Height);

                        _coordinatesText = $"{_cursorPos.X}x{_cursorPos.Y}";
                        Size coordinatesTextSize;

                        using (var font = new Font(FontFamily.GenericSansSerif, 8))
                        {
                            coordinatesTextSize = TextRenderer.MeasureText(_coordinatesText, font);
                        }

                        _coordinatesInvalidation.Current = new Rectangle(_cursorPos.X + 5, _cursorPos.Y + 5,
                            coordinatesTextSize.Width - 3,
                            coordinatesTextSize.Height);
                    }

                    holeRectangle = Rectangle.Empty;
                }
                else
                {
                    if (_selectedCaptureWindow != null && !_selectedCaptureWindow.Equals(lastWindow))
                        _windowAnimator.ChangeDestination(_captureRect, FramesForMillis(700));

                    if (IsAnimating(_windowAnimator))
                    {
                        _windowAnimator.Next();
                        holeRectangle = _windowAnimator.Current;
                    }
                    else
                        holeRectangle = _windowAnimator.Current;
                }
            }
            else
            {
                _captureRect.Intersect(new Rectangle(Point.Empty,
                    _capture.ScreenBounds.Size)); // crop what is outside the screen
                holeRectangle = _captureRect;
            }

            if (_mouseDown || _captureMode == CaptureMode.Window)
            {
                _horizontalAxle1Invalidation.Current = new Rectangle(screenBounds.X, holeRectangle.Y, screenBounds.Width, 1);
                _verticalAxle1Invalidation.Current = new Rectangle(holeRectangle.X, screenBounds.Y, 1, screenBounds.Height);

                _horizontalAxle2Invalidation.Current = new Rectangle(screenBounds.X, holeRectangle.Y + holeRectangle.Height, screenBounds.Width, 1);
                _verticalAxle2Invalidation.Current = new Rectangle(holeRectangle.X + holeRectangle.Width, screenBounds.Y, 1, screenBounds.Height);

                // Hole
                _holeInvalidation.Current = holeRectangle;

                // Size
                int correction = _captureMode == CaptureMode.Region ? 1 : 0;

                _sizeLabelText = $"{holeRectangle.Width + correction}x{holeRectangle.Height + correction}";
                var textSize = GetSizeLabelSize(_sizeLabelText);
                _sizeLabelInvalidation.Current = GetSizeLabelRectangle(screenBounds, holeRectangle, textSize);
            }

            _horizontalAxle1Invalidation.Invalidate(this);
            _verticalAxle1Invalidation.Invalidate(this);
            _coordinatesInvalidation.Invalidate(this, 1);
            _horizontalAxle2Invalidation.Invalidate(this);
            _verticalAxle2Invalidation.Invalidate(this);
            _holeInvalidation.Invalidate(this);
            _sizeLabelInvalidation.Invalidate(this);

            if (_zoomAnimator != null && (IsAnimating(_zoomAnimator) || _captureMode != CaptureMode.Window))
            {
                // Make sure we invalidate the old zoom area
                var invalidateRectangle = _zoomAnimator.Current;
                invalidateRectangle.Offset(lastPos);
                Invalidate(invalidateRectangle);
                // Only verify if we are really showing the zoom, not the outgoing animation
                if (Conf.ZoomerEnabled && _captureMode != CaptureMode.Window)
                    VerifyZoomAnimation(_cursorPos, false);
                // The following logic is not needed, next always returns the current if there are no frames left
                // but it makes more sense if we want to change something in the logic
                invalidateRectangle = IsAnimating(_zoomAnimator) ? _zoomAnimator.Next() : _zoomAnimator.Current;
                invalidateRectangle.Offset(_cursorPos);
                Invalidate(invalidateRectangle);
            }

            // Force update "now"
            Update();
        }

        /// <summary>
        /// This makes sure there is no background painted, as we have complete "paint" control it doesn't make sense to do otherwise.
        /// </summary>
        /// <param name="prevent"></param>
        protected override void OnPaintBackground(PaintEventArgs prevent)
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

            graphics.DrawImageUnscaled(_capture.Image, Point.Empty);

            // Only draw Cursor if it's (partly) visible
            if (_capture.Cursor != null && _capture.CursorVisible &&
                clipRectangle.IntersectsWith(new Rectangle(_capture.CursorLocation, _capture.Cursor.Size)))
            {
                graphics.DrawIcon(_capture.Cursor, _capture.CursorLocation.X, _capture.CursorLocation.Y);
            }

            if (_mouseDown || _captureMode == CaptureMode.Window)
            {
                if (_overlayColor.HasValue && !_holeInvalidation.IsEmpty)
                    using (var brush = new SolidBrush(_overlayColor.Value))
                    {
                        graphics.FillRectangle(brush, _holeInvalidation.Current);
                    }

                using (var brush = new HatchBrush(BorderHatchStyle, BorderForeColor, BorderBackColor))
                using (var pen = new Pen(brush))
                {
                    _horizontalAxle1Invalidation.DrawLine(graphics, pen);
                    _verticalAxle1Invalidation.DrawLine(graphics, pen);
                    _horizontalAxle2Invalidation.DrawLine(graphics, pen);
                    _verticalAxle2Invalidation.DrawLine(graphics, pen);
                }

                //Рисуем размер
                if (!_sizeLabelInvalidation.IsEmpty)
                    DrawSize(graphics, _sizeLabelInvalidation.Current, _sizeLabelText);
            }
            else
            {
                if (!IsTerminalServerSession)
                {
                    // Оси координат (до нажатия кнопки мыши).

                    using (Brush brush = new HatchBrush(BorderHatchStyle, BorderForeColor, BorderBackColor))
                    using (Pen pen = new Pen(brush))
                    {
                        _horizontalAxle1Invalidation.DrawLine(graphics, pen);
                        _verticalAxle1Invalidation.DrawLine(graphics, pen);
                    }

                    // Координаты
                    using (var font = new Font(FontFamily.GenericSansSerif, 8))
                    {
                        var coordinatesRectangle = _coordinatesInvalidation.Current;

                        using (var graphicsPath = RoundedRectangle.Create2(coordinatesRectangle.X,
                            coordinatesRectangle.Y, coordinatesRectangle.Width, coordinatesRectangle.Height, 3))
                        {
                            using (var brush = new SolidBrush(_overlayColor ?? Color.White))
                            {
                                graphics.FillPath(brush, graphicsPath);
                            }

                            using (var pen = new Pen(Color.Black))
                            {
                                graphics.DrawPath(pen, graphicsPath);

                                var coordinatePosition = new Point(coordinatesRectangle.X, coordinatesRectangle.Y);
                                graphics.DrawString(_coordinatesText, font, pen.Brush, coordinatePosition);
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

                var sourceRectangle = new Rectangle(_cursorPos.X - zoomSourceWidth / 2,
                    _cursorPos.Y - zoomSourceHeight / 2, zoomSourceWidth, zoomSourceHeight);

                var destinationRectangle = _zoomAnimator.Current;
                destinationRectangle.Offset(_cursorPos);
                DrawZoom(graphics, sourceRectangle, destinationRectangle);
            }
        }

        #region Размер выделенной области (надпись в центре)

        public static Size GetSizeLabelSize(string text)
        {
            if (null == text)
                throw new ArgumentNullException(nameof(text));

            Size textSize;

            using (var font = new Font(new FontFamily(SizeLabelFontFamily), SizeLabelFontSize))
            {
                textSize = TextRenderer.MeasureText(text, font);
            }

            textSize.Width++;
            textSize.Height++;

            return textSize;
        }

        // TODO $MarketKernel сделать общей c QuickImageEditorForm.CalculateSizeLabelLocation
        private static Rectangle GetSizeLabelRectangle(Rectangle screenBounds, Rectangle holeRectangle, Size textSize)
        {
            int sizeLabelLeft = holeRectangle.X + 1;
            int sizeLabelTop = holeRectangle.Y - textSize.Height - SizeLabelMargin;

            if (sizeLabelTop < screenBounds.Y)
            {
                sizeLabelLeft = holeRectangle.X + SizeLabelMargin + 1;
                sizeLabelTop = holeRectangle.Y + SizeLabelMargin + 1;
            }

            if (sizeLabelLeft + textSize.Width > screenBounds.Width)
                sizeLabelLeft = holeRectangle.X - textSize.Width - SizeLabelMargin;

            return new Rectangle(sizeLabelLeft, sizeLabelTop, textSize.Width - 2,
                textSize.Height - 2);
        }

        public static void DrawSize(Graphics graphics, Rectangle rectangle, string text, bool applyTransparency = true)
        {
            if (null == graphics)
                throw new ArgumentNullException(nameof(graphics));

            if (null == rectangle)
                throw new ArgumentNullException(nameof(rectangle));

            if (null == text)
                throw new ArgumentNullException(nameof(text));

            var backColor = applyTransparency ? SizeLabelBackColor : Color.FromArgb(255, SizeLabelBackColor);
            var foreColor = applyTransparency ? SizeLabelForeColor : Color.FromArgb(255, SizeLabelForeColor);

            using (var font = new Font(new FontFamily(SizeLabelFontFamily), SizeLabelFontSize))
            {
                using (var backBrush = new SolidBrush(backColor))
                using (var borderPen = new Pen(foreColor, 1))
                using (var foreBrush = new SolidBrush(foreColor))
                {
                    graphics.FillRectangle(backBrush, rectangle);

                    var borderRectangle =
                        new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);

                    graphics.DrawRectangle(borderPen, borderRectangle);
                    graphics.DrawString(text, font, foreBrush, new PointF(rectangle.X + 5, rectangle.Y));
                }
            }
        }

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
