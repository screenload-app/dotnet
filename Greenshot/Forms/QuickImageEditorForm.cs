using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Greenshot.Destinations;
using Greenshot.Drawing;
using Greenshot.Drawing.Fields;
using Greenshot.Helpers;
using Greenshot.IniFile;
using Greenshot.Plugin;
using GreenshotPlugin.Core;

namespace Greenshot
{
    public sealed partial class QuickImageEditorForm : Form
    {
        private enum ToolboxPlacing
        {
            Default,
            BackSide,
            Inside
        }

        private struct HorizontalAndVerticalToolboxLocation
        {
            public Point HorizontalToolboxLocation { get; }
            public Point VerticalToolboxLocation { get; }

            public HorizontalAndVerticalToolboxLocation(Point horizontalToolboxLocation, Point verticalToolboxLocation)
            {
                HorizontalToolboxLocation = horizontalToolboxLocation;
                VerticalToolboxLocation = verticalToolboxLocation;
            }
        }

        private const int ADORNER_HALF_SIZE = 4;

        private readonly Form _surfaceForm;
        private readonly Surface _surface;

        private readonly HorizontalToolboxForm _horizontalToolboxForm = new HorizontalToolboxForm();
        private readonly VerticalToolboxForm _verticalToolboxForm = new VerticalToolboxForm();

        private bool _allowMove;
        private bool _allowResize;

        private int _x;
        private int _y;

        private Point _holeStartLocation;
        private Size _holeStartSize;

        private bool _isMouseInLeftEdge;
        private bool _isMouseInRightEdge;
        private bool _isMouseInTopEdge;
        private bool _isMouseInBottomEdge;

        private QuickImageEditorResult _result;

        public QuickImageEditorForm(Surface surface, Rectangle holeRectangle)
        {
            if (null == surface)
                throw new ArgumentNullException(nameof(surface));

            var surfaceForm = surface.FindForm();

            _surfaceForm = surfaceForm ?? throw new InvalidOperationException("null == surfaceForm");
            _surfaceForm.KeyDown += Form_KeyDown;

            _surface = surface;

            InitializeComponent();

            var coreConfiguration = IniConfig.GetIniSection<CoreConfiguration>();
            BackColor = Color.FromArgb(255, coreConfiguration.CaptureAreaColor);

            holePanel.Location = holeRectangle.Location;
            holePanel.Size = new Size(holeRectangle.Width + ADORNER_HALF_SIZE * 2,
                holeRectangle.Height + ADORNER_HALF_SIZE * 2);
        }

        private void QuickImageEditorForm_Load(object sender, EventArgs e)
        {
            _horizontalToolboxForm.KeyDown += Form_KeyDown;
            _horizontalToolboxForm.ServiceCommand += Toolbox_ServiceCommand;
            _horizontalToolboxForm.Visible = false;
            _horizontalToolboxForm.Show(this);

            _verticalToolboxForm.KeyDown += Form_KeyDown;
            _verticalToolboxForm.ServiceCommand += Toolbox_ServiceCommand;
            _verticalToolboxForm.Visible = false;
            _verticalToolboxForm.Show(this);

            DisplayHoleSize();
            SetAccessoriesLocation();

            holePanel.Visible = true;
            sizeLabel.Visible = true;
            _horizontalToolboxForm.Visible = true;
            _verticalToolboxForm.Visible = true;
        }

        public static QuickImageEditorResult ShowQuickImageEditor(Surface surface, Rectangle holeRectangle)
        {
            if (null == surface)
                throw new ArgumentNullException(nameof(surface));

            var surfaceForm = new SurfaceForm(surface);
            QuickImageEditorForm quickImageEditorForm = null;

            surfaceForm.Load += (sender, args) =>
            {
                surfaceForm.Visible = true;

                quickImageEditorForm = new QuickImageEditorForm(surface, holeRectangle);
                quickImageEditorForm.Show(surfaceForm);
            };

            if (DialogResult.OK != surfaceForm.ShowDialog())
                return new QuickImageEditorResult(QuickImageEditorAction.Cancel);

            return quickImageEditorForm._result;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Escape == e.KeyData)
                _surfaceForm.DialogResult = DialogResult.Cancel;
        }

        private void HolePanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var r = holePanel.ClientRectangle;

            r.Inflate(-ADORNER_HALF_SIZE, -ADORNER_HALF_SIZE);
            ControlPaint.DrawBorder(g, r, Color.Black, ButtonBorderStyle.Dashed);

