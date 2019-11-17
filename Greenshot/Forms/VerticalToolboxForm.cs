﻿using System;
using System.Windows.Forms;
using Greenshot.Helpers;
using GreenshotPlugin.Core;

namespace Greenshot
{
    public sealed partial class VerticalToolboxForm : Form
    {
        const int WM_NCHITTEST = 0x0084;
        const int HTCAPTION = 2;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams createParams = base.CreateParams;
        //        createParams.ExStyle |= 0x02000000;
        //        return createParams;
        //    }
        //}

        public event EventHandler<QuickImageEditorCommandEventArgs> ServiceCommand;

        public VerticalToolboxForm()
        {
            InitializeComponent();

            //SuspendLayout();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer |
            //         ControlStyles.OptimizedDoubleBuffer, true);
            //ResumeLayout(true);
        }

        private void VerticalToolboxForm_Load(object sender, EventArgs e)
        {
            toolTip.SetToolTip(uploadButton, Language.GetString("QuickImageEditor_Upload"));
            toolTip.SetToolTip(copyButton, Language.GetString("QuickImageEditor_Copy"));
            toolTip.SetToolTip(saveButton, Language.GetString("QuickImageEditor_Save"));
            toolTip.SetToolTip(moreButton, Language.GetString("QuickImageEditor_More"));
            toolTip.SetToolTip(closeButton, Language.GetString("QuickImageEditor_Close"));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTCAPTION;
                return;
            }

            base.WndProc(ref m);
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Upload));
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Copy));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Save));
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.Close));
        }

        private void MoreButton_Click(object sender, EventArgs e)
        {
            ServiceCommand?.Invoke(this, new QuickImageEditorCommandEventArgs(QuickImageEditorCommand.More));
        }
    }
}
