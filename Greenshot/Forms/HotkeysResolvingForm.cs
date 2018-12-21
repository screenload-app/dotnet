using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Greenshot.Controls;
using Greenshot.Helpers;

namespace Greenshot.Forms
{
    internal partial class HotkeysResolvingForm : BaseForm
    {
        public HotkeysResolvingForm(IEnumerable<HotkeyProblem> hotkeyProblems)
            : this()
        {
            if (null == hotkeyProblems)
                throw new ArgumentNullException(nameof(hotkeyProblems));

            mFlowLayoutPanel.SuspendLayout();

            foreach (var hotkeyProblem in hotkeyProblems)
            {
                mFlowLayoutPanel.Controls.Add(new HotkeyResolvingControl(hotkeyProblem.Action, hotkeyProblem.ActionText,
                    hotkeyProblem.Hotkey));
            }

            mFlowLayoutPanel.ResumeLayout();
        }

        public HotkeysResolvingForm()
        {
            InitializeComponent();
        }

        public IEnumerable<HotkeySolution> CollectHotkeySolutions()
        {
            var hotkeySolutions = new List<HotkeySolution>();

            foreach (Control control in mFlowLayoutPanel.Controls)
            {
                var hotkeyResolvingControl = control as HotkeyResolvingControl;

                if (null == hotkeyResolvingControl)
                    continue;

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

            foreach (var control in mFlowLayoutPanel.Controls)
            {
                var hotkeyResolvingControl = control as HotkeyResolvingControl;

                if (null == hotkeyResolvingControl)
                    return;

                if (!hotkeyResolvingControl.Inspect())
                    isValid = false;
            }

            if (isValid)
                DialogResult = DialogResult.OK;
        }
    }
}
