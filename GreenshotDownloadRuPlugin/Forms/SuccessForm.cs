using System;
using System.Windows.Forms;
using GreenshotPlugin.Core;

namespace GreenshotDownloadRuPlugin.Forms
{
    public partial class SuccessForm : DownloadRuForm
    {
        private readonly DownloadRuConfiguration _config;

        private string _okButtonText;
        private int _countdown = 5;

        public SuccessForm(DownloadRuConfiguration config, FileEntry fileEntry)
        {
            if (null == fileEntry)
                throw new ArgumentNullException(nameof(fileEntry));

            _config = config ?? throw new ArgumentNullException(nameof(config));

            InitializeComponent();
            Icon = GreenshotResources.getGreenshotIcon();
            
            directLinkTextBox.Text = LinkHelper.BuildDirectLink(fileEntry);
            pageLinkTextBox.Text = LinkHelper.BuildPageLink(fileEntry);

            var screen = Screen.FromControl(this);
            var workingArea = screen.WorkingArea;

            Top = workingArea.Height - Height;
            Left = workingArea.Width - Width;
        }

        private void SuccessForm_Load(object sender, EventArgs e)
        {
            _okButtonText = okButton.Text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DirectLinkButton_Click(object sender, EventArgs e)
        {
            ClipboardHelper.SetClipboardData(directLinkTextBox.Text);
        }

        private void PageLinkButton_Click(object sender, EventArgs e)
        {
            ClipboardHelper.SetClipboardData(pageLinkTextBox.Text);
        }

        private void doNotShowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.AfterUploadLinkShowDetails = !doNotShowCheckBox.Checked;
        }

        private void AutomaticallyCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticallyCloseCheckBox.Checked)
            {
                mTimer.Enabled = true;
            }
            else
            {
                mTimer.Enabled = false;
                okButton.Text = _okButtonText;
            }
        }

        private void MTimer_Tick(object sender, EventArgs e)
        {
            okButton.Text = $@"{_okButtonText} - {_countdown}";

            if (0 == _countdown)
            {
                Close();
                return;
            }

            _countdown--;
        }
    }
}
