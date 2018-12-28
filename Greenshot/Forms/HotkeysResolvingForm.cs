using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Greenshot.Controls;
using Greenshot.Helpers;

namespace Greenshot.Forms
{
    internal partial class HotkeysResolvingForm : BaseForm
    {
        private readonly ReadOnlyCollection<HotkeyResolvingControl> _hotkeyResolvingControls;

        public HotkeysResolvingForm(IEnumerable<HotkeyProblem> hotkeyProblems)
            : this()
        {
            if (null == hotkeyProblems)
                throw new ArgumentNullException(nameof(hotkeyProblems));

            var hotkeyResolvingControls = new List<HotkeyResolvingControl>();

            mFlowLayoutPanel.SuspendLayout();

            foreach (var hotkeyProblem in hotkeyProblems)
            {
                var hotkeyResolvingControl = new HotkeyResolvingControl(hotkeyProblem.Action, hotkeyProblem.ActionText,
                    hotkeyProblem.Hotkey);

                hotkeyResolvingControls.Add(hotkeyResolvingControl);
                mFlowLayoutPanel.Controls.Add(hotkeyResolvingControl);
            }

            mFlowLayoutPanel.ResumeLayout();

            _hotkeyResolvingControls = new ReadOnlyCollection<HotkeyResolvingControl>(hotkeyResolvingControls);
        }

        public HotkeysResolvingForm()
        {
            InitializeComponent();
        }

        public IEnumerable<HotkeySolution> CollectHotkeySolutions()
        {
            var hotkeySolutions = new List<HotkeySolution>();

            foreach (var hotkeyResolvingControl in _hotkeyResolvingControls)
            {
                hotkeySolutions.Add(new HotkeySolution
                {
                    Action = hotkeyResolvingControl.Action,
                    Hotkey = hotkeyResolvingControl.Hotkey
                });
            }

            return hotkeySolutions;
        }

        private void HotkeyErrorsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var isValid = true;

            foreach (var hotkeyResolvingControl in _hotkeyResolvingControls)
            {
                if (!hotkeyResolvingControl.Inspect())
                    isValid = false;
            }

            if (isValid)
                DialogResult = DialogResult.OK;
        }
    }
}
