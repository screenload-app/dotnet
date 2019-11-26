using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Greenshot.Helpers;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;

namespace Greenshot
{
    public partial class UpdateForm : GreenshotForm
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

        private static UpdateForm _instance;

        private readonly VersionInfo _versionInfo;
        private readonly WebClient _webClient;

        private string _tempFilePath;

        private bool _closed;

        private UpdateForm(VersionInfo versionInfo)
        {
            InitializeComponent();

            _versionInfo = versionInfo ?? throw new ArgumentNullException(nameof(versionInfo));

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
                ReportProgress(args.ProgressPercentage, args.BytesReceived, args.TotalBytesToReceive);
            };

            _webClient.DownloadFileCompleted += (sender, args) =>
            {
                if (null != args.Error)
                {
                    mProgressBar.BarColor = Color.Red;
                    mProgressBar.Invalidate();
                    mProgressBar.Update();

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

                lock (Locker)
                {
                    _instance = null;
                }

                DialogResult = DialogResult.OK;
            };
        }

        public static DialogResult ShowSingleDialog(VersionInfo versionInfo)
        {
            if (null == versionInfo)
                throw new ArgumentNullException(nameof(versionInfo));

            lock (Locker)
            {
                if (null != _instance)
                    return DialogResult.Cancel;

                _instance = new UpdateForm(versionInfo);
            }

            return _instance.ShowDialog();
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

        private void okLabel_Click(object sender, EventArgs e){
            okLabel.Enabled = false;

            bottomFlowPanel.SuspendLayout();
            bottomFlowPanel.Controls.Clear();
            bottomFlowPanel.Controls.Add(progressBottomPanel);
            progressBottomPanel.Visible = true;
            bottomFlowPanel.ResumeLayout(true);

            _tempFilePath = Path.Combine(Path.GetTempPath(), _versionInfo.File);

            if (File.Exists(_tempFilePath))
                File.Delete(_tempFilePath);

            mProgressBar.CustomText = "0%";
            _webClient.DownloadFileAsync(new Uri(_versionInfo.DownloadLink), _tempFilePath);
        }

        private void cancelLabel_Click(object sender, EventArgs e)
        {
            if (null != _webClient && _webClient.IsBusy)
                _webClient.CancelAsync();

            _closed = true;

            lock (Locker)
            {
                _instance = null;
            }

            DialogResult = DialogResult.Cancel;
        }

        private void ReportProgress(int progressPercentage, float received, float toReceive)
        {
            mProgressBar.Value = progressPercentage;

            var unit = Language.GetString("UpdateForm_byte"); // Б

            if (toReceive > 1024)
            {
                received /= 1024;
                toReceive /= 1024;
                unit = Language.GetString("UpdateForm_kilobyte"); // кбайт

                if (toReceive > 1024)
                {
                    received /= 1024;
                    toReceive /= 1024;
                    unit = Language.GetString("UpdateForm_megabyte"); // Мбайт
                }
            }

            mProgressBar.CustomText = string.Format(CultureInfo.InvariantCulture, " {0}% - {1:0.00}/{2:0.00} {3}",
                progressPercentage, received, toReceive, unit);
        }
    }
}
