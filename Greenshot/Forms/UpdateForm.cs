using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Greenshot.Helpers;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;

namespace Greenshot
{
    public partial class UpdateForm : GreenshotForm
    {
        private readonly string _downloadLink;
        private readonly WebClient _webClient;
        private readonly string _tempFilePath;
        private readonly VersionInfo _versionInfo;

        private bool _closed;

        public UpdateForm(VersionInfo versionInfo, string downloadLink)
        {
            _versionInfo = versionInfo ?? throw new ArgumentNullException(nameof(versionInfo));

            _downloadLink = downloadLink ?? throw new ArgumentNullException(nameof(downloadLink));

            InitializeComponent();

            if (null != versionInfo.Info)
                infoTextBox.Text = versionInfo.Info;

            var screen = Screen.FromControl(this);
            var workingArea = screen.WorkingArea;

            Top = workingArea.Height - Height;
            Left = workingArea.Width - Width;

            _webClient = new WebClient();
            _webClient.DownloadProgressChanged += (sender, args) =>
            {
                ReportProgress(args.ProgressPercentage, args.BytesReceived, args.TotalBytesToReceive);
            };
            _webClient.DownloadFileCompleted += (sender, args) =>
            {
                if (null != args.Error)
                {
                    captionLabel.Text = Language.GetString("error");

                    infoTextBox.BackColor = Color.LightPink;
                    infoTextBox.Text = Language.GetFormattedString("update_error", args.Error.Message);
                    return;
                }

                if (args.Cancelled)
                {
                    Close();
                    return;
                }

                if (_closed || IsDisposed)
                    return;

                var thread = new Thread(o =>
                {
                    Thread.Sleep(500); // ждем, пока приложение закроется...

                    var filePath = (string) o;

                    // http://www.jrsoftware.org/ishelp/index.php?topic=setupcmdline
                    var startInfo = new ProcessStartInfo
                    {
                        Arguments = "/SILENT",
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = filePath,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    try
                    {
                        Process.Start(startInfo);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Greenshot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                })
                {
                    IsBackground = false
                };

                thread.Start(_tempFilePath);
                MainForm.Instance.Exit();
            };

            _tempFilePath = Path.Combine(Path.GetTempPath(), versionInfo.File);

            if (File.Exists(_tempFilePath))
                File.Delete(_tempFilePath);
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            mProgressBar.CustomText = "0%";
            captionLabel.Text = Language.GetFormattedString("updateform_caption", _versionInfo.Version);
            _webClient.DownloadFileAsync(new Uri(_downloadLink), _tempFilePath);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _webClient.CancelAsync();
            Close();
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closed = true;
            _webClient.CancelAsync();
        }

        private void ReportProgress(int progressPercentage, float received, float toReceive)
        {
            mProgressBar.Value = progressPercentage;

            var unit = Language.GetString("updateform_byte"); // Б

            if (toReceive > 1024)
            {
                received /= 1024;
                toReceive /= 1024;
                unit = Language.GetString("updateform_kilobyte"); // кбайт

                if (toReceive > 1024)
                {
                    received /= 1024;
                    toReceive /= 1024;
                    unit = Language.GetString("updateform_megabyte"); // Мбайт
                }
            }

            mProgressBar.CustomText = string.Format(CultureInfo.InvariantCulture, " {0}% - {1:0.00}/{2:0.00} {3}",
                progressPercentage, received, toReceive, unit);
        }
    }
}
