using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ScreenLoad.Helpers;
using ScreenLoadPlugin.Controls;
using ScreenLoadPlugin.Core;

namespace ScreenLoad.Controls
{
    internal partial class HotkeyResolvingControl : UserControl
    {
        private readonly bool _initializationComplete;

        private readonly HotkeyHelper _hotkeyHelper;
        private readonly HotkeyAction _hotkeyAction;

        public HotkeyResolvingControl(HotkeyHelper hotkeyHelper, HotkeyAction hotkeyAction)
            : this()
        {
            _hotkeyHelper = hotkeyHelper ?? throw new ArgumentNullException(nameof(hotkeyHelper));
            _hotkeyAction = hotkeyAction;

            var hotkeyInfo = _hotkeyHelper.GetHotkeyInfo(hotkeyAction);

            mGroupBox.Text = hotkeyInfo.ActionText;

            var defaultHotkeyText = HotkeyControl.GetLocalizedHotkeyStringFromString(hotkeyInfo.DefaultHotkey);
            defaultRadioButton.Text = string.Format(CultureInfo.InvariantCulture,
                Language.GetString("hotkey_resolving_retry"), defaultHotkeyText);

            switch (hotkeyInfo.Solution)
            {
                case HotkeySolution.Default:
                    defaultRadioButton.Checked = true;
                    break;
                case HotkeySolution.Custom:
                    otherCombinationRadioButton.Checked = true;
                    otherCombinationHotkeyControl.SetHotkey(hotkeyInfo.Hotkey);
                    break;
                case HotkeySolution.Disabled:
                    ignoreRadioButton.Checked = true;
                    break;
            }

            if (HotkeySolution.Unsolved == hotkeyInfo.Solution)
                Highlight();

            _initializationComplete = true;
        }

        public HotkeyResolvingControl()
        {
            InitializeComponent();
        }

        public bool Inspect()
        {
            if (otherCombinationRadioButton.Checked)
            {
                if (string.IsNullOrEmpty(otherCombinationHotkeyControl.Text))
                {
                    var emptyHotkeyErrorMessage = Language.GetString("empty_hotkey_error_message");
                    mErrorProvider.SetError(otherCombinationHotkeyControl, emptyHotkeyErrorMessage);
                    return false;
                }
            }

            return true;
        }

        private void defaultRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            if (!defaultRadioButton.Checked)
                return;

            defaultRadioButton.Checked = _hotkeyHelper.TrySetDefaultHotkey(this, _hotkeyAction);
            Highlight(!defaultRadioButton.Checked);
        }

        private void otherCombinationHotkeyControl_Enter(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            otherCombinationRadioButton.Checked = true;
            mErrorProvider.SetError(otherCombinationHotkeyControl, null);
        }

        private void otherCombinationHotkeyControl_TextChanged(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            if (!otherCombinationRadioButton.Checked)
                return;

            if (string.IsNullOrEmpty(otherCombinationHotkeyControl.Text))
                return;

            var hotkey = otherCombinationHotkeyControl.ToString();

            if (HotkeyHelper.IsNoneKey(hotkey))
            {
                otherCombinationHotkeyControl.Clear();
                return;
            }

            if (!_hotkeyHelper.TrySetHotkey(this, _hotkeyAction, hotkey))
            {
                var form = FindForm();

                if (form != null)
                    form.ActiveControl = (Control)form.AcceptButton;

                otherCombinationRadioButton.Checked = false;
                otherCombinationHotkeyControl.Clear();
            }

            Highlight(!otherCombinationRadioButton.Checked);
        }

        private void otherCombinationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            if (otherCombinationRadioButton.Checked)
                otherCombinationHotkeyControl.Focus();
            else
            {
                otherCombinationHotkeyControl.Clear();
                mErrorProvider.SetError(otherCombinationHotkeyControl, null);
            }
        }

        private void ignoreRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            if (ignoreRadioButton.Checked)
            {
                _hotkeyHelper.DisableHotkey(_hotkeyAction);
                Highlight(false);
            }
        }

        private void Highlight(bool highlight = true)
        {
            mGroupBox.ForeColor = highlight ? Color.Red : ForeColor;
        }
    }
}