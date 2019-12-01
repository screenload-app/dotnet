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

    public enum UpdateCheckingResult
    {
        Found,
        NotFound,
        Skipped,
        Busy,
        Error
    }

    public sealed class VersionInfo
    {
        private const string DownloadLinkTemplate = "https://d2n4w7xg423fnr.cloudfront.net/temp/Nov2019/update/{0}";

        private const string DefaultLanguageKey = "en-US";

        private readonly Dictionary<string, string> _infoDictionary = new Dictionary<string, string>();

        public Version Version { get; private set; }
        public string File { get; private set; }

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

        public static VersionInfo TryLoadFrom(CoreConfiguration configuration, bool stable)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            VersionInfo versionInfo = null;

            // Доступ к конфигурации только в UI-потоке
            MainForm.Instance.InvokeAction(() =>
            {
                string version;
                string file;
                Dictionary<string, string> descriptions;

                if (stable)
                {
                    version = configuration.LatestDetectedStableUpdateVersion;
                    file = configuration.LatestDetectedStableUpdateFile;
                    descriptions = configuration.LatestDetectedStableUpdateDescriptions;
                }
                else
                {
                    version = configuration.LatestDetectedUpdateVersion;
                    file = configuration.LatestDetectedUpdateFile;
                    descriptions = configuration.LatestDetectedUpdateDescriptions;
                }

                if (string.IsNullOrEmpty(version) ||
                    string.IsNullOrEmpty(file))
                    return;

                versionInfo = new VersionInfo
                {
                    Version = new Version(version),
                    File = file
                };

                if (null != descriptions)
                {
                    foreach (var description in descriptions)
                    {
                        var unescapedValue = Unescape(description.Value);
                        versionInfo._infoDictionary.Add(description.Key, unescapedValue);
                    }
                }
            });

            return versionInfo;
        }

        public void SaveTo(CoreConfiguration configuration, bool stable)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));
            
            var escapedDescriptions = new Dictionary<string, string>();

            foreach (var keyValue in _infoDictionary)
            {
                var escapedValue = Escape(keyValue.Value);
                escapedDescriptions.Add(keyValue.Key, escapedValue);
            }

            // Доступ к конфигурации только в UI-потоке
            MainForm.Instance.InvokeAction(() =>
            {
                if (stable)
                {

                    configuration.LatestDetectedStableUpdateVersion = Version.ToString();
                    configuration.LatestDetectedStableUpdateFile = File;
                    configuration.LatestDetectedStableUpdateDescriptions = escapedDescriptions;

                    return;
                }

                configuration.LatestDetectedUpdateVersion = Version.ToString();
                configuration.LatestDetectedUpdateFile = File;
                configuration.LatestDetectedUpdateDescriptions = escapedDescriptions;
            });
        }

        private static string Escape(string value)
        {
            return value?.Replace("\\", "\\\\").Replace("\r", "\\r").Replace("\n", "\\n");
        }

        public static string Unescape(string value)
        {
            if (null == value)
                return null;

            var parts = value.Split(new[] {"\\\\"}, StringSplitOptions.None)
                .Select(part => part.Replace("\\n", "\n").Replace("\\r", "\r"))
                .ToArray();

            return string.Join("\\", parts);
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

        private static VersionInfo _latestVersion;
        private static VersionInfo _latestStableVersion;

        public static bool IsUpdateDetected(CoreConfiguration configuration)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            InitIfNeeded(configuration);

            bool checkForUnstable = false;

            // Доступ к параметрам конфигурации - только в UI-потоке.
            MainForm.Instance.InvokeAction(() =>
            {
                checkForUnstable = configuration.CheckForUnstable;
            });

            bool detected;

            lock (LockObject)
            {
                var version = checkForUnstable ? _latestVersion?.Version : _latestStableVersion?.Version;

                if (null == version)
                    return false;

                detected = version > CurrentVersion;
            }

            return detected;
        }

        public static VersionInfo GetActualUpdateVersionInfo(CoreConfiguration configuration)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            InitIfNeeded(configuration);

            bool checkForUnstable = false;

            // Доступ к параметрам конфигурации - только в UI-потоке.
            MainForm.Instance.InvokeAction(() =>
            {
                checkForUnstable = configuration.CheckForUnstable;
            });

            VersionInfo versionInfo;

            lock (LockObject)
            {
                versionInfo = checkForUnstable ? _latestVersion : _latestStableVersion;
            }

            return versionInfo;
        }

        public static void CheckAndAskForUpdateInThread(UpdateRaised updateRaised, CoreConfiguration configuration,
            int millisecondsTimeout = 0, Action<UpdateCheckingResult> continueWith = null)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            var thread = new Thread(() =>
            {
                var checkingResult = CheckAndAskForUpdate(updateRaised, configuration, millisecondsTimeout);
                continueWith?.Invoke(checkingResult);
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

        private static void InitIfNeeded(CoreConfiguration configuration)
        {
            bool initializationNeeded;

            lock (LockObject)
            {
                initializationNeeded = null == _latestStableVersion && null == _latestVersion;
            }

            if (initializationNeeded)
            {
                VersionInfo latestStableVersion = null;
                VersionInfo latestVersion = null;

                // Доступ к параметрам конфигурации - только в UI-потоке.
                MainForm.Instance.InvokeAction(() =>
                {
                    latestStableVersion = VersionInfo.TryLoadFrom(configuration, true);
                    latestVersion = VersionInfo.TryLoadFrom(configuration, false);
                });

                lock (LockObject)
                {
                    if (null == _latestStableVersion && null == _latestVersion)
                    {
                        _latestStableVersion = latestStableVersion;
                        _latestVersion = latestVersion;
                    }
                }
            }
        }

        private static UpdateCheckingResult CheckAndAskForUpdate(UpdateRaised updateRaised, CoreConfiguration configuration, int millisecondsTimeout)
        {
            if (null == configuration)
                throw new ArgumentNullException(nameof(configuration));

            lock (LockObject)
            {
                if (_updateInProgress)
                    return UpdateCheckingResult.Busy;

                _updateInProgress = true;
            }

            if (!IsUpdateCheckNeeded(updateRaised))
            {
                lock (LockObject)
                {
                    _updateInProgress = false;
                }

                return UpdateCheckingResult.Skipped;
            }

            if (0 != millisecondsTimeout)
                Thread.Sleep(millisecondsTimeout);

            VersionInfo latestVersion;
            VersionInfo latestStableVersion;

            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;

                string versionHistoryText;

                try
                {
                    versionHistoryText = webClient.DownloadString(new Uri(VersionHistoryLink));
                }
                catch (WebException exception)
                {
                    Log.Error("An error occured while checking for updates, the error will be ignored: ", exception);

                    MainForm.Instance.InvokeAction(() =>
                    {
                        if (MainForm.Instance.IsDisposed)
                            return;

                        MainForm.Instance.NotifyIcon.ShowBalloonTip(10000, "Greenshot", exception.Message,
                            ToolTipIcon.Error);
                    });

                    lock (LockObject)
                    {
                        _updateInProgress = false;
                    }

                    return UpdateCheckingResult.Error;
                }

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(versionHistoryText);

                VersionInfo SelectVersionInfo(bool stable)
                {
                    var xPath = stable ? "version[@type='release']" : "version";

                    var versionNodes = xmlDocument.DocumentElement?.SelectNodes(xPath);

                    if (null == versionNodes)
                        throw new InvalidOperationException("null == versionNodes");

                    var versionInfoList = versionNodes.Cast<XmlNode>().Select(vn => new VersionInfo(vn));

                    return versionInfoList.OrderByDescending(vi => vi.Version).First();
                }

                latestVersion = SelectVersionInfo(false);
                latestStableVersion = SelectVersionInfo(true);
            }

            lock (LockObject)
            {
                _latestVersion = latestVersion;
                _latestStableVersion = latestStableVersion;
            }

            latestVersion?.SaveTo(configuration, false);
            latestStableVersion?.SaveTo(configuration, true);

            MainForm.Instance.OnUpdateStateChanged(); // Оповещаем о наличии обновления

            bool checkForUnstable = false;

            // Доступ к параметрам конфигурации - только в UI-потоке.
            MainForm.Instance.InvokeAction(() =>
            {
                checkForUnstable = configuration.CheckForUnstable;
            });

            if (checkForUnstable && null != latestVersion && latestVersion.Version <= CurrentVersion ||
                !checkForUnstable && null != latestStableVersion && latestStableVersion.Version <= CurrentVersion)
            {
                lock (LockObject)
                {
                    _updateInProgress = false;
                }

                return UpdateCheckingResult.NotFound;
            }

            UpdateForm.ShowSingle(UpdateRaised.Manually == updateRaised);

            lock (LockObject)
            {
                _updateInProgress = false;
            }

            return UpdateCheckingResult.Found;
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