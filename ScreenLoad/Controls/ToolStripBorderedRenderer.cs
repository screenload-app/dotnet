using System.Drawing;
using System.Windows.Forms;

namespace ScreenLoad.Controls
{
    public sealed class ToolStripBorderedRenderer : ToolStripProfessionalRenderer
    {
        public ToolStripBorderedRenderer()
        {
            RoundedEdges = false;
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            var toolStrip = e.ToolStrip;
            var graphics = e.Graphics;

            var rectangle = new Rectangle(Point.Empty, toolStrip.Size);

            var toolStripPanel = toolStrip.Parent as ToolStripPanel;

            var toolStripContainer = toolStripPanel?.Parent as ToolStripContainer;

            if (null == toolStripPanel || null == toolStripContainer)
                return;
            
            const float multiplier = 0.7875f;

            var pen1 = new Pen(Color.FromArgb(SystemColors.Control.A, (int) (SystemColors.Control.R * multiplier),
                (int) (SystemColors.Control.G * multiplier), (int) (SystemColors.Control.B * multiplier)));

            var pen2 = SystemPens.ControlLightLight;

            if (toolStripPanel == toolStripContainer.TopToolStripPanel)
            {
                graphics.DrawLine(pen1, rectangle.Left, rectangle.Bottom - 2, rectangle.Right - 1, rectangle.Bottom - 2);
                graphics.DrawLine(pen2, rectangle.Left, rectangle.Bottom - 1, rectangle.Right - 1, rectangle.Bottom - 1);
            }
            else if (toolStripPanel == toolStripContainer.BottomToolStripPanel)
            {
                graphics.DrawLine(pen2, rectangle.Left, rectangle.Top, rectangle.Right - 1, rectangle.Top);
                graphics.DrawLine(pen1, rectangle.Left, rectangle.Top + 1, rectangle.Right - 1,
                    rectangle.Top + 1);
            }
            else if (toolStripPanel == toolStripContainer.LeftToolStripPanel)
            {
                graphics.DrawLine(pen1, rectangle.Right - 2, rectangle.Top, rectangle.Right - 2, rectangle.Bottom - 1);
                graphics.DrawLine(pen2, rectangle.Right - 1, rectangle.Top, rectangle.Right - 1, rectangle.Bottom - 1);
            }
            else if (toolStripPanel == toolStripContainer.RightToolStripPanel)
            {
                graphics.DrawLine(pen2, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom - 1);
                graphics.DrawLine(pen1, rectangle.Left + 1, rectangle.Top, rectangle.Left + 1, rectangle.Bottom - 1);
            }
        }
    }
}
