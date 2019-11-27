namespace Greenshot
{
    partial class UpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.okLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.laterLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.progressBottomPanel = new Greenshot.Controls.TransparentPanel();
            this.mProgressBar = new Greenshot.Controls.ProgressBarWithText();
            this.cancelLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.infoLabel = new Greenshot.Controls.TransparentLabel();
            this.captionLabel = new Greenshot.Controls.TransparentLabel();
            this.bottomFlowPanel = new Greenshot.Controls.TransparentFlowLayoutPanel();
            this.notificationBottomFlowPanel = new Greenshot.Controls.TransparentFlowLayoutPanel();
            this.progressBottomPanel.SuspendLayout();
            this.bottomFlowPanel.SuspendLayout();
            this.notificationBottomFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // okLabel
            // 
            this.okLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okLabel.AutoSize = true;
            this.okLabel.BackColor = System.Drawing.Color.Transparent;
            this.okLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(35)))));
            this.okLabel.LanguageKey = "UpdateForm_UpdateNow";
            this.okLabel.Location = new System.Drawing.Point(455, 12);
            this.okLabel.Margin = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.okLabel.Name = "okLabel";
            this.okLabel.Size = new System.Drawing.Size(138, 22);
            this.okLabel.TabIndex = 1;
            this.okLabel.Text = "UPDATE NOW";
            this.okLabel.Click += new System.EventHandler(this.okLabel_Click);
            // 
            // laterLabel
            // 
            this.laterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.laterLabel.AutoSize = true;
            this.laterLabel.BackColor = System.Drawing.Color.Transparent;
            this.laterLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.laterLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laterLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(35)))));
            this.laterLabel.LanguageKey = "UpdateForm_RemindLater";
            this.laterLabel.Location = new System.Drawing.Point(278, 12);
            this.laterLabel.Margin = new System.Windows.Forms.Padding(0, 12, 12, 0);
            this.laterLabel.Name = "laterLabel";
            this.laterLabel.Size = new System.Drawing.Size(153, 22);
            this.laterLabel.TabIndex = 0;
            this.laterLabel.Text = "REMIND LATER";
            this.laterLabel.Click += new System.EventHandler(this.cancelLabel_Click);
            // 
            // progressBottomPanel
            // 
            this.progressBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.progressBottomPanel.Controls.Add(this.mProgressBar);
            this.progressBottomPanel.Controls.Add(this.cancelLabel);
            this.progressBottomPanel.Location = new System.Drawing.Point(21, 284);
            this.progressBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.progressBottomPanel.Name = "progressBottomPanel";
            this.progressBottomPanel.Size = new System.Drawing.Size(593, 46);
            this.progressBottomPanel.TabIndex = 4;
            this.progressBottomPanel.Visible = false;
            // 
            // mProgressBar
            // 
            this.mProgressBar.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(131)))), ((int)(((byte)(201)))));
            this.mProgressBar.CustomText = null;
            this.mProgressBar.ForeColor = System.Drawing.Color.Black;
            this.mProgressBar.Location = new System.Drawing.Point(12, 12);
            this.mProgressBar.Margin = new System.Windows.Forms.Padding(12);
            this.mProgressBar.Name = "mProgressBar";
            this.mProgressBar.Size = new System.Drawing.Size(481, 22);
            this.mProgressBar.TabIndex = 0;
            // 
            // cancelLabel
            // 
            this.cancelLabel.AutoSize = true;
            this.cancelLabel.BackColor = System.Drawing.Color.Transparent;
            this.cancelLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(35)))));
            this.cancelLabel.LanguageKey = "UpdateForm_Cancel";
            this.cancelLabel.Location = new System.Drawing.Point(501, 12);
            this.cancelLabel.Name = "cancelLabel";
            this.cancelLabel.Size = new System.Drawing.Size(89, 22);
            this.cancelLabel.TabIndex = 1;
            this.cancelLabel.Text = "CANCEL";
            this.cancelLabel.Click += new System.EventHandler(this.cancelLabel_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.infoLabel.ForeColor = System.Drawing.Color.Black;
            this.infoLabel.Location = new System.Drawing.Point(272, 70);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(342, 121);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "A newer version of Greenshot is available!";
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.BackColor = System.Drawing.Color.Transparent;
            this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captionLabel.ForeColor = System.Drawing.Color.Black;
            this.captionLabel.LanguageKey = "UpdateForm_Caption";
            this.captionLabel.Location = new System.Drawing.Point(265, 21);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(287, 37);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "Greenshot Update!";
            // 
            // bottomFlowPanel
            // 
            this.bottomFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomFlowPanel.Controls.Add(this.notificationBottomFlowPanel);
            this.bottomFlowPanel.Location = new System.Drawing.Point(21, 210);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Size = new System.Drawing.Size(593, 46);
            this.bottomFlowPanel.TabIndex = 2;
            this.bottomFlowPanel.WrapContents = false;
            // 
            // notificationBottomFlowPanel
            // 
            this.notificationBottomFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.notificationBottomFlowPanel.Controls.Add(this.okLabel);
            this.notificationBottomFlowPanel.Controls.Add(this.laterLabel);
            this.notificationBottomFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.notificationBottomFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.notificationBottomFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.notificationBottomFlowPanel.Name = "notificationBottomFlowPanel";
            this.notificationBottomFlowPanel.Size = new System.Drawing.Size(593, 46);
            this.notificationBottomFlowPanel.TabIndex = 3;
            this.notificationBottomFlowPanel.WrapContents = false;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(640, 275);
            this.ControlBox = false;
            this.Controls.Add(this.bottomFlowPanel);
            this.Controls.Add(this.progressBottomPanel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.captionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateForm_FormClosed);
            this.progressBottomPanel.ResumeLayout(false);
            this.progressBottomPanel.PerformLayout();
            this.bottomFlowPanel.ResumeLayout(false);
            this.notificationBottomFlowPanel.ResumeLayout(false);
            this.notificationBottomFlowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Greenshot.Controls.TransparentLabel infoLabel;
        private GreenshotPlugin.Controls.GreenshotLabel laterLabel;
        private GreenshotPlugin.Controls.GreenshotLabel okLabel;
        private Greenshot.Controls.TransparentLabel captionLabel;
        private GreenshotPlugin.Controls.GreenshotLabel cancelLabel;
        private Controls.ProgressBarWithText mProgressBar;
        private Greenshot.Controls.TransparentPanel progressBottomPanel;
        private Greenshot.Controls.TransparentFlowLayoutPanel bottomFlowPanel;
        private Greenshot.Controls.TransparentFlowLayoutPanel notificationBottomFlowPanel;
    }
}

