using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ScreenLoad.Forms;
using ScreenLoad.Helpers;
using ScreenLoadPlugin.Controls;
using ScreenLoadPlugin.Core;

namespace ScreenLoad
{
    public sealed partial class AboutForm : ScreenLoadForm
    {
        #region Assembly Attribute Accessors

        private static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];

                    if (!string.IsNullOrEmpty(titleAttribute.Title))
                        return titleAttribute.Title;
                }

                return Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
            }
        }

        private static string AssemblyVersion
        {
            get
            {
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
                return fileVersionInfo.FileVersion;
            }
        }

        private static string AssemblyDescription
        {
            get
            {
                var attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        private static string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        private static string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        public AboutForm()
        {
            InitializeComponent();


            titleLabel.Text = AssemblyTitle;
            versionValueLabel.Text = String.Format(CultureInfo.InvariantCulture, @"{0}", AssemblyVersion);
            copyrightValueLabel.Text = AssemblyCopyright;
            companyNameValueLabel.Text = AssemblyCompany;
            descriptionRichTextBox.Text = AssemblyDescription;

            companyNameValueLabel.Tag = "https://download.ru/about";
            licenseValueLabel.Tag = "http://www.gnu.org/licenses/gpl-3.0.html";
            logoPictureBox.Tag = "http://screenload.ru/";

            companyNameValueLabel.Click += ValueLabelOnClick;
            licenseValueLabel.Click += ValueLabelOnClick;
            logoPictureBox.Click += ValueLabelOnClick;

            descriptionRichTextBox.Rtf = Language.CurrentLanguage.Equals("ru-RU")
                ? Resources.AboutScreenLoad_ru_RU
                : Resources.AboutScreenLoad_en_US;
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            Text = String.Format(CultureInfo.InvariantCulture, Text, AssemblyTitle);
            toolTip.SetToolTip(updateButton, Language.GetString("About_CheckForUpdatesButton"));
        }

        private void ValueLabelOnClick(object sender, EventArgs e)
        {
            if ((sender as Control)?.Tag is string url)
                Process.Start(url);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            updateButton.Enabled = false;

            UpdateHelper.CheckAndAskForUpdateInThread(UpdateRaised.Manually, coreConfiguration, 0, result =>
            {
                this.InvokeAction(() =>
                {
                    if (IsDisposed)
                        return;

                    updateButton.Enabled = true;

                    if (UpdateCheckingResult.NotFound == result)
                    {
                        MainForm.Instance.NotifyIcon.ShowBalloonTip(10000, "ScreenLoad",
                            Language.GetString("noupdatesfound"), ToolTipIcon.Info);
                    }
                });
            });
        }

        private void descriptionRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (CheckUrl(e.LinkText))
                Process.Start(e.LinkText);
        }

        private bool CheckUrl(string value)
        {
            Uri uri;

            return Uri.TryCreate(value, UriKind.Absolute, out uri)
                   && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }
    }
}