using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.Windows.Forms;
using ScreenLoadDownloadRuPlugin.Properties;
using ScreenLoadPlugin.Core;

namespace ScreenLoadDownloadRuPlugin.Forms
{
    public partial class SuccessForm : DownloadRuForm
    {
        private class SocialNetwork
        {
            public string TextKey { get; }
            public string ShareUrlTemplate { get; }
            public int PictureNumber { get; }

            public SocialNetwork(string textKey, string shareUrlTemplate, int pictureNumber)
            {
                TextKey = textKey ?? throw new ArgumentNullException(nameof(textKey));
                ShareUrlTemplate = shareUrlTemplate ?? throw new ArgumentNullException(nameof(shareUrlTemplate));
                PictureNumber = pictureNumber;
            }
        }

        private readonly DownloadRuConfiguration _config;

        private string _okButtonText;
        private int _countdown = 5;

        public SuccessForm(DownloadRuConfiguration config, FileEntry fileEntry)
        {
            if (null == fileEntry)
                throw new ArgumentNullException(nameof(fileEntry));

            _config = config ?? throw new ArgumentNullException(nameof(config));

            InitializeComponent();
            Icon = ScreenLoadResources.win_old;

            var directLink = LinkHelper.BuildDirectLink(fileEntry);
            var pageLink = LinkHelper.BuildPageLink(fileEntry);

            directLinkTextBox.Text = directLink;
            pageLinkTextBox.Text = pageLink;

            var screen = Screen.FromControl(this);
            var workingArea = screen.WorkingArea;

            Top = workingArea.Height - Height;
            Left = workingArea.Width - Width;

            var socialNetworks = new[]
            {
                new SocialNetwork("WebMoney", "https://events.webmoney.ru/sharer/?url={0}", 45),
                new SocialNetwork("Google", "https://www.google.com/searchbyimage?image_url={0}", 46),
                new SocialNetwork("Facebook", "https://www.facebook.com/sharer.php?u={0}", 1),
                new SocialNetwork("Twitter", "http://twitter.com/share?url={0}", 2),
                new SocialNetwork("VK", "https://vk.com/share.php?url={0}", 5),
                new SocialNetwork("Pinterest", "https://pinterest.com/pin/create/button/?url={1}&media={0}", 6),
                new SocialNetwork("Telegram", "https://telegram.me/share/url?url={0}", 3),
                new SocialNetwork("Email", "mailto:?body={0}", 8)
            };

            Bitmap allImages = Resources.pluso;
            bool first = true;

            shareFlowLayoutPanel.SuspendLayout();

            foreach (var socialNetwork in socialNetworks)
            {
                int imageX = (socialNetwork.PictureNumber - 1) * 42;

                var button = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Name = socialNetwork.TextKey,
                    Size = new Size(46, 46),
                    UseVisualStyleBackColor = true,
                    Image = allImages.Clone(new Rectangle(imageX, 0, 40, 40), allImages.PixelFormat),
                    ImageAlign = ContentAlignment.MiddleCenter
                };

                if (first)
                {
                    button.Margin = new Padding(0, button.Margin.Top, button.Margin.Right, button.Margin.Bottom);
                    first = false;
                }

                button.FlatAppearance.BorderColor = SystemColors.Control;
                button.FlatAppearance.BorderSize = 0;

                button.Click += (sender, args) =>
                {
                    string url = string.Format(CultureInfo.InvariantCulture, socialNetwork.ShareUrlTemplate,
                        HttpUtility.UrlEncode(directLink), HttpUtility.UrlEncode(pageLink));
                    Process.Start(url);
                };

                shareFlowLayoutPanel.Controls.Add(button);
            }

            shareFlowLayoutPanel.ResumeLayout(true);
        }

        private void SuccessForm_Load(object sender, EventArgs e)
        {
            _okButtonText = okButton.Text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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
            _config.AfterUploadShowDetails = !doNotShowCheckBox.Checked;
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
                OkButton_Click(this, null);
                return;
            }

            _countdown--;
        }
    }
}
