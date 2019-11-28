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
            this.updateNowButton = new GreenshotPlugin.Controls.GreenshotLabel();
            this.laterButton = new GreenshotPlugin.Controls.GreenshotLabel();
            this.progressBottomPanel = new Greenshot.Controls.TransparentPanel();
            this.mProgressBar = new Greenshot.Controls.ProgressBarWithText();
            this.cancelButton = new GreenshotPlugin.Controls.GreenshotLabel();
            this.infoLabel = new Greenshot.Controls.TransparentLabel();
            this.captionLabel = new Greenshot.Controls.TransparentLabel();
            this.bottomFlowPanel = new Greenshot.Controls.TransparentFlowLayoutPanel();
            this.notificationBottomPanel = new Greenshot.Controls.TransparentFlowLayoutPanel();
            this.remindButton = new GreenshotPlugin.Controls.GreenshotLabel();
            this.doNotCheckRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.tomorrowRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.inAnHourRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.remindBottomPanel = new Greenshot.Controls.TransparentTableLayoutPanel();
            this.remindLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.progressBottomPanel.SuspendLayout();
            this.bottomFlowPanel.SuspendLayout();
            this.notificationBottomPanel.SuspendLayout();
            this.remindBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateNowButton
            // 
            this.updateNowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateNowButton.AutoSize = true;
            this.updateNowButton.BackColor = System.Drawing.Color.Transparent;
            this.updateNowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateNowButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateNowButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(35)))));
            this.updateNowButton.LanguageKey = "UpdateForm_UpdateNow";
            this.updateNowButton.Location = new System.Drawing.Point(266, 12);
            this.updateNowButton.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.updateNowButton.Name = "updateNowButton";
            this.updateNowButton.Size = new System.Drawing.Size(138, 22);
            this.updateNowButton.TabIndex = 0;
            this.updateNowButton.Text = "UPDATE NOW";
            this.updateNowButton.Click += new System.EventHandler(this.updateNowButton_Click);
            // 
            // laterButton
            // 
            this.laterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.laterButton.AutoSize = true;
            this.laterButton.BackColor = System.Drawing.Color.Transparent;
            this.laterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.laterButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(35)))));
            this.laterButton.LanguageKey = "UpdateForm_RemindLater";
            this.laterButton.Location = new System.Drawing.Point(428, 12);
            this.laterButton.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.laterButton.Name = "laterButton";
            this.laterButton.Size = new System.Drawing.Size(153, 22);
            this.laterButton.TabIndex = 1;
            this.laterButton.Text = "REMIND LATER";
            this.laterButton.Click += new System.EventHandler(this.laterButton_Click);
            // 
            // progressBottomPanel
            // 
            this.progressBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.progressBottomPanel.Controls.Add(this.mProgressBar);
            this.progressBottomPanel.Controls.Add(this.cancelButton);
            this.progressBottomPanel.Location = new System.Drawing.Point(21, 329);
            this.progressBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.progressBottomPanel.Name = "progressBottomPanel";
            this.progressBottomPanel.Size = new System.Drawing.Size(593, 46);
            this.progressBottomPanel.TabIndex = 5;
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
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(35)))));
            this.cancelButton.LanguageKey = "UpdateForm_Cancel";
            this.cancelButton.Location = new System.Drawing.Point(501, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(89, 22);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
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
            this.bottomFlowPanel.Controls.Add(this.notificationBottomPanel);
            this.bottomFlowPanel.Location = new System.Drawing.Point(21, 210);
            this.bottomFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Size = new System.Drawing.Size(593, 46);
            this.bottomFlowPanel.TabIndex = 2;
            this.bottomFlowPanel.WrapContents = false;
            // 
            // notificationBottomPanel
            // 
            this.notificationBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.notificationBottomPanel.Controls.Add(this.laterButton);
            this.notificationBottomPanel.Controls.Add(this.updateNowButton);
            this.notificationBottomPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.notificationBottomPanel.Location = new System.Drawing.Point(0, 0);
            this.notificationBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.notificationBottomPanel.Name = "notificationBottomPanel";
            this.notificationBottomPanel.Size = new System.Drawing.Size(593, 46);
            this.notificationBottomPanel.TabIndex = 3;
            this.notificationBottomPanel.WrapContents = false;
            // 
            // remindButton
            // 
            this.remindButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remindButton.AutoSize = true;
            this.remindButton.BackColor = System.Drawing.Color.Transparent;
            this.remindButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remindButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remindButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(35)))));
            this.remindButton.LanguageKey = "UpdateForm_OK";
            this.remindButton.Location = new System.Drawing.Point(554, 12);
            this.remindButton.Margin = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.remindButton.Name = "remindButton";
            this.remindButton.Size = new System.Drawing.Size(39, 22);
            this.remindButton.TabIndex = 4;
            this.remindButton.Text = "OK";
            this.remindButton.Click += new System.EventHandler(this.remindButton_Click);
            // 
            // doNotCheckRadioButton
            // 
            this.doNotCheckRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.doNotCheckRadioButton.AutoSize = true;
            this.doNotCheckRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.doNotCheckRadioButton.LanguageKey = "UpdateForm_DoNotCheck";
            this.doNotCheckRadioButton.Location = new System.Drawing.Point(262, 12);
            this.doNotCheckRadioButton.Name = "doNotCheckRadioButton";
            this.doNotCheckRadioButton.Size = new System.Drawing.Size(107, 22);
            this.doNotCheckRadioButton.TabIndex = 3;
            this.doNotCheckRadioButton.Text = "don\'t remind";
            this.doNotCheckRadioButton.UseVisualStyleBackColor = true;
            // 
            // tomorrowRadioButton
            // 
            this.tomorrowRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tomorrowRadioButton.AutoSize = true;
            this.tomorrowRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tomorrowRadioButton.LanguageKey = "UpdateForm_Tomorrow";
            this.tomorrowRadioButton.Location = new System.Drawing.Point(165, 12);
            this.tomorrowRadioButton.Name = "tomorrowRadioButton";
            this.tomorrowRadioButton.Size = new System.Drawing.Size(91, 22);
            this.tomorrowRadioButton.TabIndex = 2;
            this.tomorrowRadioButton.Text = "tomorrow";
            this.tomorrowRadioButton.UseVisualStyleBackColor = true;
            // 
            // inAnHourRadioButton
            // 
            this.inAnHourRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.inAnHourRadioButton.AutoSize = true;
            this.inAnHourRadioButton.Checked = true;
            this.inAnHourRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inAnHourRadioButton.LanguageKey = "UpdateForm_InAnHour";
            this.inAnHourRadioButton.Location = new System.Drawing.Point(68, 12);
            this.inAnHourRadioButton.Name = "inAnHourRadioButton";
            this.inAnHourRadioButton.Size = new System.Drawing.Size(91, 22);
            this.inAnHourRadioButton.TabIndex = 1;
            this.inAnHourRadioButton.TabStop = true;
            this.inAnHourRadioButton.Text = "in an hour";
            this.inAnHourRadioButton.UseVisualStyleBackColor = true;
            // 
            // remindBottomPanel
            // 
            this.remindBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.remindBottomPanel.ColumnCount = 5;
            this.remindBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.remindBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.remindBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.remindBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.remindBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.remindBottomPanel.Controls.Add(this.remindButton, 4, 0);
            this.remindBottomPanel.Controls.Add(this.inAnHourRadioButton, 1, 0);
            this.remindBottomPanel.Controls.Add(this.doNotCheckRadioButton, 3, 0);
            this.remindBottomPanel.Controls.Add(this.tomorrowRadioButton, 2, 0);
            this.remindBottomPanel.Controls.Add(this.remindLabel, 0, 0);
            this.remindBottomPanel.Location = new System.Drawing.Point(21, 283);
            this.remindBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.remindBottomPanel.Name = "remindBottomPanel";
            this.remindBottomPanel.RowCount = 1;
            this.remindBottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.remindBottomPanel.Size = new System.Drawing.Size(593, 46);
            this.remindBottomPanel.TabIndex = 4;
            this.remindBottomPanel.Visible = false;
            // 
            // remindLabel
            // 
            this.remindLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.remindLabel.AutoSize = true;
            this.remindLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remindLabel.LanguageKey = "UpdateForm_RemindLabel";
            this.remindLabel.Location = new System.Drawing.Point(3, 14);
            this.remindLabel.Name = "remindLabel";
            this.remindLabel.Size = new System.Drawing.Size(59, 18);
            this.remindLabel.TabIndex = 0;
            this.remindLabel.Text = "Remind";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(640, 275);
            this.ControlBox = false;
            this.Controls.Add(this.remindBottomPanel);
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
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateForm_FormClosed);
            this.progressBottomPanel.ResumeLayout(false);
            this.progressBottomPanel.PerformLayout();
            this.bottomFlowPanel.ResumeLayout(false);
            this.notificationBottomPanel.ResumeLayout(false);
            this.notificationBottomPanel.PerformLayout();
            this.remindBottomPanel.ResumeLayout(false);
            this.remindBottomPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Greenshot.Controls.TransparentLabel infoLabel;
        private GreenshotPlugin.Controls.GreenshotLabel laterButton;
        private GreenshotPlugin.Controls.GreenshotLabel updateNowButton;
        private Greenshot.Controls.TransparentLabel captionLabel;
        private GreenshotPlugin.Controls.GreenshotLabel cancelButton;
        private Controls.ProgressBarWithText mProgressBar;
        private Greenshot.Controls.TransparentPanel progressBottomPanel;
        private Greenshot.Controls.TransparentFlowLayoutPanel bottomFlowPanel;
        private Greenshot.Controls.TransparentFlowLayoutPanel notificationBottomPanel;
        private GreenshotPlugin.Controls.GreenshotLabel remindButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton doNotCheckRadioButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton tomorrowRadioButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton inAnHourRadioButton;
        private Greenshot.Controls.TransparentTableLayoutPanel remindBottomPanel;
        private GreenshotPlugin.Controls.GreenshotLabel remindLabel;
    }
}

