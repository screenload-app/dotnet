using System;
using System.Drawing;
using System.Windows.Forms;
using ScreenLoad.Helpers;
using ScreenLoadPlugin.Core;

namespace ScreenLoad
{
    public sealed partial class HorizontalToolboxForm : Form
    {
        private const int WM_LBUTTONDBLCLK = 0x00A3;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private const string WhiteImageKey = "White";
        private const string BlackImageKey = "Black";

        private readonly QuickImageEditorTool _lastUsedTool;

        private Form _parentForm;
        private ToolboxShapesForm _shapesForm;
        private ToolboxShape _currentShape = ToolboxShape.Rectangle;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams createParams = base.CreateParams;
        //        createParams.ExStyle |= 0x02000000;
        //        return createParams;
        //    }
        //}

        public event EventHandler<QuickImageEditorCommandEventArgs> ServiceCommand;

        public HorizontalToolboxForm(QuickImageEditorTool lastUsedTool)
        {
            InitializeComponent();
            _lastUsedTool = lastUsedTool;

            //shapesButton.Paint += (sender, args) =>
            //    {
            //        args.Graphics.DrawLine(Pens.Gray, args.ClipRectangle.X + args.ClipRectangle.Width - 1,
            //            args.ClipRectangle.Y + 6, args.ClipRectangle.X + args.ClipRectangle.Width - 1,
            //            args.ClipRectangle.Y + args.ClipRectangle.Height - 6);
            //    };

            //SuspendLayout();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer |
            //         ControlStyles.OptimizedDoubleBuffer, true);
            //ResumeLayout(true);
        }

        private void HorizontalToolboxForm_Load(object sender, EventArgs e)
        {
            toolTip.SetToolTip(selectButton, Language.GetString("QuickImageEditor_Select"));
            toolTip.SetToolTip(arrowButton, Language.GetString("QuickImageEditor_Arrow"));
            toolTip.SetToolTip(pencilButton, Language.GetString("QuickImageEditor_Pencil"));
            toolTip.SetToolTip(markerButton, Language.GetString("QuickImageEditor_Marker"));
            toolTip.SetToolTip(shapesButton, Language.GetString("QuickImageEditor_Rectangle"));
            toolTip.SetToolTip(textButton, Language.GetString("QuickImageEditor_Text"));
            toolTip.SetToolTip(blurButton, Language.GetString("QuickImageEditor_Blur"));
            toolTip.SetToolTip(counterButton, Language.GetString("QuickImageEditor_Counter"));
            toolTip.SetToolTip(colorButton, Language.GetString("QuickImageEditor_Color"));
            toolTip.SetToolTip(undoButton, Language.GetString("QuickImageEditor_Undo"));

            _parentForm = Owner;

            switch (_lastUsedTool)
            {
                case QuickImageEditorTool.Select:
                    selectButton.Checked = true;
                    SelectButton_Click(this, null);
                    break;
                case QuickImageEditorTool.Arrow:
                    arrowButton.Checked = true;
                    ArrowButton_Click(this, null);
                    break;
                case QuickImageEditorTool.Pencil:
                    pencilButton.Checked = true;
                    PencilButton_Click(this, null);
                    break;
                case QuickImageEditorTool.Marker:
                    markerButton.Checked = true;
                    markerButton_Click(this, null);
                    break;
                case QuickImageEditorTool.Line:
                    SetShape(ToolboxShape.Line);
                    break;
                case QuickImageEditorTool.Rectangle:
                    SetShape(ToolboxShape.Rectangle);
                    break;
                case QuickImageEditorTool.Ellipse:
                    SetShape(ToolboxShape.Ellipse);
                    break;
                case QuickImageEditorTool.Text:
                    textButton.Checked = true;
                    TextButton_Click(this, null);
                    break;
                case QuickImageEditorTool.Blur:
                    blurButton.Checked = true;
                    BlurButton_Click(this, null);
                    break;
                case QuickImageEditorTool.Counter:
                    counterButton.Checked = true;
                    CounterButton_Click(this, null);
                    break;
                default:
                    throw new InvalidOperationException("_lastUsedTool=" + _lastUsedTool);
            }
        }

        public void SetColor(object colorObject)
        {
            if (null == colorObject)
                colorObject = Color.Transparent;

            var color = (Color)colorObject;

            if (color == Color.Transparent)
                color = BackColor;

            colorButton.BackColor = color;
            colorButton.FlatAppearance.BorderColor = color;
            colorButton.FlatAppearance.MouseDownBackColor = CalculateColor(color, 0.67F);
            colorButton.FlatAppearance.MouseOverBackColor = CalculateColor(color, 0.87F);

            colorButton.ImageKey = ColorUtility.IsDark(color) ? WhiteImageKey : BlackImageKey;
        }

