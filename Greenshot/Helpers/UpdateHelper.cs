/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Greenshot.Configuration;
using Greenshot.IniFile;
using GreenshotPlugin.Core;
using log4net;

namespace Greenshot.Helpers
{
    public sealed class VersionInfo
    {
        private readonly XmlNode _xmlNode;

        public Version Version { get; }
        public string File { get; }

        public string Info
        {
            get
            {
                var infoNode = _xmlNode.SelectSingleNode($"info[@locale=\"{Language.CurrentLanguage}\"]") ??
                               _xmlNode.SelectSingleNode("info[@locale=\"en-US\"]");

                return infoNode?.InnerText;
            }
        }

        public bool Unwanted { get; set; }

        public VersionInfo(XmlNode xmlNode)
        {
            _xmlNode = xmlNode ?? throw new ArgumentNullException(nameof(xmlNode));

            var numberValue = xmlNode.Attributes?["number"].Value;

            if (null == numberValue)
                throw new InvalidOperationException("null == numberValue");

            Version = new Version(numberValue);

            var file = xmlNode.Attributes?["file"].Value;
            File = file ?? throw new InvalidOperationException("null == file");
        }
    }

    public static class UpdateHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpdateHelper));
        private static readonly CoreConfiguration CoreConfig = IniConfig.GetIniSection<CoreConfiguration>();

        private const string VersionHistoryLink = "https://d2n4w7xg423fnr.cloudfront.net/temp/Nov2019/update/VersionHistory.xml";
        public const string DownloadLinkTemplate = "https://d2n4w7xg423fnr.cloudfront.net/temp/Nov2019/update/{0}";

        private static readonly object LockObject = new object();

        private static VersionInfo _lastVersion;

        /// <summary>
        /// Is an update check needed?
        /// </summary>
        /// <returns>bool true if yes</returns>
        public static bool IsUpdateCheckNeeded()
        {
            lock (LockObject)
            {
                if (CoreConfig.UpdateCheckInterval == 0)
                    return false;

                var lastUpdateCheck = CoreConfig.LastUpdateCheck;
                lastUpdateCheck = lastUpdateCheck.AddDays(CoreConfig.UpdateCheckInterval);

                if (DateTime.Now.CompareTo(lastUpdateCheck) < 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Read the RSS feed to see if there is a Greenshot update
        /// </summary>
        public static bool CheckAndAskForUpdate(CoreConfiguration configuration)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            lock (LockObject)
            {
                var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
                // Test like this:
                // currentVersion = new Version("0.8.1.1198");

                try
                {
                    VersionInfo lastVersion;

                    using (var webClient = new WebClient())
                    {
                        webClient.Encoding = Encoding.UTF8;

                        var versionHistoryText = webClient.DownloadString(new Uri(VersionHistoryLink));

                        var xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(versionHistoryText);

                        var xPath = configuration.UseStableVersionsOnly ? "version[@type='release']" : "version";

                        var versionNodes = xmlDocument.DocumentElement?.SelectNodes(xPath);

                        if (null == versionNodes)
                            throw new InvalidOperationException("null == versionNodes");

                        var versionInfoList = versionNodes.Cast<XmlNode>().Select(vn => new VersionInfo(vn));

                        lastVersion = versionInfoList.OrderByDescending(vi => vi.Version).First();
                    }

                    if (null == _lastVersion)
                        _lastVersion = lastVersion;
                    else
                    {
                        if (_lastVersion.Version >= lastVersion.Version && _lastVersion.Unwanted)
                            return false; // Уже оповещали

                        _lastVersion = lastVersion;
                    }

                    if (_lastVersion.Version <= currentVersion)
                        return false;

                    var text = Language.GetFormattedString(LangKey.update_found, _lastVersion.Version);

                    if (null != _lastVersion.Info)
                        text = $"{text} {_lastVersion.Info}";

                    MainForm.Instance.NotifyIcon.BalloonTipClicked += HandleBalloonTipClick;
                    MainForm.Instance.NotifyIcon.BalloonTipClosed += CleanupBalloonTipClick;
                    MainForm.Instance.NotifyIcon.ShowBalloonTip(10000, "Greenshot", text, ToolTipIcon.Info);

                    CoreConfig.LastUpdateCheck = DateTime.Now;

                    return true;
                }
                catch (Exception e)
                {
                    Log.Error("An error occured while checking for updates, the error will be ignored: ", e);
                    return false;
                }
            }
        }

        private static void HandleBalloonTipClick(object sender, EventArgs e)
        {
            CleanupBalloonTipClick(sender, e);

            var text = Language.GetFormattedString("update_confirmation", _lastVersion.Version);

            if (DialogResult.Yes == MessageBox.Show(MainForm.Instance, text, "Greenshot", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                var updateForm = new UpdateForm(_lastVersion,
                    string.Format(CultureInfo.InvariantCulture, DownloadLinkTemplate, _lastVersion.File));
                updateForm.Show(MainForm.Instance);
            }
            else
                _lastVersion.Unwanted = true;
        }

        private static void CleanupBalloonTipClick(object sender, EventArgs e)
        {
            MainForm.Instance.NotifyIcon.BalloonTipClicked -= HandleBalloonTipClick;
            MainForm.Instance.NotifyIcon.BalloonTipClosed -= CleanupBalloonTipClick;
        }
    }
}