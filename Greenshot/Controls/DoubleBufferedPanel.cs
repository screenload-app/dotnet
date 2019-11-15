using System.Windows.Forms;

namespace Greenshot.Controls
{
    public  sealed class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
            //ResizeRedraw = true;
        }
    }
}
