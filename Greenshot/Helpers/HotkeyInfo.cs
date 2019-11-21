using System;
using System.Windows.Forms;
using GreenshotPlugin.Controls;

namespace Greenshot.Helpers
{
    internal sealed class HotkeyInfo
    {
        private string _hotkey;
        private HotkeySolution _solution;

        public HotkeyAction Action { get; }
        public string ActionText { get; }

        public string DefaultHotkey { get; }

        public string Hotkey
        {
            get
            {
                switch (Solution)
                {
                    case HotkeySolution.Unsolved:
                        return null;
                    case HotkeySolution.Disabled:
                        return HotkeyControl.HotkeyToString(Keys.None, Keys.None);
                    default:
                        return _hotkey;
                }
            }
            set
            {
                if (null == value)
                {
                    Solution = HotkeySolution.Unsolved;
                    _hotkey = null;

                    return;
                }

                if (HotkeyHelper.IsNoneKey(value))
                {
                    Solution = HotkeySolution.Disabled;
                    _hotkey = null;

                    return;
                }

                if (HotkeyHelper.Equals(DefaultHotkey, value))
                {
                    Solution = HotkeySolution.Default;
                    _hotkey = DefaultHotkey;

                    return;
                }

                Solution = HotkeySolution.Custom;
                _hotkey = value;
            }
        }

        public HotkeySolution Solution
        {
            get => _solution;
            set
            {
                switch (value)
                {
                    case HotkeySolution.Unsolved:
                        _hotkey = null;
                        break;
                    case HotkeySolution.Default:
                        _hotkey = DefaultHotkey;
                        break;
                    case HotkeySolution.Disabled:
                        _hotkey = HotkeyControl.HotkeyToString(Keys.None, Keys.None);
                        break;
                }

                _solution = value;
            }
        }

        public HotkeyInfo(HotkeyAction action, string actionText, string defaultHotkey)
        {
            Action = action;
            ActionText = actionText ?? throw new ArgumentNullException(nameof(actionText));
            DefaultHotkey = defaultHotkey ?? throw new ArgumentNullException(nameof(defaultHotkey));
        }
    }
}