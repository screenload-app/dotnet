using System;
using System.Windows.Forms;
using ScreenLoad.Helpers;
using ScreenLoadPlugin.Core;

namespace ScreenLoad
{
    public partial class ToolboxShapesForm : Form
    {
        public event EventHandler<ShapeChangedEventArgs> ShapeChanged;

        public ToolboxShapesForm()
        {
            InitializeComponent();
        }

        private void ToolboxShapesForm_Load(object sender, EventArgs e)
        {
            toolTip.SetToolTip(lineRadioButton, Language.GetString("QuickImageEditor_Line"));
            toolTip.SetToolTip(rectangleButton, Language.GetString("QuickImageEditor_Rectangle"));
            toolTip.SetToolTip(ellipseButton, Language.GetString("QuickImageEditor_Ellipse"));
        }

        public void SetCurrentShape(ToolboxShape currentShape)
        {
            mFlowLayoutPanel.SuspendLayout();
            mFlowLayoutPanel.Controls.Clear();

            switch (currentShape)
            {
                case ToolboxShape.Rectangle:
                    mFlowLayoutPanel.Controls.Add(ellipseButton);
                    mFlowLayoutPanel.Controls.Add(lineRadioButton);
                    break;
                case ToolboxShape.Ellipse:
                    mFlowLayoutPanel.Controls.Add(rectangleButton);
                    mFlowLayoutPanel.Controls.Add(lineRadioButton);
                    break;
                case ToolboxShape.Line:
                    mFlowLayoutPanel.Controls.Add(rectangleButton);
                    mFlowLayoutPanel.Controls.Add(ellipseButton);
                    break;
            }

            mFlowLayoutPanel.ResumeLayout(true);
        }

        private void ToolboxShapesForm_Deactivate(object sender, EventArgs e)
        {
            Hide();
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            ShapeChanged?.Invoke(this, new ShapeChangedEventArgs(ToolboxShape.Rectangle));
            Hide();
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            ShapeChanged?.Invoke(this, new ShapeChangedEventArgs(ToolboxShape.Ellipse));
            Hide();
        }

        private void lineRadioButton_Click(object sender, EventArgs e)
        {
            ShapeChanged?.Invoke(this, new ShapeChangedEventArgs(ToolboxShape.Line));
            Hide();
        }
    }
}
