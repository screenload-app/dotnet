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
    public enum UpdateRaised
    {
        Manually,
        AtStartup,
        AfterSaving,
        Timer
    }

    public sealed class VersionInfo
    {
        private const string DownloadLinkTemplate = "https://d2n4w7xg423fnr.cloudfront.net/temp/Nov2019/update/{0}";

        private const string DefaultLanguageKey = "en-US";

        private readonly Dictionary<string, string> _infoDictionary = new Dictionary<string, string>();

        public Version Version { get; private set; }
        public string File { get; protected set; }

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

        public string DownloadLink => string.Format(DownloadLinkTemplate, File);

        private VersionInfo()
        {
        }

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
                var locale = infoNode.Attributes["locale"]?.Value ?? DefaultLanguageKey;

                if (_infoDictionary.ContainsKey(locale))
                    continue;

                _infoDictionary.Add(locale, infoNode.InnerText);
            }
        }

        public static VersionInfo TryLoadFrom(CoreConfiguration configuration)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            VersionInfo versionInfo = null;

            // Доступ к конфигурации только в UI-потоке
            MainForm.Instance.InvokeAction(() =>
            {
                if (string.IsNullOrEmpty(configuration.LatestDetectedUpdateVersion) ||
                    string.IsNullOrEmpty(configuration.LatestDetectedUpdateFile))
                    return;

                versionInfo = new VersionInfo
                {
                    Version = new Version(configuration.LatestDetectedUpdateVersion),
                    File = configuration.LatestDetectedUpdateFile
                };

                if (null != configuration.LatestDetectedUpdateDescriptions)
                {
                    foreach (var description in configuration.LatestDetectedUpdateDescriptions)
                    {
                        // TODO $ Затрем, если в тексте будет комбинация символов "\r"
                        var unescapedValue = description.Value.Replace("\\n", "\n").Replace("\\r", "\r");
                        versionInfo._infoDictionary.Add(description.Key, unescapedValue);
                    }
                }
            });

            return versionInfo;
        }

        public void SaveTo(CoreConfiguration configuration)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));
            
            var escapedDescriptions = new Dictionary<string, string>();

            foreach (var keyValue in _infoDictionary)
            {
                var escapedValue = keyValue.Value.Replace("\r", "\\r").Replace("\n", "\\n");
                escapedDescriptions.Add(keyValue.Key, escapedValue);
            }

            // Доступ к конфигурации только в UI-потоке
            MainForm.Instance.InvokeAction(() =>
            {
                configuration.LatestDetectedUpdateVersion = Version.ToString();
                configuration.LatestDetectedUpdateFile = File;
                configuration.LatestDetectedUpdateDescriptions = escapedDescriptions;
            });
        }
    }

    public static class UpdateHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpdateHelper));
        private static readonly CoreConfiguration CoreConfig = IniConfig.GetIniSection<CoreConfiguration>();

        private const string VersionHistoryLink = "https://d2n4w7xg423fnr.cloudfront.net/temp/Nov2019/update/VersionHistory.xml";

        private static readonly object LockObject = new object();

        private static volatile bool _updateInProgress;

        private static Version _currentVersion;

        private static Version CurrentVersion
        {
            get
            {
                lock (LockObject)
                {
                    if (null == _currentVersion)
                        _currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                    return _currentVersion;
                }
            }
        }

        public static VersionInfo LastVersion { get; private set; }

        public static bool IsUpdateDetected(CoreConfiguration configuration)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            lock (LockObject)
            {
                if (null == LastVersion)
                    LastVersion = VersionInfo.TryLoadFrom(configuration);

                if (null == LastVersion)
                    return false;

                return LastVersion.Version > CurrentVersion;
            }
        }

        public static void CheckAndAskForUpdateInThread(UpdateRaised updateRaised, CoreConfiguration configuration,
            int millisecondsTimeout = 0, Action<bool> continueWith = null)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            var thread = new Thread(() =>
            {
                bool updatesFound = CheckAndAskForUpdate(updateRaised, configuration, millisecondsTimeout);
                continueWith?.Invoke(updatesFound);
            })
            {
                IsBackground = true
            };

            thread.Start();
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

        private static bool CheckAndAskForUpdate(UpdateRaised updateRaised, CoreConfiguration configuration, int millisecondsTimeout)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            lock (LockObject)
            {
                if (_updateInProgress)
                    return false;

                _updateInProgress = true;
            }

            if (!IsUpdateCheckNeeded(updateRaised))
            {
                lock (LockObject)
                {
                    _updateInProgress = false;
                }

                return false;
            }

            if (0 != millisecondsTimeout)
                Thread.Sleep(millisecondsTimeout);

            try
            {
                VersionInfo lastVersion;

                using (var webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;

                    var versionHistoryText = webClient.DownloadString(new Uri(VersionHistoryLink));

                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(versionHistoryText);

                    bool checkForUnstable = false;

                    MainForm.Instance.InvokeAction(() => { checkForUnstable = configuration.CheckForUnstable; });

                    var xPath = checkForUnstable ? "version" : "version[@type='release']";

                    var versionNodes = xmlDocument.DocumentElement?.SelectNodes(xPath);

                    if (null == versionNodes)
                        throw new InvalidOperationException("null == versionNodes");

                    var versionInfoList = versionNodes.Cast<XmlNode>().Select(vn => new VersionInfo(vn));

                    lastVersion = versionInfoList.OrderByDescending(vi => vi.Version).First();
                }

                lock (LockObject)
                {
                    LastVersion = lastVersion;
                    LastVersion.SaveTo(configuration);
                }
                
                MainForm.Instance.OnUpdateStateChanged(); // Оповещаем о наличии обновления

                if (LastVersion.Version <= CurrentVersion)
                {
                    lock (LockObject)
                    {
                        _updateInProgress = false;
                    }

                    return false;
                }

                new Thread(() =>
                    {
                        try
                        {
                            UpdateForm.ShowSingle(UpdateRaised.Manually == updateRaised);
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

        private static bool IsUpdateCheckNeeded(UpdateRaised updateRaised)
        {
            if (UpdateRaised.Manually == updateRaised)
                return true;

            bool isUpdateCheckNeeded = false;

            // Работа с конфигом - в UI-потоке
            MainForm.Instance.InvokeAction(() =>
            {
                if (!CoreConfig.CheckUpdatesAuto)
                    return;

                if (CoreConfig.PostponeUpdateMode == PostponeUpdateMode.Hour &&
                    CoreConfig.LastUpdateCheck.AddHours(1) >= DateTime.Now)
                    return;

                if (CoreConfig.PostponeUpdateMode == PostponeUpdateMode.Day &&
                    CoreConfig.LastUpdateCheck.AddDays(1) >= DateTime.Now)
                    return;

                // Сброс паузы (чтобы лишний раз не проверять)
                CoreConfig.PostponeUpdateMode = PostponeUpdateMode.None;
                CoreConfig.LastUpdateCheck = DateTime.Now;

                switch (updateRaised)
                {
                    case UpdateRaised.AtStartup:
                        isUpdateCheckNeeded = CoreConfig.CheckUpdatesAuto && CoreConfig.CheckUpdatesAtStartup;
                        break;
                    case UpdateRaised.AfterSaving:
                        isUpdateCheckNeeded = CoreConfig.CheckUpdatesAuto && CoreConfig.CheckUpdatesAfterSaving;
                        break;
                    case UpdateRaised.Timer:
                        isUpdateCheckNeeded = CoreConfig.CheckUpdatesAuto && CoreConfig.CheckUpdatesOnceADay &&
                               CoreConfig.LastUpdateCheck.AddDays(1) <= DateTime.Now;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(updateRaised), updateRaised, null);
                }
            });

            return isUpdateCheckNeeded;
        }
    }
}