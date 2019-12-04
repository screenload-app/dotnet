using System;
using System.Windows.Forms;

namespace ScreenLoadPlugin.Core
{
    public static class DialogManager
    {
        private static readonly object LockObject = new object();

        private static volatile Form _topForm;

        public static void SetTopForm(Form topForm)
        {
            if (null == topForm)
                throw new ArgumentNullException(nameof(topForm));

            lock (LockObject)
            {
                _topForm = topForm;
            }
        }

        public static void ResetTopForm()
        {
            lock (LockObject)
            {
                _topForm = null;
            }
        }

        public static void ShowDialog(Form form)
        {
            if (null == form)
                throw new ArgumentNullException(nameof(form));

            Form topForm;

            lock (LockObject)
            {
                topForm = _topForm;
            }

            if (topForm.IsDisposed)
                topForm = null;

            topForm.InvokeAction(() =>
            {
                if (topForm?.IsDisposed ?? true)
                    topForm = null;

                form.ShowDialog(topForm);
            });
        }
    }
}