        public void SetCanUndo(bool canUndo)
        {
            undoButton.Enabled = canUndo;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
                return;

            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);

                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;

                    return;
            }

            base.WndProc(ref m);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this,
                new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                    {Argument = QuickImageEditorTool.Select});
        }

        private void ArrowButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this,
                new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                    { Argument = QuickImageEditorTool.Arrow });
        }

        private void PencilButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this,
                new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                    { Argument = QuickImageEditorTool.Pencil });
        }

        private void markerButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this,
                new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                    { Argument = QuickImageEditorTool.Marker });
        }

        private void shapesButton_Click(object sender, EventArgs e)
        {
            switch (_currentShape)
            {
                case ToolboxShape.Rectangle:
                    ServiceCommand?.Invoke(this,
                        new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                            { Argument = QuickImageEditorTool.Rectangle });
                    break;
                case ToolboxShape.Ellipse:
                    ServiceCommand?.Invoke(this,
                        new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                            { Argument = QuickImageEditorTool.Ellipse });
                    break;
                case ToolboxShape.Line:
                    ServiceCommand?.Invoke(this,
                        new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                            { Argument = QuickImageEditorTool.Line });
                    break;
            }
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this,
                new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                    { Argument = QuickImageEditorTool.Text });
        }

        private void BlurButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this,
                new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                    { Argument = QuickImageEditorTool.Blur });
        }
        private void CounterButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this,
                new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Tool)
                    { Argument = QuickImageEditorTool.Counter });
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog
            {
                Color = colorButton.BackColor,
                StartPosition = FormStartPosition.CenterScreen
            };

            if (DialogResult.OK != colorDialog.ShowDialog(this))
                return;

            SetColor(colorDialog.Color);

            ServiceCommand?.Invoke(this,
                new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Color) {Argument = colorDialog.Color});
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Undo));
        }

        private static Color CalculateColor(Color color, float multiplier)
        {
            return Color.FromArgb((byte)(color.R * multiplier), (byte)(color.G * multiplier),
                (byte)(color.B * multiplier));
        }
        private void shapesButton_CheckedChanged(object sender, EventArgs e)
        {
            if (shapesButton.Checked)
            {
                shapesButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
                shapesExpandButton.BackColor = SystemColors.ButtonHighlight;
                shapesExpandButton.FlatAppearance.BorderColor = SystemColors.ButtonHighlight;
            }
            else
            {
                shapesButton.FlatAppearance.BorderColor = SystemColors.Control;
                shapesExpandButton.BackColor = new Color();
                shapesExpandButton.FlatAppearance.BorderColor = SystemColors.Control;
            }
        }

        private void shapesExpandButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (null == _shapesForm)
            {
                _shapesForm = new ToolboxShapesForm();
                _shapesForm.ShapeChanged += (o, args) => { SetShape(args.Shape); };
            }

            if (_shapesForm.Visible)
            {
                _shapesForm.Hide();
                return;
            }
            
            var top = Top + shapesButton.Top + shapesButton.Height;
            var left = Left + shapesButton.Left;

            if (top + _shapesForm.Height > _parentForm.Top + _parentForm.Height)
                top = Top + shapesButton.Top - _shapesForm.Height;

            _shapesForm.Top = top;
            _shapesForm.Left = left;

            _shapesForm.SetCurrentShape(_currentShape);

            if (!_shapesForm.Visible)
                _shapesForm.Show(this);
        }

        private void SetShape(ToolboxShape shape)
        {
            _currentShape = shape;

            switch (_currentShape)
            {
                case ToolboxShape.Rectangle:
                    shapesButton.ImageKey = @"Rectangle";
                    toolTip.SetToolTip(shapesButton, Language.GetString("QuickImageEditor_Rectangle"));
                    break;
                case ToolboxShape.Ellipse:
                    shapesButton.ImageKey = @"Ellipse";
                    toolTip.SetToolTip(shapesButton, Language.GetString("QuickImageEditor_Ellipse"));
                    break;
                case ToolboxShape.Line:
                    shapesButton.ImageKey = @"Line";
                    toolTip.SetToolTip(shapesButton, Language.GetString("QuickImageEditor_Line"));
                    break;
            }

            shapesButton.Checked = true;
            shapesButton_Click(this, null);
        }
    }
}
