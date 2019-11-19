using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using GreenshotPlugin.Core;
using log4net;
using Microsoft.Win32;
using RegistryUtils;

namespace Greenshot.Helpers
{
    internal sealed class NotifyIconHelper : IDisposable
    {
        private const string PersonalizeRegistryKey = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        private static readonly ILog Log = LogManager.GetLogger(typeof(NotifyIconHelper));

        private readonly NotifyIcon _notifyIcon;

        private bool _systemSupportsThemes;
        private RegistryMonitor _registryMonitor;

        public NotifyIconHelper(NotifyIcon notifyIcon)
        {
            _notifyIcon = notifyIcon ?? throw new ArgumentNullException(nameof(notifyIcon));
            SetNotifyIcon();

            if (_systemSupportsThemes)
                StartThemeWatcher();
        }

        private void SetNotifyIcon()
        {
            RegistryKey personalizeKey = null;
            int? systemUsesLightTheme;

            try
            {
                personalizeKey =
                    Registry.CurrentUser.OpenSubKey(PersonalizeRegistryKey);
                systemUsesLightTheme = personalizeKey?.GetValue("SystemUsesLightTheme") as int?;
            }
            catch (SecurityException exception)
            {
                Log.Error(exception.Message, exception);
                systemUsesLightTheme = null;
            }
            finally
            {
                personalizeKey?.Close();
            }

            Icon themeIcon = null;

            if (systemUsesLightTheme.HasValue)
            {
                switch (systemUsesLightTheme.Value)
                {
                    case 0:
                        themeIcon = GreenshotResources.GetWhiteNotifyIcon();
                        break;
                    case 1:
                        themeIcon = GreenshotResources.GetDarkNotifyIcon();
                        break;
                }
            }

            if (null == themeIcon)
            {
                _notifyIcon.Icon = GreenshotResources.GetClassicNotifyIcon();
                return;
            }

            _notifyIcon.Icon = themeIcon;
            _systemSupportsThemes = true;
        }

        private void StartThemeWatcher()
        {
            _registryMonitor = new RegistryMonitor(RegistryHive.CurrentUser, PersonalizeRegistryKey);

            _registryMonitor.RegChanged += (sender, args) =>
            {
                // Можно вызывать в фоновом потоке: https://social.msdn.microsoft.com/Forums/windows/en-US/a2a3c9e2-40ea-4d77-ba51-448dc79fc54e/notifyicon-can-background-thread-update-it?forum=winforms
                SetNotifyIcon();
            };

            _registryMonitor.Error += (sender, args) =>
            {
                var exception = args.GetException();
                Log.Error(exception.Message, exception);
            };

            _registryMonitor.Start();
        }

        public void Dispose()
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();

            _registryMonitor?.Dispose();
        }
    }
}
