using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScreenLoadPlugin.Core;
using log4net;

namespace ScreenLoadDownloadRuPlugin.Forms
{
    public sealed partial class LoginForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginForm));

        private readonly string _authorizationLink;
        private readonly string _callbackUrl;

        public IDictionary<string, string> CallbackParameters { get; private set; }

        public bool IsOk => DialogResult == DialogResult.OK;

        public LoginForm(string browserTitle, Size size, string authorizationLink, string callbackUrl)
        {
            // Make sure ScreenLoad uses the correct browser version
            IEHelper.FixBrowserVersion(false);

            _authorizationLink = authorizationLink;
            _callbackUrl = callbackUrl;

            // Fix for BUG-2071
            if (callbackUrl.EndsWith("/"))
                _callbackUrl = callbackUrl.Substring(0, callbackUrl.Length - 1);

            InitializeComponent();
            ClientSize = size;
            Icon = ScreenLoadResources.win_old;
            Text = browserTitle;
            _addressTextBox.Text = authorizationLink;

            // The script errors are suppressed by using the ExtendedWebBrowser
            _browser.ScriptErrorsSuppressed = false;
            _browser.DocumentCompleted += Browser_DocumentCompleted;
            _browser.Navigated += Browser_Navigated;
            _browser.Navigating += Browser_Navigating;
            _browser.Navigate(new Uri(authorizationLink));
        }

        private void OAuthLoginForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Make sure the form is visible
        /// </summary>
        /// <param name="e">EventArgs</param>
        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);
        //    WindowDetails.ToForeground(Handle);
        //}

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Log.DebugFormat("document completed with url: {0}", _browser.Url);
            CheckUrl();
        }

        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Log.DebugFormat("Navigating to url: {0}", _browser.Url);
            _addressTextBox.Text = e.Url.ToString();
        }

        private void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Log.DebugFormat("Navigated to url: {0}", _browser.Url);
            CheckUrl();
        }

        private void CheckUrl()
        {
            if (_browser.Url.ToString().StartsWith(_callbackUrl))
            {
                var correctedUri = new Uri(_browser.Url.AbsoluteUri.Replace("#", "&"));

                string queryParams = correctedUri.Query;

                if (queryParams.Length > 0)
                {
                    queryParams = NetworkHelper.UrlDecode(queryParams);
                    //Store the Token and Token Secret
                    CallbackParameters = NetworkHelper.ParseQueryString(queryParams);
                }

                DialogResult = DialogResult.OK;
            }
            else if (_browser.Url.ToString()
                .StartsWith("https://download.ru/users/auth/", StringComparison.OrdinalIgnoreCase))
            {
                Opacity = 1;
                //ShowInTaskbar = false;
                _browser.Navigate(new Uri(_authorizationLink));
            }
        }

        private void AddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Cancel the key press so the user can't enter a new url
            e.Handled = true;
        }
    }
}
