using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Greenshot.Destinations;
using Greenshot.Drawing;
using Greenshot.Drawing.Fields;
using Greenshot.Helpers;
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

        private struct ToolboxesLocation
        {
            public Point HorizontalToolboxLocation { get; }
            public Point VerticalToolboxLocation { get; }

            public ToolboxesLocation(Point horizontalToolboxLocation, Point verticalToolboxLocation)
            {
                HorizontalToolboxLocation = horizontalToolboxLocation;
                VerticalToolboxLocation = verticalToolboxLocation;
            }
        }

        public const string ConfirmationDialogName = "QuickImageEditorConfirmation";

        private readonly Form _surfaceForm;
        private readonly Surface _surface;

        private readonly CoreConfiguration _coreConfiguration;

        private static readonly HatchStyle OverlayHatchStyle = HatchStyle.Percent50;
        private static readonly Color OverlayForeColor = Color.White;
        private static readonly Color OverlayBackColor = Color.Black;

        private static readonly Brush AdornerBackBrush = Brushes.White;
        private static readonly Pen AdornerBorderPen = Pens.Black;

        private readonly int _adornerHalfSize;

        private HorizontalToolboxForm _horizontalToolboxForm;
        private VerticalToolboxForm _verticalToolboxForm;

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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        private QuickImageEditorForm(SurfaceForm surfaceForm, Rectangle holeRectangle)
        {
            _surfaceForm = surfaceForm;
            _surfaceForm.KeyDown += Form_KeyDown;

            _surface = surfaceForm.Surface;

            InitializeComponent();

            _adornerHalfSize = holePanel.Padding.Top;

            SuspendLayout();
            Bounds = surfaceForm.Bounds;
            ResumeLayout(true);

            _coreConfiguration = MainForm.Instance.CoreConfiguration;

            if (_coreConfiguration.IsCaptureAreaColorUsed)
                BackColor = Color.FromArgb(255, _coreConfiguration.CaptureAreaColor);
            else
                Paint += QuickImageEditorForm_Paint;

            var holePanelLocation = new Point(holeRectangle.X - _adornerHalfSize, holeRectangle.Y - _adornerHalfSize);
            var holePanelSize = new Size(holeRectangle.Width + _adornerHalfSize * 2,
                holeRectangle.Height + _adornerHalfSize * 2);

            holePanel.Location = holePanelLocation;
            holePanel.Size = holePanelSize;

            sizeLabel.Paint += (sender, args) =>
            {
                args.Graphics.Clear(Color.Black);
                CaptureForm.DrawSize(args.Graphics, args.ClipRectangle, sizeLabel.Text, false);
            };
        }

        private void QuickImageEditorForm_Load(object sender, EventArgs e)
        {
            DisplayHoleSize();
            SetSizeLabelLocation();
            sizeLabel.Visible = true;

            _horizontalToolboxForm = new HorizontalToolboxForm();
            _horizontalToolboxForm.KeyDown += Form_KeyDown;
            _horizontalToolboxForm.ServiceCommand += Toolbox_ServiceCommand;

            _verticalToolboxForm = new VerticalToolboxForm();
            _verticalToolboxForm.KeyDown += Form_KeyDown;
            _verticalToolboxForm.ServiceCommand += Toolbox_ServiceCommand;

            SetToolboxesLocation();

            _horizontalToolboxForm.Show(this);
            _verticalToolboxForm.Show(this);

            _surface.CanUndoChanged += (s, args) => { _horizontalToolboxForm.SetCanUndo(_surface.CanUndo); };
        }

        public static QuickImageEditorResult ShowQuickImageEditor(ICapture capture, Rectangle holeRectangle, Form ownerForm = null)
        {
            if (null == capture)
                throw new ArgumentNullException(nameof(capture));

            var surfaceForm = new SurfaceForm(capture);

            MainForm.Instance.SetSurfaceForm(surfaceForm);
            DialogManager.SetTopForm(surfaceForm);

            QuickImageEditorForm quickImageEditorForm = null;

            surfaceForm.Load += (sender, args) =>
            {
                quickImageEditorForm = new QuickImageEditorForm(surfaceForm, holeRectangle);
                quickImageEditorForm.Show(surfaceForm);
            };

            surfaceForm.Shown += (sender, args) =>
            {
                var captureForm = ownerForm as CaptureForm;
                captureForm?.MakeInvisibleWithDelay();
            };

            var dialogResult = surfaceForm.ShowDialog(ownerForm ?? MainForm.Instance);

            MainForm.Instance.ResetSurfaceForm();
            DialogManager.ResetTopForm();

            if (DialogResult.OK != dialogResult)
                return QuickImageEditorResult.NoAction;

            return quickImageEditorForm._result;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    _surface.RemoveSelectedElements();
                    break;
                case Keys.Escape:
                    Cancel();
                    break;
                default:
                    if (e.Control)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.D:
                                UploadCapture();
                                break;
                            case Keys.C:
                                CopyCapture();
                                break;
                            case Keys.S:
                                SaveCapture();
                                break;
                            case Keys.E:
                                SendToExtendedEditor();
                                break;
                            case Keys.Z:
                                if (_surface.CanUndo)
                                    _surface.Undo();
                                break;
                        }
                    }

                    break;
            }
        }

        private void HolePanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var r = holePanel.ClientRectangle;

            int side = _adornerHalfSize * 2;

            var leftX = r.Left;
            var middleX = (r.Left + r.Width - 1) / 2 - side / 2;
            var rightX = r.Left + r.Width - side;

            var topY = r.Top;
            var middleY = (r.Top + r.Height - 1) / 2 - side / 2;
            var bottomY = r.Top + r.Height - side;

            var adornerRectangles = new List<Rectangle>
            {
                new Rectangle(leftX, topY, side, side), // top-left
                new Rectangle(middleX, topY, side, side), // top
                new Rectangle(rightX, topY, side, side), // top-right
                new Rectangle(rightX, middleY, side, side), // right
                new Rectangle(rightX, bottomY, side, side), // bottom-right
                new Rectangle(middleX, bottomY, side, side), // bottom
                new Rectangle(leftX, bottomY, side, side), // bottom-left
                new Rectangle(leftX, middleY, side, side) // left
            };

            var adornerBorderRectangles =
                adornerRectangles.Select(ar => new Rectangle(ar.X, ar.Y, ar.Width - 1, ar.Height - 1));

            g.FillRectangles(AdornerBackBrush, adornerRectangles.ToArray());
            g.DrawRectangles(AdornerBorderPen, adornerBorderRectangles.ToArray());
        }

        private void InnerPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var r = innerPanel.ClientRectangle;

            var borderRectangle = new Rectangle(r.Left, r.Top, r.Left + r.Width - 1, r.Top + r.Height - 1); // border

            using (Brush brush = new HatchBrush(OverlayHatchStyle, OverlayForeColor, OverlayBackColor))
            using (var pen = new Pen(brush))
            {
                g.DrawRectangle(pen, borderRectangle);
            }

            int largeSide = _adornerHalfSize * 2;
            int smallSide = _adornerHalfSize;

            var leftX = r.Left;
            var middleX = (r.Left + r.Width - 1) / 2 - largeSide / 2;
            var rightX = r.Left + r.Width - smallSide;

            var topY = r.Top;
            var middleY = (r.Top + r.Height - 1) / 2 - largeSide / 2;
            var bottomY = r.Top + r.Height - smallSide;

            var adornerRectangles = new List<Rectangle>
            {
                new Rectangle(leftX, topY, smallSide, smallSide), // top-left
                new Rectangle(middleX, topY, largeSide, smallSide), // top
                new Rectangle(rightX, topY, smallSide, smallSide), // top-right
                new Rectangle(rightX, middleY, smallSide, largeSide), // right
                new Rectangle(rightX, bottomY, smallSide, smallSide), // bottom-right
                new Rectangle(middleX, bottomY, largeSide, smallSide), // bottom
                new Rectangle(leftX, bottomY, smallSide, smallSide), // bottom-left
                new Rectangle(leftX, middleY, smallSide, largeSide) // left
            };

            g.FillRectangles(AdornerBackBrush, adornerRectangles.ToArray());

            var largeBorderSide = largeSide - 1;
            var smallBorderSide = smallSide - 1;

            // top-left
            g.DrawLines(AdornerBorderPen,
                new[]
                {
                    new Point(leftX, topY + smallBorderSide),
                    new Point(leftX + smallBorderSide, topY + smallBorderSide),
                    new Point(leftX + smallBorderSide, topY)
                });

            // top
            g.DrawLines(AdornerBorderPen,
                new[]
                {
                    new Point(middleX, topY), new Point(middleX, topY + smallBorderSide),
                    new Point(middleX + largeBorderSide, topY + smallBorderSide),
                    new Point(middleX + largeBorderSide, topY)
                });

            // top-right
            g.DrawLines(AdornerBorderPen,
                new[]
                {
                    new Point(rightX, topY), new Point(rightX, topY + smallBorderSide),
                    new Point(rightX + smallBorderSide, topY + smallBorderSide)
                });

            // right
            g.DrawLines(AdornerBorderPen,
                new[]
                {
                    new Point(rightX + smallBorderSide, middleY), new Point(rightX, middleY),
                    new Point(rightX, middleY + largeBorderSide),
                    new Point(rightX + largeBorderSide, middleY + largeBorderSide)
                });

            // bottom-right
            g.DrawLines(AdornerBorderPen,
                new[]
                {
                    new Point(rightX + smallBorderSide, bottomY), new Point(rightX, bottomY),
                    new Point(rightX, bottomY + smallBorderSide)
                });

            // bottom
            g.DrawLines(AdornerBorderPen,
                new[]
                {
                    new Point(middleX, bottomY + smallBorderSide), new Point(middleX, bottomY),
                    new Point(middleX + largeBorderSide, bottomY),
                    new Point(middleX + largeBorderSide, bottomY + smallBorderSide)
                });

            // bottom-left
            g.DrawLines(AdornerBorderPen,
                new[]
                {
                    new Point(leftX, bottomY), new Point(leftX + smallBorderSide, bottomY),
                    new Point(leftX + smallBorderSide, bottomY + smallBorderSide)
                });

            // left
            g.DrawLines(AdornerBorderPen,
                new[]
                {
                    new Point(leftX, middleY), new Point(leftX + smallBorderSide, middleY),
                    new Point(leftX + smallBorderSide, middleY + largeBorderSide),
                    new Point(leftX, middleY + largeBorderSide)
                });
        }

        #region Перемещение сквозного окна

        private void QuickImageEditorCoverForm_MouseDown(object sender, MouseEventArgs e)
        {
            _holeStartLocation = holePanel.Location;

            _x = e.X;
            _y = e.Y;

            _horizontalToolboxForm.Visible = false;
            _verticalToolboxForm.Visible = false;

            _allowMove = true;
        }

        private void QuickImageEditorCoverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_allowMove)
                return;

            if (_holeStartLocation.Y + (e.Y - _y) < -_adornerHalfSize)
                _y = _holeStartLocation.Y + e.Y + _adornerHalfSize;

            if (_holeStartLocation.X + (e.X - _x) < -_adornerHalfSize)
                _x = _holeStartLocation.X + e.X + _adornerHalfSize;

            if (_holeStartLocation.Y + (e.Y - _y) + holePanel.Height > Height + _adornerHalfSize)
                _y = _holeStartLocation.Y + e.Y + holePanel.Height - Height - _adornerHalfSize;

            if (_holeStartLocation.X + (e.X - _x) + holePanel.Width > Width + _adornerHalfSize)
                _x = _holeStartLocation.X + e.X + holePanel.Width - Width - _adornerHalfSize;

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

            _horizontalToolboxForm.Visible = true;
            _verticalToolboxForm.Visible = true;
        }

        #endregion

        #region Изменение размера сквозного окна

        private void HolePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_allowResize)
                return;

            if (!_isMouseInLeftEdge && !_isMouseInRightEdge && !_isMouseInTopEdge && !_isMouseInBottomEdge)
                return;

            _holeStartSize = holePanel.Size;

            _x = e.X;
            _y = e.Y;

            if (sender == innerPanel)
            {
                _x += _adornerHalfSize;
                _y += _adornerHalfSize;
            }

            holePanel.Capture = true;

            _horizontalToolboxForm.Visible = false;
            _verticalToolboxForm.Visible = false;

            _allowResize = true;
        }

        private void HolePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_allowResize)
            {
                UpdateMouseEdgeProperties(sender, e.X, e.Y);
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

            if (top < -_adornerHalfSize)
            {
                height += top + _adornerHalfSize;
                top = -_adornerHalfSize;
            }

            if (left < -_adornerHalfSize)
            {
                width += left + _adornerHalfSize;
                left = -_adornerHalfSize;
            }

            if (top + height > Height + _adornerHalfSize)
            {
                height -= top - (Height + _adornerHalfSize - height);
                top = Height + _adornerHalfSize - height;
            }

            if (left + width > Width + _adornerHalfSize)
            {
                width -= left - (Width + _adornerHalfSize - width);
                left = Width + _adornerHalfSize - width;
            }

            if (width < _adornerHalfSize * 4)
                width = _adornerHalfSize * 4;

            if (height < _adornerHalfSize * 4)
                height = _adornerHalfSize * 4;

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

        private void UpdateMouseEdgeProperties(object sender, int x, int y)
        {
            var panel = (Panel)sender;

            _isMouseInLeftEdge = x <= _adornerHalfSize * 2;
            _isMouseInRightEdge = panel.Width - x <= _adornerHalfSize * 2;
            _isMouseInTopEdge = y <= _adornerHalfSize * 2;
            _isMouseInBottomEdge = panel.Height - y <= _adornerHalfSize * 2;
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

            _horizontalToolboxForm.Visible = true;
            _verticalToolboxForm.Visible = true;

            UpdateMouseCursor();
        }

        private void DisplayHoleSize()
        {
            var text = $@"{holePanel.Width - _adornerHalfSize * 2}x{holePanel.Height - _adornerHalfSize * 2}";
            var size = CaptureForm.GetSizeLabelSize(text);

            size = new Size(size.Width, size.Height);

            sizeLabel.Size = size;
            sizeLabel.Text = text;
        }

        #endregion

        #region Подстройка позиции метки с размерами и панелей инструментов (в зависимости от положения сквозного окна).

        private void SetAccessoriesLocation()
        {
            SetSizeLabelLocation();
            SetToolboxesLocation();
        }

        private void SetSizeLabelLocation()
        {
            var sizeLabelLocation = CalculateSizeLabelLocation(holePanel.Location, sizeLabel.Size, Width);

            sizeLabel.Left = sizeLabelLocation.X;
            sizeLabel.Top = sizeLabelLocation.Y;

            sizeLabel.Invalidate();
        }

        private void SetToolboxesLocation()
        {
            var toolboxesLocation = CalculateToolboxesLocation(
                new Rectangle(holePanel.Left, holePanel.Top, holePanel.Width, holePanel.Height),
                _horizontalToolboxForm.Size, _verticalToolboxForm.Size, Bounds);

            _horizontalToolboxForm.SuspendLayout();
            _horizontalToolboxForm.Left = toolboxesLocation.HorizontalToolboxLocation.X;
            _horizontalToolboxForm.Top = toolboxesLocation.HorizontalToolboxLocation.Y;
            _horizontalToolboxForm.ResumeLayout(true);

            _verticalToolboxForm.SuspendLayout();
            _verticalToolboxForm.Left = toolboxesLocation.VerticalToolboxLocation.X;
            _verticalToolboxForm.Top = toolboxesLocation.VerticalToolboxLocation.Y;
            _verticalToolboxForm.ResumeLayout(true);
        }

        private Point CalculateSizeLabelLocation(Point holeLocation, Size sizeLabelSize, int windowWidth)
        {
            var sizeLabelLeft = holeLocation.X + _adornerHalfSize;
            var sizeLabelTop = holeLocation.Y - sizeLabelSize.Height;

            if (sizeLabelTop < 0)
            {
                sizeLabelLeft = holeLocation.X + _adornerHalfSize * 2 + 1;
                sizeLabelTop = holeLocation.Y + _adornerHalfSize * 2 + 1;
            }

            if (sizeLabelLeft + sizeLabelSize.Width > windowWidth)
                sizeLabelLeft = holeLocation.X - sizeLabelSize.Width;

            return new Point(sizeLabelLeft, sizeLabelTop);
        }

        private ToolboxesLocation CalculateToolboxesLocation(
            Rectangle holeRectangle, Size horizontalToolboxSize, Size verticalToolboxSize, Rectangle windowRectangle)
        {
            //Horizontal
            var horizontalToolboxPlacing = ToolboxPlacing.Default;

            if (holeRectangle.Y + holeRectangle.Height + horizontalToolboxSize.Height > windowRectangle.Height)
            {
                horizontalToolboxPlacing = ToolboxPlacing.BackSide;

                if (holeRectangle.Y < horizontalToolboxSize.Height)
                    horizontalToolboxPlacing = ToolboxPlacing.Inside;
            }

            int horizontalToolboxLeft =
                holeRectangle.X + holeRectangle.Width - horizontalToolboxSize.Width - _adornerHalfSize;
            int horizontalToolboxTop;

            switch (horizontalToolboxPlacing)
            {
                case ToolboxPlacing.BackSide:
                    horizontalToolboxTop = holeRectangle.Y - horizontalToolboxSize.Height;
                    break;
                case ToolboxPlacing.Inside:
                    horizontalToolboxLeft = holeRectangle.X + holeRectangle.Width - horizontalToolboxSize.Width -
                                            _adornerHalfSize * 3;
                    horizontalToolboxTop = holeRectangle.Y + holeRectangle.Height - horizontalToolboxSize.Height -
                                           _adornerHalfSize * 3;
                    break;
                default:
                    horizontalToolboxTop = holeRectangle.Y + holeRectangle.Height;
                    break;
            }

            // Vertical
            var verticalToolboxPlacing = ToolboxPlacing.Default;

            if (holeRectangle.X + holeRectangle.Width + verticalToolboxSize.Width > windowRectangle.Width)
            {
                verticalToolboxPlacing = ToolboxPlacing.BackSide;

                if (holeRectangle.X < verticalToolboxSize.Width)
                    verticalToolboxPlacing = ToolboxPlacing.Inside;
            }

            int verticalToolboxTop =
                holeRectangle.Y + holeRectangle.Height - verticalToolboxSize.Height - _adornerHalfSize;
            int verticalToolboxLeft;

            switch (verticalToolboxPlacing)
            {
                case ToolboxPlacing.BackSide:
                    verticalToolboxLeft = holeRectangle.X - verticalToolboxSize.Width;
                    break;
                case ToolboxPlacing.Inside:
                    verticalToolboxLeft = holeRectangle.X + holeRectangle.Width - verticalToolboxSize.Width -
                                          _adornerHalfSize * 3;
                    verticalToolboxTop = holeRectangle.Y + holeRectangle.Height - verticalToolboxSize.Height -
                                         _adornerHalfSize * 3;
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
                            if (horizontalToolboxTop + horizontalToolboxSize.Height + _adornerHalfSize >
                                verticalToolboxTop)
                                horizontalToolboxTop =
                                    verticalToolboxTop - horizontalToolboxSize.Height - _adornerHalfSize;

                            if (verticalToolboxLeft + verticalToolboxSize.Width + _adornerHalfSize >
                                horizontalToolboxLeft)
                                verticalToolboxLeft =
                                    horizontalToolboxLeft - verticalToolboxSize.Width - _adornerHalfSize;
                            break;
                        case ToolboxPlacing.Inside:
                            if (horizontalToolboxTop + horizontalToolboxSize.Height + _adornerHalfSize >
                                verticalToolboxTop)
                                horizontalToolboxTop =
                                    verticalToolboxTop - horizontalToolboxSize.Height - _adornerHalfSize;
                            break;
                        default:
                            if (horizontalToolboxTop + horizontalToolboxSize.Height + _adornerHalfSize >
                                verticalToolboxTop)
                                horizontalToolboxTop =
                                    verticalToolboxTop - horizontalToolboxSize.Height - _adornerHalfSize;

                            if (verticalToolboxLeft - _adornerHalfSize < horizontalToolboxSize.Width)
                                verticalToolboxLeft = horizontalToolboxSize.Width + _adornerHalfSize;
                            break;
                    }

                    break;
                case ToolboxPlacing.Inside:
                    switch (verticalToolboxPlacing)
                    {
                        case ToolboxPlacing.BackSide:
                            if (verticalToolboxLeft + _adornerHalfSize >
                                horizontalToolboxLeft - verticalToolboxSize.Width)
                                verticalToolboxLeft =
                                    horizontalToolboxLeft - verticalToolboxSize.Width - _adornerHalfSize;
                            break;
                        case ToolboxPlacing.Inside:
                            verticalToolboxTop -= horizontalToolboxSize.Height + _adornerHalfSize;
                            break;
                    }

                    break;
                default:
                    switch (verticalToolboxPlacing)
                    {
                        case ToolboxPlacing.BackSide:
                            if (verticalToolboxLeft + verticalToolboxSize.Width + _adornerHalfSize >
                                horizontalToolboxLeft)
                                verticalToolboxLeft =
                                    horizontalToolboxLeft - verticalToolboxSize.Width - _adornerHalfSize;

                            if (horizontalToolboxTop < verticalToolboxSize.Height + _adornerHalfSize)
                                horizontalToolboxTop = verticalToolboxSize.Height + _adornerHalfSize;
                            break;
                        case ToolboxPlacing.Inside:
                            if (horizontalToolboxTop <
                                verticalToolboxTop + verticalToolboxSize.Height + _adornerHalfSize)
                                horizontalToolboxTop =
                                    verticalToolboxTop + verticalToolboxSize.Height + _adornerHalfSize;
                            break;
                        default:
                            if (horizontalToolboxTop < verticalToolboxSize.Height + _adornerHalfSize)
                                horizontalToolboxTop = verticalToolboxSize.Height + _adornerHalfSize;

                            if (verticalToolboxLeft < horizontalToolboxSize.Width + _adornerHalfSize)
                                verticalToolboxLeft = horizontalToolboxSize.Width + _adornerHalfSize;
                            break;
                    }

                    break;
            }

            // Корректировка: размеры были по отношению к окну, а нужно по отношению к экрану
            horizontalToolboxLeft += windowRectangle.X;
            horizontalToolboxTop += windowRectangle.Y;

            verticalToolboxLeft += windowRectangle.X;
            verticalToolboxTop += windowRectangle.Y;

            // Если не видно через физ. монитор - то отображаем в правом нижнем углу главного монитора.
            if (!IsToolboxesOnScreen(
                new Rectangle(horizontalToolboxLeft, horizontalToolboxTop, horizontalToolboxSize.Width,
                    horizontalToolboxSize.Height),
                new Rectangle(verticalToolboxLeft, verticalToolboxTop, verticalToolboxSize.Width,
                    verticalToolboxSize.Height)))
            {
                var primaryScreenBounds = Screen.PrimaryScreen.Bounds;

                horizontalToolboxLeft =
                    primaryScreenBounds.Width - primaryScreenBounds.X - horizontalToolboxSize.Width;
                horizontalToolboxTop =
                    primaryScreenBounds.Height - primaryScreenBounds.Y - horizontalToolboxSize.Height;

                verticalToolboxLeft =
                    primaryScreenBounds.Width - primaryScreenBounds.X - verticalToolboxSize.Width;
                verticalToolboxTop =
                    primaryScreenBounds.Height - primaryScreenBounds.Y - verticalToolboxSize.Height -
                    horizontalToolboxSize.Height - _adornerHalfSize;
            }

            return new ToolboxesLocation(new Point(horizontalToolboxLeft, horizontalToolboxTop),
                new Point(verticalToolboxLeft, verticalToolboxTop));
        }

        private static bool IsToolboxesOnScreen(Rectangle horizontalToolboxRectangle, Rectangle verticalToolboxRectangle)
        {
            bool isHorizontalToolboxOnScreen = false;
            bool isVerticalToolboxOnScreen = false;

            foreach (var screen in Screen.AllScreens)
            {
                if (!isHorizontalToolboxOnScreen)
                {
                    if (screen.Bounds.Contains(horizontalToolboxRectangle))
                        isHorizontalToolboxOnScreen = true;
                }

                if (!isVerticalToolboxOnScreen)
                {
                    if (screen.Bounds.Contains(verticalToolboxRectangle))
                        isVerticalToolboxOnScreen = true;
                }
            }

            return isHorizontalToolboxOnScreen && isVerticalToolboxOnScreen;
        }

        #endregion

        #region Команды

        private void Toolbox_ServiceCommand(object sender, QuickImageEditorCommandEventArgs e)
        {
            switch (e.Command)
            {
                case QuickImageEditorCommand.Select:
                    _surface.DrawingMode = DrawingModes.None;
                    break;
                case QuickImageEditorCommand.Arrow:
                    _surface.DrawingMode = DrawingModes.Arrow;
                    _horizontalToolboxForm.SetColor((Color)_surface.FieldAggregator.GetField(FieldType.LINE_COLOR).Value);
                    break;
                case QuickImageEditorCommand.Pencil:
                    _surface.DrawingMode = DrawingModes.Path;
                    _horizontalToolboxForm.SetColor((Color)_surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Line:
                    _surface.DrawingMode = DrawingModes.Line;
                    _horizontalToolboxForm.SetColor((Color)_surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Rectangle:
                    _surface.DrawingMode = DrawingModes.Rect;
                    _surface.FieldAggregator.GetField(FieldType.FILL_COLOR).Value = Color.Transparent;
                    _horizontalToolboxForm.SetColor((Color)_surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Ellipse:
                    _surface.DrawingMode = DrawingModes.Ellipse;
                    _surface.FieldAggregator.GetField(FieldType.FILL_COLOR).Value = Color.Transparent;
                    _horizontalToolboxForm.SetColor((Color)_surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Text:
                    _surface.DrawingMode = DrawingModes.Text;
                    _surface.FieldAggregator.GetField(FieldType.FILL_COLOR).Value = Color.Transparent;
                    _surface.FieldAggregator.GetField(FieldType.TEXT_HORIZONTAL_ALIGNMENT).Value = StringAlignment.Near;
                    _surface.FieldAggregator.GetField(FieldType.TEXT_VERTICAL_ALIGNMENT).Value = StringAlignment.Near;
                    _surface.FieldAggregator.GetField(FieldType.LINE_THICKNESS).Value = 0;
                    _horizontalToolboxForm.SetColor((Color)_surface.FieldAggregator.GetField(FieldType.LINE_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Blur:
                    _surface.DrawingMode = DrawingModes.Obfuscate;
                    break;
                case QuickImageEditorCommand.Counter:
                    _surface.DrawingMode = DrawingModes.StepLabel;
                    _horizontalToolboxForm.SetColor((Color)_surface.FieldAggregator.GetField(FieldType.FILL_COLOR)
                        .Value);
                    break;
                case QuickImageEditorCommand.Color:
                    if (DrawingModes.StepLabel == _surface.DrawingMode)
                    {
                        var color = (Color)e.Argument;
                        _surface.FieldAggregator.GetField(FieldType.LINE_COLOR).Value =
                            ColorUtility.CalculateContrastColor(color);
                        _surface.FieldAggregator.GetField(FieldType.FILL_COLOR).Value = color;
                    }
                    else
                        _surface.FieldAggregator.GetField(FieldType.LINE_COLOR).Value = e.Argument;
                    break;
                case QuickImageEditorCommand.Undo:
                    if (_surface.CanUndo)
                        _surface.Undo();
                    break;
                case QuickImageEditorCommand.Upload:
                    UploadCapture();
                    break;
                case QuickImageEditorCommand.Copy:
                    CopyCapture();
                    break;
                case QuickImageEditorCommand.Save:
                    SaveCapture();
                    break;
                case QuickImageEditorCommand.More:
                    SendToExtendedEditor();
                    break;
                case QuickImageEditorCommand.Close:
                    Cancel();
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void UploadCapture()
        {
            _result = BuildResult(QuickImageEditorAction.DownloadRu);
            _surfaceForm.DialogResult = DialogResult.OK;
        }

        private void CopyCapture()
        {
            _result = BuildResult(QuickImageEditorAction.Copy);
            _surfaceForm.DialogResult = DialogResult.OK;
        }

        private void SaveCapture()
        {
            var captureForExport = new Capture(_surface.GetImageForExport());
            captureForExport.Crop(GetActiveRectangle());

            var surfaceForExport = new Surface(captureForExport)
            {
                CaptureDetails = _surface.CaptureDetails
            };

            if (_coreConfiguration.ShowTrayNotification && !_coreConfiguration.HideTrayicon)
                surfaceForExport.SurfaceMessage += CaptureHelper.SurfaceMessageReceived;

            var destination = DestinationHelper.GetDestination(FileWithDialogDestination.DESIGNATION);
            var exportInformation = destination?.ExportCapture(false, surfaceForExport, _surface.CaptureDetails);

            if (null != exportInformation && !exportInformation.ExportMade)
                return;

            _result = QuickImageEditorResult.NoAction;
            _surfaceForm.DialogResult = DialogResult.OK;
        }

        private void SendToExtendedEditor()
        {
            _result = BuildResult(QuickImageEditorAction.Editor);
            _surfaceForm.DialogResult = DialogResult.OK;
        }

        private void Cancel()
        {
            if (_surface.Modified && DialogResult.Yes != DialogHelper.ShowYesNoDialogWithCheckbox(_verticalToolboxForm,
                    ConfirmationDialogName, Language.GetString("QuickImageEditorForm_Leave_Confirmation_Text"),
                    Language.GetString("QuickImageEditorForm_Leave_Confirmation_Title")))
                return;

            _result = QuickImageEditorResult.NoAction;
            _surfaceForm.DialogResult = DialogResult.Cancel;
        }

        private QuickImageEditorResult BuildResult(QuickImageEditorAction action)
        {
            if (QuickImageEditorAction.None == action)
                return QuickImageEditorResult.NoAction;

            var image = _surface.GetImageForExport();
            var rectangle = GetActiveRectangle();

            return new QuickImageEditorResult(action, image, rectangle);
        }

        private Rectangle GetActiveRectangle()
        {
            return new Rectangle(holePanel.Left + _adornerHalfSize, holePanel.Top + _adornerHalfSize,
                holePanel.Width - _adornerHalfSize * 2,
                holePanel.Height - _adornerHalfSize * 2);
        }

        #endregion

        private void QuickImageEditorForm_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new HatchBrush(OverlayHatchStyle, OverlayForeColor, OverlayBackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }
    }
}