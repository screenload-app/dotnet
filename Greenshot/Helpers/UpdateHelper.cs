using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Greenshot.IniFile;
using GreenshotPlugin.Core;
using log4net;

namespace Greenshot.Helpers
{
    public sealed class VersionInfo
    {
        private const string DefaultLanguageKey = "en-US";

        private readonly Dictionary<string, string> _infoDictionary = new Dictionary<string, string>();

        public Version Version { get; }
        public string File { get; }

        public string Info
        {
            get
            {
                if (_infoDictionary.ContainsKey(Language.CurrentLanguage))
                    return _infoDictionary[Language.CurrentLanguage];

                if (_infoDictionary.ContainsKey(DefaultLanguageKey))
                    return _infoDictionary[DefaultLanguageKey];

                return null;
            }
        }

        public string DownloadLink { get; set; }

        public bool Unwanted { get; set; }

        public VersionInfo(XmlNode xmlNode)
        {
            if (null == xmlNode)
                throw new ArgumentNullException(nameof(xmlNode));

            var numberValue = xmlNode.Attributes?["number"].Value;

            if (null == numberValue)
                throw new InvalidOperationException("null == numberValue");

            Version = new Version(numberValue);

            var file = xmlNode.Attributes?["file"].Value;
            File = file ?? throw new InvalidOperationException("null == file");

            var infoNodes = xmlNode.SelectNodes("info");
            
            if (null == infoNodes)
                return;

            foreach (XmlElement infoNode in  infoNodes)
            {
                var locale = infoNode.Attributes["locale"]?.Value;

                if (null == locale)
                    locale = DefaultLanguageKey;

                if (_infoDictionary.ContainsKey(locale))
                    continue;

                _infoDictionary.Add(locale, infoNode.InnerText);
            }
        }
    }

    public static class UpdateHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpdateHelper));
        private static readonly CoreConfiguration CoreConfig = IniConfig.GetIniSection<CoreConfiguration>();

        private const string VersionHistoryLink = "https://d2n4w7xg423fnr.cloudfront.net/temp/Nov2019/update/VersionHistory.xml";
        public const string DownloadLinkTemplate = "https://d2n4w7xg423fnr.cloudfront.net/temp/Nov2019/update/{0}";

        private static readonly object LockObject = new object();

        private static volatile bool _updateInProgress;
        private static VersionInfo _lastVersion;

        /// <summary>
        /// Is an update check needed?
        /// </summary>
        /// <returns>bool true if yes</returns>
        public static bool IsUpdateCheckNeeded()
        {
            if (CoreConfig.UpdateCheckInterval == 0)
                return false;

            var lastUpdateCheck = CoreConfig.LastUpdateCheck;
            lastUpdateCheck = lastUpdateCheck.AddDays(CoreConfig.UpdateCheckInterval);

            if (DateTime.Now.CompareTo(lastUpdateCheck) < 0)
                return false;

            return true;
        }

        public static void CheckAndAskForUpdateInThread(CoreConfiguration configuration, int millisecondsTimeout = 0)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            var thread = new Thread(() =>
            {
                CheckAndAskForUpdate(configuration, millisecondsTimeout);
            })
            {
                IsBackground = true
            };

            thread.Start();
        }

        public static bool CheckAndAskForUpdate(CoreConfiguration configuration)
        {
            return CheckAndAskForUpdate(configuration, 0);
        }

        public static void RunUpdate(string tempFilePath)
        {
            if (null == tempFilePath)
                throw new ArgumentNullException(nameof(tempFilePath));

            var thread = new Thread(o =>
            {
                Thread.Sleep(500); // ждем, пока приложение закроется...

                var argument = (string[]) o;

                var filePath = argument[0];
                var language = argument[1];

                // http://www.jrsoftware.org/ishelp/index.php?topic=setupcmdline
                var startInfo = new ProcessStartInfo
                {
                    Arguments = $"/SILENT /LANG={language}",
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

            var cultureInfo = new CultureInfo(Language.CurrentLanguage);

            thread.Start(new[]
            {
                tempFilePath,
                cultureInfo.TwoLetterISOLanguageName
            });
        }

        private static bool CheckAndAskForUpdate(CoreConfiguration configuration, int millisecondsTimeout)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            lock (LockObject)
            {
                if (_updateInProgress)
                    return false;

                _updateInProgress = true;
            }

            if (0 != millisecondsTimeout)
            {
                Thread.Sleep(millisecondsTimeout);
            }

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

                    var xPath = configuration.CheckForUnstable ? "version" : "version[@type='release']";

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
                    {
                        lock (LockObject)
                        {
                            _updateInProgress = false;
                        }

                        return false; // Уже оповещали
                    }

                    _lastVersion = lastVersion;
                }

                if (_lastVersion.Version <= currentVersion)
                {
                    lock (LockObject)
                    {
                        _updateInProgress = false;
                    }

                    return false;
                }

                _lastVersion.DownloadLink = string.Format(CultureInfo.InvariantCulture, DownloadLinkTemplate,
                    _lastVersion.File);

                CoreConfig.LastUpdateCheck = DateTime.Now;

                new Thread(() =>
                    {
                        try
                        {
                            UpdateForm.ShowSingle(_lastVersion);
                        }
                        catch (Exception exception)
                        {
                            Log.Error(exception);
                            MessageBox.Show(exception.Message, "Greenshot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    })
                {
                    IsBackground = true
                }.Start();

                lock (LockObject)
                {
                    _updateInProgress = false;
                }

                return true;
            }
            catch (Exception exception)
            {
                Log.Error("An error occured while checking for updates, the error will be ignored: ", exception);
                MessageBox.Show(exception.Message, "Greenshot", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lock (LockObject)
                {
                    _updateInProgress = false;
                }

                return false;
            }
        }
    }
}