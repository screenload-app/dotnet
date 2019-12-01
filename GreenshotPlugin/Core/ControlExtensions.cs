using System;
using System.Windows.Forms;

namespace GreenshotPlugin.Core
{
    public static class ControlExtensions
    {
        public static void InvokeAction(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