            var backBrush = new SolidBrush(BackColor);

            g.FillRectangle(backBrush, 0, 0, holePanel.Width - ADORNER_HALF_SIZE, ADORNER_HALF_SIZE);
            g.FillRectangle(backBrush, holePanel.Width - ADORNER_HALF_SIZE, 0, ADORNER_HALF_SIZE,
                holePanel.Height - ADORNER_HALF_SIZE);
            g.FillRectangle(backBrush, ADORNER_HALF_SIZE, holePanel.Height - ADORNER_HALF_SIZE,
                holePanel.Width - ADORNER_HALF_SIZE, ADORNER_HALF_SIZE);
            g.FillRectangle(backBrush, 0, ADORNER_HALF_SIZE, ADORNER_HALF_SIZE, holePanel.Height - ADORNER_HALF_SIZE);

            var adornerRectangles = new List<Rectangle>();

            // top-left
            var adornerRectangle = new Rectangle(r.Left - ADORNER_HALF_SIZE, r.Top - ADORNER_HALF_SIZE,
                ADORNER_HALF_SIZE * 2,
                ADORNER_HALF_SIZE * 2);
            adornerRectangles.Add(adornerRectangle);

            // top
            adornerRectangle.Offset((r.Width - 1) / 2, 0);
            adornerRectangles.Add(adornerRectangle);

            // top-right
            adornerRectangle.Offset(r.Width / 2, 0);
            adornerRectangles.Add(adornerRectangle);

            // right
            adornerRectangle.Offset(0, (r.Height - 1) / 2);
            adornerRectangles.Add(adornerRectangle);

            // bottom-right
            adornerRectangle.Offset(0, r.Height / 2);
            adornerRectangles.Add(adornerRectangle);

            // bottom
            adornerRectangle.Offset(-r.Width / 2, 0);
            adornerRectangles.Add(adornerRectangle);

            // bottom-left
            adornerRectangle.Offset((-r.Width + 1) / 2, 0);
            adornerRectangles.Add(adornerRectangle);

            // left
            adornerRectangle.Offset(0, -r.Height / 2);
            adornerRectangles.Add(adornerRectangle);

