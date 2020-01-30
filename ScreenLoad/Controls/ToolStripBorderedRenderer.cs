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

            if (toolStripPanel == toolStripContainer.TopToolStripPanel)
            {
                graphics.DrawLine(SystemPens.ControlDark, rectangle.Left, rectangle.Bottom - 2, rectangle.Right - 1, rectangle.Bottom - 2);
                graphics.DrawLine(SystemPens.ControlDarkDark, rectangle.Left, rectangle.Bottom - 1, rectangle.Right - 1, rectangle.Bottom - 1);
            }
            else if (toolStripPanel == toolStripContainer.BottomToolStripPanel)
            {
                graphics.DrawLine(SystemPens.ControlDarkDark, rectangle.Left, rectangle.Top, rectangle.Right - 1, rectangle.Top);
                graphics.DrawLine(SystemPens.ControlDark, rectangle.Left, rectangle.Top + 1, rectangle.Right - 1,
                    rectangle.Top + 1);
            }
            else if (toolStripPanel == toolStripContainer.LeftToolStripPanel)
            {
                graphics.DrawLine(SystemPens.ControlDark, rectangle.Right - 2, rectangle.Top, rectangle.Right - 2, rectangle.Bottom - 1);
                graphics.DrawLine(SystemPens.ControlDarkDark, rectangle.Right - 1, rectangle.Top, rectangle.Right - 1, rectangle.Bottom - 1);
            }
            else if (toolStripPanel == toolStripContainer.RightToolStripPanel)
            {
                graphics.DrawLine(SystemPens.ControlDarkDark, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom - 1);
                graphics.DrawLine(SystemPens.ControlDark, rectangle.Left + 1, rectangle.Top, rectangle.Left + 1, rectangle.Bottom - 1);
            }
        }
    }
}
