using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Greenshot.Controls;
using Greenshot.Helpers;
using GreenshotPlugin.Core;

namespace Greenshot
{
    internal partial class HotkeysResolvingForm : BaseForm
    {
        private readonly ReadOnlyCollection<HotkeyResolvingControl> _hotkeyResolvingControls;
        private readonly ReadOnlyCollection<HotkeyInfo> _hotkeyInfoListCollection;

        public HotkeysResolvingForm(IEnumerable<HotkeyInfo> hotkeyInfoList)
            : this()
        {
            if (null == hotkeyInfoList)
                throw new ArgumentNullException(nameof(hotkeyInfoList));

            _hotkeyInfoListCollection = new ReadOnlyCollection<HotkeyInfo>(new List<HotkeyInfo>(hotkeyInfoList));

            var hotkeyResolvingControls = new List<HotkeyResolvingControl>();

            conflictsFlowLayoutPanel.SuspendLayout();
            mFlowLayoutPanel.SuspendLayout();
            SuspendLayout();
            
            foreach (var hotkeyInfo in _hotkeyInfoListCollection)
            {
                var hotkeyResolvingControl = new HotkeyResolvingControl(hotkeyInfo);

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

            var solved = true;

            foreach (var hotkeyInfo in _hotkeyInfoListCollection)
            {
                if (HotkeySolution.Unsolved == hotkeyInfo.Solution)
                    solved = false;
            }

            if (!solved)
            {
                var errorMessage = Language.GetString("hotkeys_resolving_info");

                if (DialogResult.OK == MessageBox.Show(this, errorMessage, "Greenshot",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                    return;

                foreach (var hotkeyInfo in _hotkeyInfoListCollection)
                {
                    if (HotkeySolution.Unsolved == hotkeyInfo.Solution)
                        hotkeyInfo.Solution = HotkeySolution.Disabled;
                }
            }

            DialogResult = DialogResult.OK;
        }
    }
}
