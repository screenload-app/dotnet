using System.Drawing;
using System.Windows.Forms;

namespace ScreenLoad.Controls
{
    public sealed class StatusStripBorderedRenderer : ToolStripProfessionalRenderer
    {
        public StatusStripBorderedRenderer()
        {
            RoundedEdges = false;
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            var toolStrip = e.ToolStrip;
            var graphics = e.Graphics;

            var rectangle = new Rectangle(Point.Empty, toolStrip.Size);
            
            using (var pen1 = new Pen(ColorTable.SeparatorDark))
            using (var pen2 = new Pen(ColorTable.SeparatorLight))
            {
                graphics.DrawLine(pen1, rectangle.Left, rectangle.Top, rectangle.Right - 1, rectangle.Top);
                graphics.DrawLine(pen2, rectangle.Left, rectangle.Top + 1, rectangle.Right - 1,
                    rectangle.Top + 1);
            }
        }
    }
}