            g.FillRectangles(Brushes.White, adornerRectangles.ToArray());
            g.DrawRectangles(Pens.Black, adornerRectangles.ToArray());
        }

        #region Перемещение сквозного окна

        private void QuickImageEditorCoverForm_MouseDown(object sender, MouseEventArgs e)
        {
            _holeStartLocation = holePanel.Location;

            _x = e.X;
            _y = e.Y;

            _allowMove = true;
        }

        private void QuickImageEditorCoverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_allowMove)
                return;

            if (_holeStartLocation.Y + (e.Y - _y) < -ADORNER_HALF_SIZE)
                _y = _holeStartLocation.Y + e.Y + ADORNER_HALF_SIZE;

            if (_holeStartLocation.X + (e.X - _x) < -ADORNER_HALF_SIZE)
                _x = _holeStartLocation.X + e.X + ADORNER_HALF_SIZE;

            if (_holeStartLocation.Y + (e.Y - _y) + holePanel.Height > Height + ADORNER_HALF_SIZE)
                _y = _holeStartLocation.Y + e.Y + holePanel.Height - Height - ADORNER_HALF_SIZE;

            if (_holeStartLocation.X + (e.X - _x) + holePanel.Width > Width + ADORNER_HALF_SIZE)
                _x = _holeStartLocation.X + e.X + holePanel.Width - Width - ADORNER_HALF_SIZE;

            var top = _holeStartLocation.Y + (e.Y - _y);
            var left = _holeStartLocation.X + (e.X - _x);

            holePanel.Top = top;
            holePanel.Left = left;

            SetAccessoriesLocation();

            holePanel.Invalidate();
        }

        private void QuickImageEditorCoverForm_MouseUp(object sender, MouseEventArgs e)
        {
            _allowMove = false;
        }

        #endregion

        #region Изменение размера сквозного окна

        private void HolePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_allowResize)
                return;

            if (!_isMouseInLeftEdge && !_isMouseInRightEdge && !_isMouseInTopEdge && !_isMouseInBottomEdge)
                return;

            _allowResize = true;

            _holeStartSize = holePanel.Size;
            _x = e.X;
            _y = e.Y;

            holePanel.Capture = true;
        }

        private void HolePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_allowResize)
            {
                UpdateMouseEdgeProperties(e.X, e.Y);
                UpdateMouseCursor();

                return;
            }

            var top = holePanel.Top;
            var left = holePanel.Left;
            var width = holePanel.Width;
            var height = holePanel.Height;

            var deltaX = e.X - _x;
            var deltaY = e.Y - _y;

            if (_isMouseInLeftEdge)
            {
                if (_isMouseInTopEdge)
                {
                    top = holePanel.Top + deltaY;
                    left = holePanel.Left + deltaX;
                    width = holePanel.Width - deltaX;
                    height = holePanel.Height - deltaY;
                }
                else if (_isMouseInBottomEdge)
                {
                    left = holePanel.Left + deltaX;
                    width = holePanel.Width - deltaX;
                    height = _holeStartSize.Height + deltaY;
                }
                else
                {
                    left = holePanel.Left + deltaX;
                    width = holePanel.Width - deltaX;
                }
            }
            else if (_isMouseInRightEdge)
            {
                if (_isMouseInTopEdge)
                {
                    top = holePanel.Top + deltaY;
                    width = _holeStartSize.Width + deltaX;
                    height = holePanel.Height - deltaY;
                }
                else if (_isMouseInBottomEdge)
                {
                    width = _holeStartSize.Width + deltaX;
                    height = _holeStartSize.Height + deltaY;
                }
                else
                    width = _holeStartSize.Width + deltaX;
            }
            else if (_isMouseInTopEdge)
            {
                top = holePanel.Top + deltaY;
                height = holePanel.Height - deltaY;
            }
            else if (_isMouseInBottomEdge)
                height = _holeStartSize.Height + deltaY;
            else
            {
                StopDragOrResizing();
                return;
            }

            if (top < -ADORNER_HALF_SIZE)
            {
                height += top + ADORNER_HALF_SIZE;
                top = -ADORNER_HALF_SIZE;
            }

            if (left < -ADORNER_HALF_SIZE)
            {
                width += left + ADORNER_HALF_SIZE;
                left = -ADORNER_HALF_SIZE;
            }

            if (top + height > Height + ADORNER_HALF_SIZE)
            {
                height -= top - (Height + ADORNER_HALF_SIZE - height);
                top = Height + ADORNER_HALF_SIZE - height;
            }

            if (left + width > Width + ADORNER_HALF_SIZE)
            {
                width -= left - (Width + ADORNER_HALF_SIZE - width);
                left = Width + ADORNER_HALF_SIZE - width;
            }

            if (width < ADORNER_HALF_SIZE * 4)
                width = ADORNER_HALF_SIZE * 4;

            if (height < ADORNER_HALF_SIZE * 4)
                height = ADORNER_HALF_SIZE * 4;

            holePanel.Top = top;
            holePanel.Left = left;
            holePanel.Width = width;
            holePanel.Height = height;

            DisplayHoleSize();
            SetAccessoriesLocation();

            holePanel.Invalidate();
        }

        private void HolePanel_MouseUp(object sender, MouseEventArgs e)
        {
            StopDragOrResizing();
        }

        private void UpdateMouseEdgeProperties(int x, int y)
        {
            _isMouseInLeftEdge = x <= ADORNER_HALF_SIZE * 2;
            _isMouseInRightEdge = holePanel.Width - x <= ADORNER_HALF_SIZE * 2;
            _isMouseInTopEdge = y <= ADORNER_HALF_SIZE * 2;
            _isMouseInBottomEdge = holePanel.Height - y <= ADORNER_HALF_SIZE * 2;
        }

        private void UpdateMouseCursor()
        {
            if (_isMouseInLeftEdge)
            {
                if (_isMouseInTopEdge)
                    holePanel.Cursor = Cursors.SizeNWSE;
                else if (_isMouseInBottomEdge)
                    holePanel.Cursor = Cursors.SizeNESW;
                else
                    holePanel.Cursor = Cursors.SizeWE;
            }
            else if (_isMouseInRightEdge)
            {
                if (_isMouseInTopEdge)
                    holePanel.Cursor = Cursors.SizeNESW;
                else if (_isMouseInBottomEdge)
                    holePanel.Cursor = Cursors.SizeNWSE;
                else
                    holePanel.Cursor = Cursors.SizeWE;
            }
            else if (_isMouseInTopEdge || _isMouseInBottomEdge)
                holePanel.Cursor = Cursors.SizeNS;
            else
                holePanel.Cursor = Cursors.Default;
        }

        private void StopDragOrResizing()
        {
            _allowResize = false;
            holePanel.Capture = false;
            UpdateMouseCursor();
        }

        #endregion

        #region Подстройка позиции метки с размерами и панелей инструментов (в зависимости от положения сквозного окна).

        private void SetAccessoriesLocation()
        {
            var sizeLabelLocation = CalculateSizeLabelLocation(holePanel.Location, sizeLabel.Size, Width);

            sizeLabel.Left = sizeLabelLocation.X;
            sizeLabel.Top = sizeLabelLocation.Y;

            var horizontalAndVerticalToolboxLocation = CalculateHorizontalAndVerticalToolboxLocation(
                new Rectangle(holePanel.Left, holePanel.Top, holePanel.Width, holePanel.Height),
                _horizontalToolboxForm.Size, _verticalToolboxForm.Size, Size);

            _horizontalToolboxForm.Left = horizontalAndVerticalToolboxLocation.HorizontalToolboxLocation.X;
            _horizontalToolboxForm.Top = horizontalAndVerticalToolboxLocation.HorizontalToolboxLocation.Y;

            _verticalToolboxForm.Left = horizontalAndVerticalToolboxLocation.VerticalToolboxLocation.X;
            _verticalToolboxForm.Top = horizontalAndVerticalToolboxLocation.VerticalToolboxLocation.Y;
        }

        private static Point CalculateSizeLabelLocation(Point holeLocation, Size sizeLabelSize, int windowWidth)
        {
            var sizeLabelLeft = holeLocation.X + ADORNER_HALF_SIZE;
            var sizeLabelTop = holeLocation.Y - sizeLabelSize.Height;

            if (sizeLabelTop < 0)
            {
                sizeLabelLeft = holeLocation.X + ADORNER_HALF_SIZE * 2 + 1;
                sizeLabelTop = holeLocation.Y + ADORNER_HALF_SIZE * 2 + 1;
            }

            if (sizeLabelLeft + sizeLabelSize.Width > windowWidth)
                sizeLabelLeft = holeLocation.X - sizeLabelSize.Width;

            return new Point(sizeLabelLeft, sizeLabelTop);
        }

        private static HorizontalAndVerticalToolboxLocation CalculateHorizontalAndVerticalToolboxLocation(
            Rectangle holeRectangle, Size horizontalToolboxSize, Size verticalToolboxSize, Size windowSize)
        {
            //Horizontal
            var horizontalToolboxPlacing = ToolboxPlacing.Default;

            if (holeRectangle.Y + holeRectangle.Height + horizontalToolboxSize.Height > windowSize.Height)
            {
                horizontalToolboxPlacing = ToolboxPlacing.BackSide;

                if (holeRectangle.Y < horizontalToolboxSize.Height)
                    horizontalToolboxPlacing = ToolboxPlacing.Inside;
            }

            int horizontalToolboxLeft =
                holeRectangle.X + holeRectangle.Width - horizontalToolboxSize.Width - ADORNER_HALF_SIZE;
            int horizontalToolboxTop;

            switch (horizontalToolboxPlacing)
            {
                case ToolboxPlacing.BackSide:
                    horizontalToolboxTop = holeRectangle.Y - horizontalToolboxSize.Height;
                    break;
                case ToolboxPlacing.Inside:
                    horizontalToolboxLeft = holeRectangle.X + holeRectangle.Width - horizontalToolboxSize.Width -
                                            ADORNER_HALF_SIZE * 3;
                    horizontalToolboxTop = holeRectangle.Y + holeRectangle.Height - horizontalToolboxSize.Height -
                                           ADORNER_HALF_SIZE * 3;
                    break;
                default:
                    horizontalToolboxTop = holeRectangle.Y + holeRectangle.Height;
                    break;
            }

            // Vertical
            var verticalToolboxPlacing = ToolboxPlacing.Default;

            if (holeRectangle.X + holeRectangle.Width + verticalToolboxSize.Width > windowSize.Width)
            {
                verticalToolboxPlacing = ToolboxPlacing.BackSide;

                if (holeRectangle.X < verticalToolboxSize.Width)
                    verticalToolboxPlacing = ToolboxPlacing.Inside;
            }

            int verticalToolboxTop =
                holeRectangle.Y + holeRectangle.Height - verticalToolboxSize.Height - ADORNER_HALF_SIZE;
            int verticalToolboxLeft;

            switch (verticalToolboxPlacing)
            {
                case ToolboxPlacing.BackSide:
                    verticalToolboxLeft = holeRectangle.X - verticalToolboxSize.Width;
                    break;
                case ToolboxPlacing.Inside:
                    verticalToolboxLeft = holeRectangle.X + holeRectangle.Width - verticalToolboxSize.Width -
                                          ADORNER_HALF_SIZE * 3;
                    verticalToolboxTop = holeRectangle.Y + holeRectangle.Height - verticalToolboxSize.Height -
                                         ADORNER_HALF_SIZE * 3;
                    break;
                default:
                    verticalToolboxLeft = holeRectangle.X + holeRectangle.Width;
                    break;
            }

            // Граничные случаи

            if (horizontalToolboxLeft < 0)
                horizontalToolboxLeft = 0;

            if (verticalToolboxTop < 0)
                verticalToolboxTop = 0;

            switch (horizontalToolboxPlacing)
            {
                case ToolboxPlacing.BackSide:
                    switch (verticalToolboxPlacing)
                    {
                        case ToolboxPlacing.BackSide:
                            if (horizontalToolboxTop + horizontalToolboxSize.Height + ADORNER_HALF_SIZE >
                                verticalToolboxTop)
                                horizontalToolboxTop =
                                    verticalToolboxTop - horizontalToolboxSize.Height - ADORNER_HALF_SIZE;

                            if (verticalToolboxLeft + verticalToolboxSize.Width + ADORNER_HALF_SIZE >
                                horizontalToolboxLeft)
                                verticalToolboxLeft =
                                    horizontalToolboxLeft - verticalToolboxSize.Width - ADORNER_HALF_SIZE;
                            break;
                        case ToolboxPlacing.Inside:
                            if (horizontalToolboxTop + horizontalToolboxSize.Height + ADORNER_HALF_SIZE >
                                verticalToolboxTop)
                                horizontalToolboxTop =
                                    verticalToolboxTop - horizontalToolboxSize.Height - ADORNER_HALF_SIZE;
                            break;
                        default:
                            if (horizontalToolboxTop + horizontalToolboxSize.Height + ADORNER_HALF_SIZE >
                                verticalToolboxTop)
                                horizontalToolboxTop =
                                    verticalToolboxTop - horizontalToolboxSize.Height - ADORNER_HALF_SIZE;

                            if (verticalToolboxLeft - ADORNER_HALF_SIZE < horizontalToolboxSize.Width)
                                verticalToolboxLeft = horizontalToolboxSize.Width + ADORNER_HALF_SIZE;
                            break;
                    }

                    break;
                case ToolboxPlacing.Inside:
                    switch (verticalToolboxPlacing)
                    {
                        case ToolboxPlacing.BackSide:
                            if (verticalToolboxLeft + ADORNER_HALF_SIZE >
                                horizontalToolboxLeft - verticalToolboxSize.Width)
                                verticalToolboxLeft =
                                    horizontalToolboxLeft - verticalToolboxSize.Width - ADORNER_HALF_SIZE;
                            break;
                        case ToolboxPlacing.Inside:
                            verticalToolboxTop -= horizontalToolboxSize.Height + ADORNER_HALF_SIZE * 2;
                            break;
                    }

                    break;
                default:
                    switch (verticalToolboxPlacing)
                    {
                        case ToolboxPlacing.BackSide:
                            if (verticalToolboxLeft + verticalToolboxSize.Width + ADORNER_HALF_SIZE >
                                horizontalToolboxLeft)
                                verticalToolboxLeft =
                                    horizontalToolboxLeft - verticalToolboxSize.Width - ADORNER_HALF_SIZE;

                            if (horizontalToolboxTop < verticalToolboxSize.Height + ADORNER_HALF_SIZE)
                                horizontalToolboxTop = verticalToolboxSize.Height + ADORNER_HALF_SIZE;
                            break;
                        case ToolboxPlacing.Inside:
                            if (horizontalToolboxTop <
                                verticalToolboxTop + verticalToolboxSize.Height + ADORNER_HALF_SIZE)
                                horizontalToolboxTop =
                                    verticalToolboxTop + verticalToolboxSize.Height + ADORNER_HALF_SIZE;
                            break;
                        default:
                            if (horizontalToolboxTop < verticalToolboxSize.Height + ADORNER_HALF_SIZE)
                                horizontalToolboxTop = verticalToolboxSize.Height + ADORNER_HALF_SIZE;

                            if (verticalToolboxLeft < horizontalToolboxSize.Width + ADORNER_HALF_SIZE)
                                verticalToolboxLeft = horizontalToolboxSize.Width + ADORNER_HALF_SIZE;
                            break;
                    }

                    break;
            }

            return new HorizontalAndVerticalToolboxLocation(new Point(horizontalToolboxLeft, horizontalToolboxTop),
                new Point(verticalToolboxLeft, verticalToolboxTop));
        }

        #endregion

        private void Toolbox_ServiceCommand(object sender, QuickImageEditorCommandEventArgs e)
        {
            switch (e.Command)
            {
                case QuickImageEditorCommand.Arrow:
                    _surface.DrawingMode = DrawingModes.Arrow;
                    var color = (Color) _surface.FieldAggregator.GetField(FieldType.LINE_COLOR).Value;
                    _horizontalToolboxForm.SetColor(color);
                    break;
                case QuickImageEditorCommand.Pencil:
                    _surface.DrawingMode = DrawingModes.Path;
                    _horizontalToolboxForm.SetColor((Color) _surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Rectangle:
                    _surface.DrawingMode = DrawingModes.Rect;
                    _surface.FieldAggregator.GetField(FieldType.FILL_COLOR).Value = Color.Transparent;
                    _horizontalToolboxForm.SetColor((Color) _surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Text:
                    _surface.DrawingMode = DrawingModes.Text;
                    _surface.FieldAggregator.GetField(FieldType.FILL_COLOR).Value = Color.Transparent;
                    _surface.FieldAggregator.GetField(FieldType.TEXT_HORIZONTAL_ALIGNMENT).Value = StringAlignment.Near;
                    _surface.FieldAggregator.GetField(FieldType.TEXT_VERTICAL_ALIGNMENT).Value = StringAlignment.Near;
                    _horizontalToolboxForm.SetColor((Color) _surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Blur:
                    _surface.DrawingMode = DrawingModes.Obfuscate;
                    break;
                case QuickImageEditorCommand.Counter:
                    _surface.DrawingMode = DrawingModes.StepLabel;
                    _horizontalToolboxForm.SetColor((Color) _surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Color:
                    _surface.FieldAggregator.GetField(FieldType.LINE_COLOR).Value = e.Argument;
                    break;
                case QuickImageEditorCommand.Undo:
                    if (_surface.CanUndo)
                        _surface.Undo();
                    break;
                case QuickImageEditorCommand.Upload:
                {
                    var surface = GetSurfaceForExport();
                    _result = new QuickImageEditorResult(QuickImageEditorAction.DownloadRu, surface);
                    _surfaceForm.DialogResult = DialogResult.OK;
                }
                    break;
                case QuickImageEditorCommand.Copy:
                {
                    using (var surface = GetSurfaceForExport())
                    {
                        DestinationHelper.ExportCapture(true, ClipboardDestination.DESIGNATION, surface,
                            _surface.CaptureDetails);

                        _result = new QuickImageEditorResult(QuickImageEditorAction.None);
                        _surfaceForm.DialogResult = DialogResult.OK;
                    }
                }
                    break;
                case QuickImageEditorCommand.Save:
                {
                    using (var surface = GetSurfaceForExport())
                    {
                        var exportInformation = DestinationHelper.ExportCapture(true,
                            FileWithDialogDestination.DESIGNATION,
                            surface,
                            _surface.CaptureDetails);

                        if (exportInformation.ExportMade)
                        {
                            _result = new QuickImageEditorResult(QuickImageEditorAction.None);
                            _surfaceForm.DialogResult = DialogResult.OK;
                        }
                    }
                }
                    break;
                case QuickImageEditorCommand.More:
                {
                    var surface = GetSurfaceForExport();
                    _result = new QuickImageEditorResult(QuickImageEditorAction.Editor, surface);
                    _surfaceForm.DialogResult = DialogResult.OK;
                }
                    break;
                case QuickImageEditorCommand.Close:
                    _surfaceForm.DialogResult = DialogResult.Cancel;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void DisplayHoleSize()
        {
            sizeLabel.Text = $@"{holePanel.Width - ADORNER_HALF_SIZE * 2}x{holePanel.Height - ADORNER_HALF_SIZE * 2}";
        }

        private Surface GetSurfaceForExport()
        {
            using (var image = _surface.GetImageForExport())
            using (var capture = new Capture(image))
            {
                capture.CaptureDetails = new CaptureDetails {Title = _surface.CaptureDetails.Title};
                capture.Crop(new Rectangle(holePanel.Left, holePanel.Top, holePanel.Width, holePanel.Height));
                var surface = new Surface(capture);

                return surface;
            }
        }
    }
}