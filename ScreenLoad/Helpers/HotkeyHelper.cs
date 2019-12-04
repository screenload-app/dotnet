using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ScreenLoad.IniFile;
using ScreenLoad.Plugin;
using ScreenLoadPlugin.Controls;
using ScreenLoadPlugin.Core;
using log4net;

namespace ScreenLoad.Helpers
{
    internal sealed class HotkeyHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HotkeyHelper));

        private readonly CoreConfiguration _coreConfiguration;
        private readonly List<HotkeyInfo> _hotkeyInfoList;

        public IList<HotkeyInfo> HotkeyInfoList => _hotkeyInfoList;

        public HotkeyHelper(CoreConfiguration coreConfiguration)
        {
            _coreConfiguration = coreConfiguration ?? throw new ArgumentNullException(nameof(coreConfiguration));
            _hotkeyInfoList = new List<HotkeyInfo>();

            var hotkeyActions = Enum.GetValues(typeof(HotkeyAction));

            foreach (HotkeyAction hotkeyAction in hotkeyActions)
            {
                var textKey = GetTextKey(hotkeyAction);
                var text = Language.GetString(textKey);

                var configurationKey = GetConfigurationKey(hotkeyAction);
                var defaultHotkey = (string) _coreConfiguration.Values[configurationKey].GetDefaultValue();

                _hotkeyInfoList.Add(new HotkeyInfo(hotkeyAction, text, defaultHotkey));
            }

            FillSolutionsFromConfiguration();
        }

        public void RegisterHotkeys(IWin32Window owner)
        {
            if (null == owner)
                throw new ArgumentNullException(nameof(owner));

            HotkeyControl.UnregisterHotkeys();

            FillSolutionsFromConfiguration();

            // Пытаемся регистрировать и устанавливаем Unsolved, если не получилось.
            foreach (var hotkeyInfo in _hotkeyInfoList)
            {
                if (IsNoneKey(hotkeyInfo.Hotkey))
                {
                    hotkeyInfo.Solution = HotkeySolution.Disabled;
                    continue;
                }

                if (!TryRegisterHotkey(hotkeyInfo.Action, hotkeyInfo.Hotkey))
                {
                    hotkeyInfo.Solution = HotkeySolution.Unsolved;
                    continue;
                }

                if (!Equals(hotkeyInfo.DefaultHotkey, hotkeyInfo.Hotkey))
                {
                    hotkeyInfo.Solution = HotkeySolution.Custom;
                    continue;
                }

                hotkeyInfo.Solution = HotkeySolution.Default;
            }

            // Форма разрешения конфликтов (если нужно).
            if (_hotkeyInfoList.All(hi => hi.Solution != HotkeySolution.Unsolved))
                return;
            
            var hotkeysResolvingForm = new HotkeysResolvingForm(this);
            hotkeysResolvingForm.ShowDialog(owner);

            // Обновляем конфигурацию на основе выбора пользователя.
            foreach (var hotkeyInfo in _hotkeyInfoList)
            {
                var configurationKey = GetConfigurationKey(hotkeyInfo.Action);
                var hotkeyValue = _coreConfiguration.Values[configurationKey];

                switch (hotkeyInfo.Solution)
                {
                    case HotkeySolution.Default:
                        hotkeyValue.Value = hotkeyInfo.DefaultHotkey;
                        break;
                    case HotkeySolution.Custom:
                        hotkeyValue.Value = hotkeyInfo.Hotkey;
                        break;
                    default:
                        hotkeyValue.Value = Keys.None.ToString();
                        break;
                }
            }

            IniConfig.Save();
        }

        public bool TrySetDefaultHotkey(IWin32Window owner, HotkeyAction hotkeyAction)
        {
            var hotkeyInfo = GetHotkeyInfo(hotkeyAction);

            if (HotkeySolution.Default == hotkeyInfo.Solution)
                return true;

            var internalConflictHotkeyInfo = _hotkeyInfoList.FirstOrDefault(hi =>
                hi.Solution == HotkeySolution.Custom && Equals(hi.Hotkey, hotkeyInfo.DefaultHotkey));

            if (null != internalConflictHotkeyInfo)
            {
                ShowConflictMessage(owner, internalConflictHotkeyInfo.ActionText);
                return false;
            }

            if (HotkeySolution.Custom == hotkeyInfo.Solution)
                UnregisterHotkey(hotkeyInfo.Hotkey);

            if (!TryRegisterHotkey(hotkeyInfo.Action, hotkeyInfo.DefaultHotkey))
            {
                ShowConflictMessage(owner);
                return false;
            }

            hotkeyInfo.Solution = HotkeySolution.Default;
            return true;
        }

        public bool TrySetHotkey(IWin32Window owner, HotkeyAction hotkeyAction, string hotkey)
        {
            var hotkeyInfo = GetHotkeyInfo(hotkeyAction);

            if (null == hotkey)
                hotkey = HotkeyControl.HotkeyToString(Keys.None, Keys.None);

            if (IsNoneKey(hotkey))
            {
                hotkeyInfo.Solution = HotkeySolution.Disabled;
                return true;
            }

            if (HotkeySolution.Custom == hotkeyInfo.Solution && Equals(hotkey, hotkeyInfo.Hotkey))
                return true;

            if (Equals(hotkey, hotkeyInfo.DefaultHotkey))
                return TrySetDefaultHotkey(owner, hotkeyAction);

            var internalConflictHotkeyInfo = _hotkeyInfoList.FirstOrDefault(hi =>
                hi.Solution == HotkeySolution.Custom && Equals(hi.Hotkey, hotkey) ||
                hi.Solution == HotkeySolution.Default && Equals(hi.DefaultHotkey, hotkey));

            if (null != internalConflictHotkeyInfo)
            {
                ShowConflictMessage(owner, internalConflictHotkeyInfo.ActionText);
                return false;
            }

            if (HotkeySolution.Default == hotkeyInfo.Solution)
                UnregisterHotkey(hotkeyInfo.DefaultHotkey);

            if (HotkeySolution.Custom == hotkeyInfo.Solution)
                UnregisterHotkey(hotkeyInfo.Hotkey);

            if (!TryRegisterHotkey(hotkeyInfo.Action, hotkey))
            {
                ShowConflictMessage(owner);
                return false;
            }

            hotkeyInfo.Solution = HotkeySolution.Custom;
            hotkeyInfo.Hotkey = hotkey;

            return true;
        }

        public void DisableHotkey(HotkeyAction hotkeyAction)
        {
            var hotkeyInfo = GetHotkeyInfo(hotkeyAction);

            switch (hotkeyInfo.Solution)
            {
                case HotkeySolution.Default:
                    UnregisterHotkey(hotkeyInfo.DefaultHotkey);
                    break;
                case HotkeySolution.Custom:
                    UnregisterHotkey(hotkeyInfo.Hotkey);
                    break;
            }

            hotkeyInfo.Solution = HotkeySolution.Disabled;
        }

        public HotkeyInfo GetHotkeyInfo(HotkeyAction hotkeyAction)
        {
            return _hotkeyInfoList.First(hi => hi.Action == hotkeyAction);
        }

        public bool HasUnsolved()
        {
            foreach (var hotkeyInfo in _hotkeyInfoList)
            {
                if (HotkeySolution.Unsolved == hotkeyInfo.Solution)
                    return true;
            }

            return false;
        }

        public void AllUnsolvedToDisabled()
        {
            foreach (var hotkeyInfo in _hotkeyInfoList)
            {
                if (HotkeySolution.Unsolved == hotkeyInfo.Solution)
                    hotkeyInfo.Solution = HotkeySolution.Disabled;
            }
        }

        public static bool IsNoneKey(string hotkeyString)
        {
            if (null == hotkeyString)
                throw new ArgumentNullException(nameof(hotkeyString));

            var virtualKeyCode = HotkeyControl.HotkeyFromString(hotkeyString);

            if (Keys.None.Equals(virtualKeyCode))
                return true;

            return false;
        }

        public static bool Equals(string leftHotkeyString, string rightHotkeyString)
        {
            if (null == leftHotkeyString)
                throw new ArgumentNullException(nameof(leftHotkeyString));

            if (null == rightHotkeyString)
                throw new ArgumentNullException(nameof(rightHotkeyString));

            var leftModifierKeyCode = HotkeyControl.HotkeyModifiersFromString(leftHotkeyString);
            var leftVirtualKeyCode = HotkeyControl.HotkeyFromString(leftHotkeyString);

            var rightModifierKeyCode = HotkeyControl.HotkeyModifiersFromString(rightHotkeyString);
            var rightVirtualKeyCode = HotkeyControl.HotkeyFromString(rightHotkeyString);

            if (leftModifierKeyCode != rightModifierKeyCode)
                return false;

            if (leftVirtualKeyCode != rightVirtualKeyCode)
                return false;

            return true;
        }

        public static bool TryRegisterHotkey(HotkeyAction action, string hotkeyString)
        {
            if (null == hotkeyString)
                throw new ArgumentNullException(nameof(hotkeyString));

            var modifierKeyCode = HotkeyControl.HotkeyModifiersFromString(hotkeyString);
            var virtualKeyCode = HotkeyControl.HotkeyFromString(hotkeyString);

            if (Keys.None.Equals(virtualKeyCode))
                return false;

            var handler = GetHandler(action);

            try
            {
                if (HotkeyControl.RegisterHotKey(modifierKeyCode, virtualKeyCode, handler) < 0)
                    return false;
            }
            catch (Exception exception)
            {
                Log.Warn(exception);
                return false;
            }

            return true;
        }

        public static void UnregisterHotkey(string hotkeyString)
        {
            if (null == hotkeyString)
                throw new ArgumentNullException(nameof(hotkeyString));

            var modifierKeyCode = HotkeyControl.HotkeyModifiersFromString(hotkeyString);
            var virtualKeyCode = HotkeyControl.HotkeyFromString(hotkeyString);

            if (Keys.None.Equals(virtualKeyCode))
                return;

            HotkeyControl.UnregisterHotkey(modifierKeyCode, virtualKeyCode);
        }

        private static void ShowConflictMessage(IWin32Window owner, string internalConflictActionText = null)
        {
            var conflictHotkeyErrorMessage = null == internalConflictActionText
                ? Language.GetString("hotkey_external_conflict_message")
                : Language.GetFormattedString("hotkey_internal_conflict_message", internalConflictActionText);

            MessageBox.Show(owner, conflictHotkeyErrorMessage, "ScreenLoad", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void FillSolutionsFromConfiguration()
        {
            foreach (var hotkeyInfo in _hotkeyInfoList)
            {
                var configurationKey = GetConfigurationKey(hotkeyInfo.Action);
                hotkeyInfo.Hotkey = (string)_coreConfiguration.Values[configurationKey].Value;
            }
        }

        private static string GetConfigurationKey(HotkeyAction action)
        {
            switch (action)
            {
                case HotkeyAction.CaptureFullScreen:
                    return "FullscreenHotkey";
                case HotkeyAction.CaptureWindow:
                    return "WindowHotkey";
                case HotkeyAction.CaptureArea:
                    return "RegionHotkey";
                case HotkeyAction.CaptureLastRegion:
                    return "LastregionHotkey";
                case HotkeyAction.CaptureIE:
                    return "IEHotkey";
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), $@"action={action}");
            }
        }

        private static string GetTextKey(HotkeyAction action)
        {
            switch (action)
            {
                case HotkeyAction.CaptureArea:
                    return "capture_region";
                case HotkeyAction.CaptureWindow:
                    return "capture_window";
                case HotkeyAction.CaptureFullScreen:
                    return "capture_fullscreen";
                case HotkeyAction.CaptureLastRegion:
                    return "capture_last_region";
                case HotkeyAction.CaptureIE:
                    return "capture_ie";
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), $@"action={action}");
            }
        }

        private static HotKeyHandler GetHandler(HotkeyAction action)
        {
            switch (action)
            {
                case HotkeyAction.CaptureArea:
                    return CaptureHelper.CaptureRegion;
                case HotkeyAction.CaptureWindow:
                    return CaptureHelper.CaptureWindow;
                case HotkeyAction.CaptureFullScreen:
                    return CaptureHelper.CaptureFullScreen;
                case HotkeyAction.CaptureLastRegion:
                    return CaptureHelper.CaptureLastRegion;
                case HotkeyAction.CaptureIE:
                    return CaptureHelper.CaptureIE;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), $@"action={action}");
            }
        }
    }
}