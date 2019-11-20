using System.Drawing;
using System.Windows.Forms;
using Greenshot.Helpers;

namespace Greenshot.Controls
{
    public class SimpleColorButton : Button
    {
        private const int MarkSize = 4;
        //private const int MarkLeftSize = 2;
        //private const int MarkRightSize = 4;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var x = e.Graphics.VisibleClipBounds.Width - (MarkSize * 2 + 1) * 2;
            var y = e.Graphics.VisibleClipBounds.Height / 2 - MarkSize;

            //var x = e.Graphics.VisibleClipBounds.Width - (MarkLeftSize + MarkRightSize + 1) * 2;
            //var y = e.Graphics.VisibleClipBounds.Height / 2;

            using (var pen = new Pen(ColorUtility.CalculateContrastColor(BackColor)))
            {
                //e.Graphics.DrawLines(pen, new[]
                //{
                //    new PointF(x, y),
                //    new PointF(x + MarkLeftSize, y + MarkLeftSize),
                //    new PointF(x + MarkLeftSize + MarkRightSize, y - MarkLeftSize)
                //});

                //e.Graphics.DrawLines(pen, new[]
                //{
                //    new PointF(x, y - 1),
                //    new PointF(x + MarkLeftSize, y + MarkLeftSize - 1),
                //    new PointF(x + MarkLeftSize + MarkRightSize, y - MarkLeftSize - 1)
                //});

                e.Graphics.DrawLines(pen, new[]
                {
                    new PointF(x, y),
                    new PointF(x + MarkSize, y + MarkSize),
                    new PointF(x + MarkSize * 2, y)
                });

                e.Graphics.DrawLines(pen, new[]
                {
                    new PointF(x, y),
                    new PointF(x + MarkSize, y + MarkSize),
                    new PointF(x + MarkSize * 2, y)
                });

                e.Graphics.DrawLines(pen, new[]
                {
                    new PointF(x, y + 1),
                    new PointF(x + MarkSize, y + MarkSize + 1),
                    new PointF(x + MarkSize * 2, y + 1)
                });
            }
        }
    }
}
