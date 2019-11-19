using System;
using System.Threading;
using System.Windows.Forms;
using log4net;

namespace GreenshotDownloadRuPlugin.Forms
{
    public partial class ProgressForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProgressForm));

        private readonly Action _action;

        private Thread _backgroundThread;
        public Exception Exception { get; private set; }

        public ProgressForm(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));

            InitializeComponent();

            var screen = Screen.FromControl(this);
            var workingArea = screen.WorkingArea;

            Top = workingArea.Height - Height;
            Left = workingArea.Width - Width;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            Process();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            _backgroundThread.Abort();
        }

        private void Process()
        {
            _backgroundThread = new Thread(() =>
                {
                    try
                    {
                        _action();

                        SetDialogResult(DialogResult.OK);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception);
                        Exception = exception;

                        SetDialogResult(DialogResult.Cancel);
                    }
                })
            {
                IsBackground = true
            };

            _backgroundThread.SetApartmentState(ApartmentState.STA);
            _backgroundThread.Start();
        }

        private void SetDialogResult(DialogResult dialogResult)
        {
            Action action = () => { DialogResult = dialogResult; };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
    }
}