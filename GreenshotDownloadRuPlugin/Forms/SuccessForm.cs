using System;
using System.Windows.Forms;
using GreenshotPlugin.Core;

namespace GreenshotDownloadRuPlugin.Forms
{
    public partial class SuccessForm : Form
    {
        public SuccessForm(FileEntry fileEntry)
        {
            if (null == fileEntry)
                throw new ArgumentNullException(nameof(fileEntry));

            InitializeComponent();

            // TODO: $ Перенести!
            directLinkTextBox.Text = $"https://download.ru/{fileEntry.Preview.UrlsEntry.Large}";
            pageLinkTextBox.Text = $"https://download.ru/f/{fileEntry.Id}";

            var screen = Screen.FromControl(this);
            var workingArea = screen.WorkingArea;

            Top = workingArea.Height - Height;
            Left = workingArea.Width - Width;
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
    }
}
