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

        public HorizontalToolboxForm()
        {
            InitializeComponent();

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
            toolTip.SetToolTip(lineRadioButton, Language.GetString("QuickImageEditor_Line"));
            toolTip.SetToolTip(rectangleButton, Language.GetString("QuickImageEditor_Rectangle"));
            toolTip.SetToolTip(ellipseRadioButton, Language.GetString("QuickImageEditor_Ellipse"));
            toolTip.SetToolTip(textButton, Language.GetString("QuickImageEditor_Text"));
            toolTip.SetToolTip(blurButton, Language.GetString("QuickImageEditor_Blur"));
            toolTip.SetToolTip(counterButton, Language.GetString("QuickImageEditor_Counter"));
            toolTip.SetToolTip(colorButton, Language.GetString("QuickImageEditor_Color"));
            toolTip.SetToolTip(undoButton, Language.GetString("QuickImageEditor_Undo"));
        }

        public void SetColor(Color color)
        {
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
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Select));
        }

        private void ArrowButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Arrow));
        }

        private void PencilButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Pencil));
        }

        private void LineRadioButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Line));
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Rectangle));
        }

        private void EllipseRadioButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Ellipse));
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Text));
        }

        private void BlurButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Blur));
        }
        private void CounterButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Counter));
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
    }
}
