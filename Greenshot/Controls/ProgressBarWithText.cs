using System;
using System.Drawing;
using System.Windows.Forms;

namespace Greenshot.Controls
{
    // https://stackoverflow.com/questions/3529928/how-do-i-put-text-on-progressbar
    public class ProgressBarWithText : ProgressBar
    {
        public String CustomText { get; set; }

        public ProgressBarWithText()
        {
            // Modify the ControlStyles flags
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.controlstyles.aspx
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var clientRectangle = ClientRectangle;
            var g = e.Graphics;

            ProgressBarRenderer.DrawHorizontalBar(g, clientRectangle);
            clientRectangle.Inflate(-3, -3);

            if (Value > 0)
            {
                // As we doing this ourselves we need to draw the chunks on the progress bar
                var rectangle = new Rectangle(clientRectangle.X, clientRectangle.Y,
                    (int) Math.Round((float) Value / Maximum * clientRectangle.Width), clientRectangle.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, rectangle);
            }

            using (var font = new Font(FontFamily.GenericSerif, Height / 2F))
            {
                SizeF stringSize = g.MeasureString(CustomText, font);
                Point location = new Point(Convert.ToInt32(Width / 2F - stringSize.Width / 2),
                    Convert.ToInt32(Height / 2F - stringSize.Height / 2));
                g.DrawString(CustomText, font, Brushes.Black, location);
            }
        }
    }
}