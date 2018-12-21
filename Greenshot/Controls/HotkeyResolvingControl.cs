using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Greenshot.Helpers;
using GreenshotPlugin.Core;

namespace Greenshot.Controls
{
    internal partial class HotkeyResolvingControl : UserControl
    {
        private const string EmptyHotkey = "[]";

        private readonly string _defaultHotkey;

        private int _blinkCount;

        public HotkeyAction Action { get; }

        public string Hotkey
        {
            get
            {
                if (retryRadioButton.Checked)
                    return _defaultHotkey;
                if (otherCombinationRadioButton.Checked)
                    return otherCombinationHotkeyControl.Text;

                return null;
            }
        }

        public HotkeyResolvingControl(HotkeyAction action, string actionText, string defaultHotkey)
            : this()
        {
            Action = action;
            actionLabel.Text = actionText ?? throw new ArgumentNullException(nameof(actionText));
            _defaultHotkey = defaultHotkey ?? throw new ArgumentNullException(nameof(defaultHotkey));

            hotkeyLabel.Text = defaultHotkey;
            retryRadioButton.Text = string.Format(CultureInfo.InvariantCulture,
                Language.GetString("hotkey_resolving_retry"), defaultHotkey);
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
                    mErrorProvider.SetError(otherCombinationHotkeyControl, "Value cannot be blank!");
                    return false;
                }
            }

            return true;
        }

        private void otherCombinationHotkeyControl_Enter(object sender, EventArgs e)
        {
            otherCombinationRadioButton.Checked = true;
            mErrorProvider.SetError(otherCombinationHotkeyControl, null);
        }

        private void otherCombinationHotkeyControl_TextChanged(object sender, EventArgs e)
        {
            if (otherCombinationRadioButton.Checked)
                hotkeyLabel.Text = string.IsNullOrEmpty(otherCombinationHotkeyControl.Text)
                    ? EmptyHotkey
                    : otherCombinationHotkeyControl.Text;
        }

        private void retryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (retryRadioButton.Checked)
                hotkeyLabel.Text = _defaultHotkey;
        }

        private void otherCombinationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (otherCombinationRadioButton.Checked)
            {
                hotkeyLabel.Text = string.IsNullOrEmpty(otherCombinationHotkeyControl.Text)
                    ? EmptyHotkey
                    : otherCombinationHotkeyControl.Text;

                otherCombinationHotkeyControl.Focus();
            }
            else
                mErrorProvider.SetError(otherCombinationHotkeyControl, null);
        }

        private void ignoreRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreRadioButton.Checked)
                hotkeyLabel.Text = EmptyHotkey;
        }

        private void mTimer_Tick(object sender, EventArgs e)
        {
            _blinkCount++;

            messageLabel.BackColor = _blinkCount % 2 > 0 ? Color.MistyRose : Color.White;

            if (_blinkCount > 15)
            {
                _blinkCount = 0;
                mTimer.Enabled = false;
            }
        }
    }
}