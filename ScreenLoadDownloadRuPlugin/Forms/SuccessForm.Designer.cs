namespace ScreenLoadDownloadRuPlugin.Forms
{
    partial class SuccessForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuccessForm));
            this.captionLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.mPictureBox = new System.Windows.Forms.PictureBox();
            this.directLinkLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.pageLinkLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.directLinkTextBox = new ScreenLoadPlugin.Controls.ScreenLoadTextBox();
            this.directLinkButton = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.pageLinkButton = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.pageLinkTextBox = new ScreenLoadPlugin.Controls.ScreenLoadTextBox();
            this.okButton = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.doNotShowCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.mTimer = new System.Windows.Forms.Timer(this.components);
            this.automaticallyCloseCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.shareFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // captionLabel
            // 
            this.captionLabel.LanguageKey = "downloadru.success_info";
            this.captionLabel.Location = new System.Drawing.Point(82, 39);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(456, 28);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "The image has been successfully uploaded to Download.Ru! You can access it online" +
    " using the following link:";
            // 
            // mPictureBox
            // 
            this.mPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mPictureBox.Image")));
            this.mPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mPictureBox.Name = "mPictureBox";
            this.mPictureBox.Size = new System.Drawing.Size(64, 64);
            this.mPictureBox.TabIndex = 1;
            this.mPictureBox.TabStop = false;
            // 
            // directLinkLabel
            // 
            this.directLinkLabel.AutoSize = true;
            this.directLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directLinkLabel.LanguageKey = "downloadru.success_directlink";
            this.directLinkLabel.Location = new System.Drawing.Point(11, 165);
            this.directLinkLabel.Name = "directLinkLabel";
            this.directLinkLabel.Size = new System.Drawing.Size(69, 13);
            this.directLinkLabel.TabIndex = 4;
            this.directLinkLabel.Text = "Direct link:";
            // 
            // pageLinkLabel
            // 
            this.pageLinkLabel.AutoSize = true;
            this.pageLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageLinkLabel.LanguageKey = "downloadru.success_pagelink";
            this.pageLinkLabel.Location = new System.Drawing.Point(12, 102);
            this.pageLinkLabel.Name = "pageLinkLabel";
            this.pageLinkLabel.Size = new System.Drawing.Size(64, 13);
            this.pageLinkLabel.TabIndex = 1;
            this.pageLinkLabel.Text = "Page link:";
            // 
            // directLinkTextBox
            // 
            this.directLinkTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.directLinkTextBox.Location = new System.Drawing.Point(163, 139);
            this.directLinkTextBox.Multiline = true;
            this.directLinkTextBox.Name = "directLinkTextBox";
            this.directLinkTextBox.ReadOnly = true;
            this.directLinkTextBox.Size = new System.Drawing.Size(284, 65);
            this.directLinkTextBox.TabIndex = 5;
            // 
            // directLinkButton
            // 
            this.directLinkButton.LanguageKey = "downloadru.success_copy";
            this.directLinkButton.Location = new System.Drawing.Point(453, 181);
            this.directLinkButton.Name = "directLinkButton";
            this.directLinkButton.Size = new System.Drawing.Size(87, 23);
            this.directLinkButton.TabIndex = 6;
            this.directLinkButton.Text = "Copy";
            this.directLinkButton.UseVisualStyleBackColor = true;
            this.directLinkButton.Click += new System.EventHandler(this.DirectLinkButton_Click);
            // 
            // pageLinkButton
            // 
            this.pageLinkButton.LanguageKey = "downloadru.success_copy";
            this.pageLinkButton.Location = new System.Drawing.Point(453, 98);
            this.pageLinkButton.Name = "pageLinkButton";
            this.pageLinkButton.Size = new System.Drawing.Size(86, 23);
            this.pageLinkButton.TabIndex = 3;
            this.pageLinkButton.Text = "Copy";
            this.pageLinkButton.UseVisualStyleBackColor = true;
            this.pageLinkButton.Click += new System.EventHandler(this.PageLinkButton_Click);
            // 
            // pageLinkTextBox
            // 
            this.pageLinkTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.pageLinkTextBox.Location = new System.Drawing.Point(164, 100);
            this.pageLinkTextBox.Name = "pageLinkTextBox";
            this.pageLinkTextBox.ReadOnly = true;
            this.pageLinkTextBox.Size = new System.Drawing.Size(283, 20);
            this.pageLinkTextBox.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.LanguageKey = "downloadru.success_done";
            this.okButton.Location = new System.Drawing.Point(453, 313);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Done";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // doNotShowCheckBox
            // 
            this.doNotShowCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.doNotShowCheckBox.AutoSize = true;
            this.doNotShowCheckBox.LanguageKey = "downloadru.success_donotshow";
            this.doNotShowCheckBox.Location = new System.Drawing.Point(15, 285);
            this.doNotShowCheckBox.Name = "doNotShowCheckBox";
            this.doNotShowCheckBox.Size = new System.Drawing.Size(158, 17);
            this.doNotShowCheckBox.TabIndex = 8;
            this.doNotShowCheckBox.Text = "Don\'t show this dialog again";
            this.doNotShowCheckBox.UseVisualStyleBackColor = true;
            this.doNotShowCheckBox.CheckedChanged += new System.EventHandler(this.doNotShowCheckBox_CheckedChanged);
            // 
            // mTimer
            // 
            this.mTimer.Interval = 1000;
            this.mTimer.Tick += new System.EventHandler(this.MTimer_Tick);
            // 
            // automaticallyCloseCheckBox
            // 
            this.automaticallyCloseCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.automaticallyCloseCheckBox.AutoSize = true;
            this.automaticallyCloseCheckBox.LanguageKey = "downloadru.success_automaticallyclose";
            this.automaticallyCloseCheckBox.Location = new System.Drawing.Point(15, 317);
            this.automaticallyCloseCheckBox.Name = "automaticallyCloseCheckBox";
            this.automaticallyCloseCheckBox.PropertyName = "AutomaticallyCloseSuccessForm";
            this.automaticallyCloseCheckBox.SectionName = "DownloadRu";
            this.automaticallyCloseCheckBox.Size = new System.Drawing.Size(173, 17);
            this.automaticallyCloseCheckBox.TabIndex = 9;
            this.automaticallyCloseCheckBox.Text = "Automatically close the window";
            this.automaticallyCloseCheckBox.UseVisualStyleBackColor = true;
            this.automaticallyCloseCheckBox.CheckedChanged += new System.EventHandler(this.AutomaticallyCloseCheckBox_CheckedChanged);
            // 
            // shareFlowLayoutPanel
            // 
            this.shareFlowLayoutPanel.AutoSize = true;
            this.shareFlowLayoutPanel.Location = new System.Drawing.Point(12, 220);
            this.shareFlowLayoutPanel.MinimumSize = new System.Drawing.Size(46, 46);
            this.shareFlowLayoutPanel.Name = "shareFlowLayoutPanel";
            this.shareFlowLayoutPanel.Size = new System.Drawing.Size(46, 46);
            this.shareFlowLayoutPanel.TabIndex = 7;
            this.shareFlowLayoutPanel.WrapContents = false;
            // 
            // SuccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 348);
            this.Controls.Add(this.shareFlowLayoutPanel);
            this.Controls.Add(this.automaticallyCloseCheckBox);
            this.Controls.Add(this.doNotShowCheckBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.pageLinkButton);
            this.Controls.Add(this.pageLinkTextBox);
            this.Controls.Add(this.directLinkButton);
            this.Controls.Add(this.directLinkTextBox);
            this.Controls.Add(this.pageLinkLabel);
            this.Controls.Add(this.directLinkLabel);
            this.Controls.Add(this.mPictureBox);
            this.Controls.Add(this.captionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuccessForm";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ScreenLoad";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SuccessForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScreenLoadPlugin.Controls.ScreenLoadLabel captionLabel;
        private System.Windows.Forms.PictureBox mPictureBox;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel directLinkLabel;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel pageLinkLabel;
        private ScreenLoadPlugin.Controls.ScreenLoadTextBox directLinkTextBox;
        private ScreenLoadPlugin.Controls.ScreenLoadButton directLinkButton;
        private ScreenLoadPlugin.Controls.ScreenLoadButton pageLinkButton;
        private ScreenLoadPlugin.Controls.ScreenLoadTextBox pageLinkTextBox;
        private ScreenLoadPlugin.Controls.ScreenLoadButton okButton;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox doNotShowCheckBox;
        private System.Windows.Forms.Timer mTimer;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox automaticallyCloseCheckBox;
        private System.Windows.Forms.FlowLayoutPanel shareFlowLayoutPanel;
    }
}