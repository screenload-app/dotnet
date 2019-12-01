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
            this.progressBottomPanel = new Greenshot.Controls.TransparentPanel();
            this.cancelButton = new GreenshotPlugin.Controls.GreenshotButton();
            this.mProgressBar = new System.Windows.Forms.ProgressBar();
            this.infoLabel = new Greenshot.Controls.TransparentLabel();
            this.captionLabel = new Greenshot.Controls.TransparentLabel();
            this.bottomFlowPanel = new Greenshot.Controls.TransparentFlowLayoutPanel();
            this.notificationBottomPanel = new Greenshot.Controls.TransparentFlowLayoutPanel();
            this.laterButton = new GreenshotPlugin.Controls.GreenshotButton();
            this.updateNowButton = new GreenshotPlugin.Controls.GreenshotButton();
            this.doNotCheckRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.tomorrowRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.inAnHourRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.remindBottomPanel = new Greenshot.Controls.TransparentTableLayoutPanel();
            this.remindLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.remindButton = new GreenshotPlugin.Controls.GreenshotButton();
            this.mPictureBox = new System.Windows.Forms.PictureBox();
            this.progressBottomPanel.SuspendLayout();
            this.bottomFlowPanel.SuspendLayout();
            this.notificationBottomPanel.SuspendLayout();
            this.remindBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBottomPanel
            // 
            this.progressBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.progressBottomPanel.Controls.Add(this.cancelButton);
            this.progressBottomPanel.Controls.Add(this.mProgressBar);
            this.progressBottomPanel.Location = new System.Drawing.Point(12, 270);
            this.progressBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.progressBottomPanel.Name = "progressBottomPanel";
            this.progressBottomPanel.Size = new System.Drawing.Size(440, 46);
            this.progressBottomPanel.TabIndex = 5;
            this.progressBottomPanel.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.LanguageKey = "UpdateForm_Cancel";
            this.cancelButton.Location = new System.Drawing.Point(365, 12);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // mProgressBar
            // 
            this.mProgressBar.Location = new System.Drawing.Point(2, 12);
            this.mProgressBar.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.mProgressBar.Name = "mProgressBar";
            this.mProgressBar.Size = new System.Drawing.Size(351, 23);
            this.mProgressBar.TabIndex = 0;
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoLabel.Location = new System.Drawing.Point(111, 35);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(341, 137);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "A newer version of Greenshot is available!";
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.BackColor = System.Drawing.Color.Transparent;
            this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captionLabel.LanguageKey = "UpdateForm_Caption";
            this.captionLabel.Location = new System.Drawing.Point(108, 12);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(114, 13);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "Greenshot Update!";
            // 
            // bottomFlowPanel
            // 
            this.bottomFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomFlowPanel.Controls.Add(this.notificationBottomPanel);
            this.bottomFlowPanel.Location = new System.Drawing.Point(12, 175);
            this.bottomFlowPanel.Name = "bottomFlowPanel";
            this.bottomFlowPanel.Size = new System.Drawing.Size(440, 46);
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
            this.notificationBottomPanel.Size = new System.Drawing.Size(440, 46);
            this.notificationBottomPanel.TabIndex = 3;
            this.notificationBottomPanel.WrapContents = false;
            // 
            // laterButton
            // 
            this.laterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.laterButton.AutoSize = true;
            this.laterButton.LanguageKey = "UpdateForm_RemindLater";
            this.laterButton.Location = new System.Drawing.Point(364, 12);
            this.laterButton.Margin = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.laterButton.Name = "laterButton";
            this.laterButton.Size = new System.Drawing.Size(76, 23);
            this.laterButton.TabIndex = 1;
            this.laterButton.Text = "Remind later";
            this.laterButton.UseVisualStyleBackColor = true;
            this.laterButton.Click += new System.EventHandler(this.laterButton_Click);
            // 
            // updateNowButton
            // 
            this.updateNowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateNowButton.AutoSize = true;
            this.updateNowButton.LanguageKey = "UpdateForm_UpdateNow";
            this.updateNowButton.Location = new System.Drawing.Point(275, 12);
            this.updateNowButton.Margin = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.updateNowButton.Name = "updateNowButton";
            this.updateNowButton.Size = new System.Drawing.Size(77, 23);
            this.updateNowButton.TabIndex = 0;
            this.updateNowButton.Text = "Update now";
            this.updateNowButton.UseVisualStyleBackColor = true;
            this.updateNowButton.Click += new System.EventHandler(this.updateNowButton_Click);
            // 
            // doNotCheckRadioButton
            // 
            this.doNotCheckRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.doNotCheckRadioButton.AutoSize = true;
            this.doNotCheckRadioButton.LanguageKey = "UpdateForm_DoNotCheck";
            this.doNotCheckRadioButton.Location = new System.Drawing.Point(204, 14);
            this.doNotCheckRadioButton.Name = "doNotCheckRadioButton";
            this.doNotCheckRadioButton.Size = new System.Drawing.Size(82, 17);
            this.doNotCheckRadioButton.TabIndex = 3;
            this.doNotCheckRadioButton.Text = "don\'t remind";
            this.doNotCheckRadioButton.UseVisualStyleBackColor = true;
            // 
            // tomorrowRadioButton
            // 
            this.tomorrowRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tomorrowRadioButton.AutoSize = true;
            this.tomorrowRadioButton.LanguageKey = "UpdateForm_Tomorrow";
            this.tomorrowRadioButton.Location = new System.Drawing.Point(130, 14);
            this.tomorrowRadioButton.Name = "tomorrowRadioButton";
            this.tomorrowRadioButton.Size = new System.Drawing.Size(68, 17);
            this.tomorrowRadioButton.TabIndex = 2;
            this.tomorrowRadioButton.Text = "tomorrow";
            this.tomorrowRadioButton.UseVisualStyleBackColor = true;
            // 
            // inAnHourRadioButton
            // 
            this.inAnHourRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.inAnHourRadioButton.AutoSize = true;
            this.inAnHourRadioButton.Checked = true;
            this.inAnHourRadioButton.LanguageKey = "UpdateForm_InAnHour";
            this.inAnHourRadioButton.Location = new System.Drawing.Point(52, 14);
            this.inAnHourRadioButton.Name = "inAnHourRadioButton";
            this.inAnHourRadioButton.Size = new System.Drawing.Size(72, 17);
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
            this.remindBottomPanel.Controls.Add(this.inAnHourRadioButton, 1, 0);
            this.remindBottomPanel.Controls.Add(this.doNotCheckRadioButton, 3, 0);
            this.remindBottomPanel.Controls.Add(this.tomorrowRadioButton, 2, 0);
            this.remindBottomPanel.Controls.Add(this.remindLabel, 0, 0);
            this.remindBottomPanel.Controls.Add(this.remindButton, 4, 0);
            this.remindBottomPanel.Location = new System.Drawing.Point(12, 224);
            this.remindBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.remindBottomPanel.Name = "remindBottomPanel";
            this.remindBottomPanel.RowCount = 1;
            this.remindBottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.remindBottomPanel.Size = new System.Drawing.Size(440, 46);
            this.remindBottomPanel.TabIndex = 4;
            this.remindBottomPanel.Visible = false;
            // 
            // remindLabel
            // 
            this.remindLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.remindLabel.AutoSize = true;
            this.remindLabel.LanguageKey = "UpdateForm_RemindLabel";
            this.remindLabel.Location = new System.Drawing.Point(3, 16);
            this.remindLabel.Name = "remindLabel";
            this.remindLabel.Size = new System.Drawing.Size(43, 13);
            this.remindLabel.TabIndex = 0;
            this.remindLabel.Text = "Remind";
            // 
            // remindButton
            // 
            this.remindButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remindButton.LanguageKey = "UpdateForm_OK";
            this.remindButton.Location = new System.Drawing.Point(365, 12);
            this.remindButton.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.remindButton.Name = "remindButton";
            this.remindButton.Size = new System.Drawing.Size(75, 23);
            this.remindButton.TabIndex = 4;
            this.remindButton.Text = "Ok";
            this.remindButton.UseVisualStyleBackColor = true;
            this.remindButton.Click += new System.EventHandler(this.remindButton_Click);
            // 
            // mPictureBox
            // 
            this.mPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mPictureBox.Image")));
            this.mPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mPictureBox.Name = "mPictureBox";
            this.mPictureBox.Size = new System.Drawing.Size(90, 90);
            this.mPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mPictureBox.TabIndex = 15;
            this.mPictureBox.TabStop = false;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 221);
            this.ControlBox = false;
            this.Controls.Add(this.mPictureBox);
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
            this.bottomFlowPanel.ResumeLayout(false);
            this.notificationBottomPanel.ResumeLayout(false);
            this.notificationBottomPanel.PerformLayout();
            this.remindBottomPanel.ResumeLayout(false);
            this.remindBottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Greenshot.Controls.TransparentLabel infoLabel;
        private Greenshot.Controls.TransparentLabel captionLabel;
        private Greenshot.Controls.TransparentPanel progressBottomPanel;
        private Greenshot.Controls.TransparentFlowLayoutPanel bottomFlowPanel;
        private Greenshot.Controls.TransparentFlowLayoutPanel notificationBottomPanel;
        private GreenshotPlugin.Controls.GreenshotRadioButton doNotCheckRadioButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton tomorrowRadioButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton inAnHourRadioButton;
        private Greenshot.Controls.TransparentTableLayoutPanel remindBottomPanel;
        private GreenshotPlugin.Controls.GreenshotLabel remindLabel;
        private GreenshotPlugin.Controls.GreenshotButton cancelButton;
        private System.Windows.Forms.ProgressBar mProgressBar;
        private GreenshotPlugin.Controls.GreenshotButton laterButton;
        private GreenshotPlugin.Controls.GreenshotButton updateNowButton;
        private GreenshotPlugin.Controls.GreenshotButton remindButton;
        private System.Windows.Forms.PictureBox mPictureBox;
    }
}

