using System;
using System.Threading;
using System.Windows.Forms;
using log4net;

namespace ScreenLoadDownloadRuPlugin.Forms
{
    public partial class ProgressForm : DownloadRuForm
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProgressForm));

        private Thread _backgroundThread;

        private ProgressForm()
        {
            InitializeComponent();

            var screen = Screen.FromControl(this);
            var workingArea = screen.WorkingArea;

            Top = workingArea.Height - Height;
            Left = workingArea.Width - Width;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            _backgroundThread.Abort();
        }

        public static void ShowAndProcess(Action action)
        {
            if (null == action)
                throw new ArgumentNullException(nameof(action));

            var progressForm = new ProgressForm();

            progressForm.Show();

            Exception threadException = null;

            progressForm._backgroundThread = new Thread(() =>
                {
                    try
                    {
                        action();
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception);
                        threadException = exception;
                    }
                })
            {
                IsBackground = true
            };

            progressForm._backgroundThread.SetApartmentState(ApartmentState.STA);
            progressForm._backgroundThread.Start();

            while (!progressForm._backgroundThread.Join(TimeSpan.FromMilliseconds(100)))
            {
                Application.DoEvents();
            }

            progressForm.Close();

            if (null != threadException)
                throw threadException;
        }
    }
}