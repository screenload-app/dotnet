using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using ScreenLoad.Controls;
using ScreenLoad.Helpers;
using ScreenLoadPlugin.Core;

namespace ScreenLoad
{
    internal partial class HotkeysResolvingForm : BaseForm
    {
        private readonly ReadOnlyCollection<HotkeyResolvingControl> _hotkeyResolvingControls;
        private readonly HotkeyHelper _hotkeyHelper;

        public HotkeysResolvingForm(HotkeyHelper hotkeyHelper)
            : this()
        {
            _hotkeyHelper = hotkeyHelper ?? throw new ArgumentNullException(nameof(hotkeyHelper));

            var hotkeyResolvingControls = new List<HotkeyResolvingControl>();

            conflictsFlowLayoutPanel.SuspendLayout();
            mFlowLayoutPanel.SuspendLayout();
            SuspendLayout();

            foreach (var hotkeyInfo in hotkeyHelper.HotkeyInfoList)
            {
                //if (HotkeySolution.Unsolved != hotkeyInfo.Solution)
                //    continue;

                var hotkeyResolvingControl = new HotkeyResolvingControl(hotkeyHelper, hotkeyInfo.Action);

                hotkeyResolvingControls.Add(hotkeyResolvingControl);
                conflictsFlowLayoutPanel.Controls.Add(hotkeyResolvingControl);
            }

            conflictsFlowLayoutPanel.ResumeLayout(true);
            mFlowLayoutPanel.ResumeLayout(true);
            ResumeLayout(true);

            _hotkeyResolvingControls = new ReadOnlyCollection<HotkeyResolvingControl>(hotkeyResolvingControls);
        }

        public HotkeysResolvingForm()
        {
            InitializeComponent();
        }

        private void HotkeysResolvingForm_Load(object sender, EventArgs e)
        {
            ActiveControl = okButton;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var isValid = true;

            foreach (var hotkeyResolvingControl in _hotkeyResolvingControls)
            {
                if (!hotkeyResolvingControl.Inspect())
                    isValid = false;
            }

            if (!isValid)
                return;

            if (_hotkeyHelper.HasUnsolved())
            {
                var errorMessage = Language.GetString("hotkeys_conflicts_warning");

                if (DialogResult.OK == MessageBox.Show(this, errorMessage, "ScreenLoad",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                    return;

                _hotkeyHelper.AllUnsolvedToDisabled();
            }

            DialogResult = DialogResult.OK;
        }
    }
}
