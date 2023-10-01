using System.Windows.Forms;

namespace ScreenLoad.Controls
{
    public sealed class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
        }
    }
}
