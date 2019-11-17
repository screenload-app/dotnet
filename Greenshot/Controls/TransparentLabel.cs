using System;
using System.Windows.Forms;

namespace Greenshot.Controls
{
    public sealed class TransparentLabel : Label
    {
        const int WM_NCHITTEST = 0x0084;
        const int HTTRANSPARENT = -1;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)HTTRANSPARENT;
            else
                base.WndProc(ref m);
        }
    }
}
