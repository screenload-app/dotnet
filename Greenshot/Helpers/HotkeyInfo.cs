using System;

namespace Greenshot.Helpers
{
    internal sealed class HotkeyInfo
    {
        private string _defaultHotkey;

        public HotkeyAction Action { get; }
        public string ActionText { get; }
        public string Hotkey { get; set; }

        public string DefaultHotkey
        {
            get => _defaultHotkey;
            set => _defaultHotkey = value ?? throw new ArgumentNullException(nameof(value));
        }

        public HotkeySolution Solution { get; set; }

        public HotkeyInfo(HotkeyAction action, string actionText, string defaultHotkey)
        {
            Action = action;
            ActionText = actionText ?? throw new ArgumentNullException(nameof(actionText));
            _defaultHotkey = defaultHotkey ?? throw new ArgumentNullException(nameof(defaultHotkey));
        }
    }
}