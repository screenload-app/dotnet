using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ScreenLoad.Helpers;
using ScreenLoadPlugin.Controls;
using ScreenLoadPlugin.Core;

namespace ScreenLoad
{
    public partial class UpdateForm : ScreenLoadForm
    {
        //private class WebClient : System.Net.WebClient
        //{
        //    public int Timeout { get; set; }

        //    protected override System.Net.WebRequest GetWebRequest(Uri uri)
        //    {
        //        var webRequest = base.GetWebRequest(uri);

        //        if (null == webRequest)
        //            throw new InvalidOperationException("null == webRequest");

        //        webRequest.Timeout = Timeout;
        //        ((System.Net.HttpWebRequest)webRequest).ReadWriteTimeout = Timeout;
        //        return webRequest;
        //    }
        //}

        private const int WM_LBUTTONDBLCLK = 0x00A3;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private static readonly object Locker = new object();

        private static bool _shown;

        private readonly VersionInfo _versionInfo;
        private readonly bool _raisedManually;
        private readonly WebClient _webClient;

        private string _tempFilePath;

        private bool _closed;

        private bool _closeApp;

        private UpdateForm(bool raisedManually, bool requestConfirmation)
        {
            InitializeComponent();

            var versionInfo = VersionInfo.TryLoadFrom(coreConfiguration, !coreConfiguration.CheckForUnstable);

            _versionInfo = versionInfo ?? throw new InvalidOperationException("null == versionInfo");
            _raisedManually = raisedManually;

            string info = versionInfo.Info;

            if (string.IsNullOrEmpty(info))
                info = Language.GetFormattedString("UpdateForm_Info", versionInfo.Version);

            infoLabel.Text = info;

            var screen = Screen.FromControl(this);
            var workingArea = screen.WorkingArea;

            Top = workingArea.Height - Height;
            Left = workingArea.Width - Width;

            _webClient = new WebClient();

            //_webClient = new WebClient
            //{
            //    Timeout = 10 * 1000
            //};

            _webClient.DownloadProgressChanged += (sender, args) =>
            {
                mProgressBar.Value = args.ProgressPercentage;
            };

            _webClient.DownloadFileCompleted += (sender, args) =>
            {
                if (null != args.Error)
                {
                    //mProgressBar.BarColor = Color.Red;
                    //mProgressBar.Invalidate();
                    //mProgressBar.Update();

                    infoLabel.BackColor = Color.LightPink;
                    infoLabel.Text = Language.GetFormattedString("update_error", args.Error.Message);

                    return;
                }

                if (args.Cancelled)
                {
                    Close();
                    return;
                }

                if (_closed || IsDisposed)
                    return;

                UpdateHelper.RunUpdate(_tempFilePath);

                _closeApp = true;
                Close();
            };

            if (_raisedManually)
                laterButton.LanguageKey = "UpdateForm_Cancel";

            if (!requestConfirmation)
                updateNowButton_Click(this, null);
        }

        public static void ShowSingle(bool raisedManually, bool requestConfirmation = true)
        {
            lock (Locker)
            {
                if (_shown)
                    return;

                _shown = true;
            }
            
            MainForm.Instance.InvokeAction(() =>
            {
                var form = new UpdateForm(raisedManually, requestConfirmation);
                form.Show(MainForm.Instance);
            });
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
                return;

            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);

                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;

                    return;
            }

            base.WndProc(ref m);
        }

        private void laterButton_Click(object sender, EventArgs e)
        {
            if (_raisedManually)
            {
                _closed = true;

                lock (Locker)
                {
                    _shown = false;
                }

                Close();

                return;
            }

            bottomFlowPanel.SuspendLayout();
            bottomFlowPanel.Controls.Clear();
            bottomFlowPanel.Controls.Add(remindBottomPanel);
            remindBottomPanel.Visible = true;
            bottomFlowPanel.ResumeLayout(true);
        }

        private void remindButton_Click(object sender, EventArgs e)
        {
            if (inAnHourRadioButton.Checked)
                coreConfiguration.PostponeUpdateMode = PostponeUpdateMode.Hour;
            else if (tomorrowRadioButton.Checked)
                coreConfiguration.PostponeUpdateMode = PostponeUpdateMode.Day;
            else
            {
                coreConfiguration.PostponeUpdateMode = PostponeUpdateMode.None;
                coreConfiguration.CheckUpdatesAuto = false;
            }

            _closed = true;

            lock (Locker)
            {
                _shown = false;
            }

            Close();
        }

        private void updateNowButton_Click(object sender, EventArgs e)
        {
            updateNowButton.Enabled = false;

            bottomFlowPanel.SuspendLayout();
            bottomFlowPanel.Controls.Clear();
            bottomFlowPanel.Controls.Add(progressBottomPanel);
            progressBottomPanel.Visible = true;
            bottomFlowPanel.ResumeLayout(true);

            _tempFilePath = Path.Combine(Path.GetTempPath(), _versionInfo.FileName);

            if (File.Exists(_tempFilePath))
                File.Delete(_tempFilePath);

            //mProgressBar.CustomText = "0%";
            _webClient.DownloadFileAsync(
                new Uri(UpdateHelper.BuildDownloadLink(coreConfiguration, _versionInfo.FileName)), _tempFilePath);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (null != _webClient && _webClient.IsBusy)
                _webClient.CancelAsync();

            _closed = true;

            lock (Locker)
            {
                _shown = false;
            }

            Close();
        }

        //private void ReportProgress(int progressPercentage, float received, float toReceive)
        //{
        //    mProgressBar.Value = progressPercentage;

        //    var unit = Language.GetString("UpdateForm_byte"); // Б

        //    if (toReceive > 1024)
        //    {
        //        received /= 1024;
        //        toReceive /= 1024;
        //        unit = Language.GetString("UpdateForm_kilobyte"); // кбайт

        //        if (toReceive > 1024)
        //        {
        //            received /= 1024;
        //            toReceive /= 1024;
        //            unit = Language.GetString("UpdateForm_megabyte"); // Мбайт
        //        }
        //    }

        //    mProgressBar.CustomText = string.Format(CultureInfo.InvariantCulture, " {0}% - {1:0.00}/{2:0.00} {3}",
        //        progressPercentage, received, toReceive, unit);
        //}

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_closeApp)
                MainForm.Instance.Invoke((MethodInvoker) MainForm.Instance.Exit);
        }
    }
}
