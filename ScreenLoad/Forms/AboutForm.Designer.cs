namespace ScreenLoad
{
    sealed partial class AboutForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.mTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.copyrightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.copyrightLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.copyrightValueLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.okButton = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.companyNameFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.companyNameLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.companyNameValueLabel = new System.Windows.Forms.Label();
            this.warningLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.detailsLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.versionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.versionLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.versionValueLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.licenseFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.licenseLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.licenseValueLabel = new System.Windows.Forms.Label();
            this.mPanel = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mTableLayoutPanel.SuspendLayout();
            this.copyrightFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.companyNameFlowLayoutPanel.SuspendLayout();
            this.versionFlowLayoutPanel.SuspendLayout();
            this.licenseFlowLayoutPanel.SuspendLayout();
            this.mPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTableLayoutPanel
            // 
            this.mTableLayoutPanel.AutoSize = true;
            this.mTableLayoutPanel.ColumnCount = 2;
            this.mTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mTableLayoutPanel.Controls.Add(this.copyrightFlowLayoutPanel, 0, 3);
            this.mTableLayoutPanel.Controls.Add(this.logoPictureBox, 1, 0);
            this.mTableLayoutPanel.Controls.Add(this.okButton, 0, 8);
            this.mTableLayoutPanel.Controls.Add(this.companyNameFlowLayoutPanel, 0, 2);
            this.mTableLayoutPanel.Controls.Add(this.warningLabel, 0, 7);
            this.mTableLayoutPanel.Controls.Add(this.descriptionRichTextBox, 0, 6);
            this.mTableLayoutPanel.Controls.Add(this.titleLabel, 0, 0);
            this.mTableLayoutPanel.Controls.Add(this.detailsLabel, 0, 5);
            this.mTableLayoutPanel.Controls.Add(this.versionFlowLayoutPanel, 0, 1);
            this.mTableLayoutPanel.Controls.Add(this.licenseFlowLayoutPanel, 0, 4);
            this.mTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.mTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mTableLayoutPanel.Name = "mTableLayoutPanel";
            this.mTableLayoutPanel.RowCount = 9;
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.Size = new System.Drawing.Size(618, 379);
            this.mTableLayoutPanel.TabIndex = 0;
            // 
            // copyrightFlowLayoutPanel
            // 
            this.copyrightFlowLayoutPanel.AutoSize = true;
            this.copyrightFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.copyrightFlowLayoutPanel.Controls.Add(this.copyrightLabel);
            this.copyrightFlowLayoutPanel.Controls.Add(this.copyrightValueLabel);
            this.copyrightFlowLayoutPanel.Location = new System.Drawing.Point(0, 83);
            this.copyrightFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.copyrightFlowLayoutPanel.Name = "copyrightFlowLayoutPanel";
            this.copyrightFlowLayoutPanel.Size = new System.Drawing.Size(127, 25);
            this.copyrightFlowLayoutPanel.TabIndex = 3;
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.copyrightLabel.ForeColor = System.Drawing.Color.DimGray;
            this.copyrightLabel.LanguageKey = "About_Copyright";
            this.copyrightLabel.Location = new System.Drawing.Point(6, 6);
            this.copyrightLabel.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(64, 13);
            this.copyrightLabel.TabIndex = 0;
            this.copyrightLabel.Text = "Copyright:";
            // 
            // copyrightValueLabel
            // 
            this.copyrightValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.copyrightValueLabel.AutoSize = true;
            this.copyrightValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.copyrightValueLabel.ForeColor = System.Drawing.Color.DimGray;
            this.copyrightValueLabel.Location = new System.Drawing.Point(70, 6);
            this.copyrightValueLabel.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.copyrightValueLabel.Name = "copyrightValueLabel";
            this.copyrightValueLabel.Size = new System.Drawing.Size(51, 13);
            this.copyrightValueLabel.TabIndex = 1;
            this.copyrightValueLabel.Text = "Copyright";
            this.copyrightValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.logoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(484, 16);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.logoPictureBox.Name = "logoPictureBox";
            this.mTableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(128, 128);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 13;
            this.logoPictureBox.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mTableLayoutPanel.SetColumnSpan(this.okButton, 2);
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.okButton.LanguageKey = "OK";
            this.okButton.Location = new System.Drawing.Point(535, 349);
            this.okButton.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // companyNameFlowLayoutPanel
            // 
            this.companyNameFlowLayoutPanel.AutoSize = true;
            this.companyNameFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.companyNameFlowLayoutPanel.Controls.Add(this.companyNameLabel);
            this.companyNameFlowLayoutPanel.Controls.Add(this.companyNameValueLabel);
            this.companyNameFlowLayoutPanel.Location = new System.Drawing.Point(0, 58);
            this.companyNameFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.companyNameFlowLayoutPanel.Name = "companyNameFlowLayoutPanel";
            this.companyNameFlowLayoutPanel.Size = new System.Drawing.Size(192, 25);
            this.companyNameFlowLayoutPanel.TabIndex = 2;
            // 
            // companyNameLabel
            // 
            this.companyNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.companyNameLabel.AutoSize = true;
            this.companyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.companyNameLabel.ForeColor = System.Drawing.Color.DimGray;
            this.companyNameLabel.LanguageKey = "About_CompanyName";
            this.companyNameLabel.Location = new System.Drawing.Point(6, 6);
            this.companyNameLabel.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.companyNameLabel.Name = "companyNameLabel";
            this.companyNameLabel.Size = new System.Drawing.Size(98, 13);
            this.companyNameLabel.TabIndex = 0;
            this.companyNameLabel.Text = "Company Name:";
            // 
            // companyNameValueLabel
            // 
            this.companyNameValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.companyNameValueLabel.AutoSize = true;
            this.companyNameValueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.companyNameValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.companyNameValueLabel.ForeColor = System.Drawing.Color.Blue;
            this.companyNameValueLabel.Location = new System.Drawing.Point(104, 6);
            this.companyNameValueLabel.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.companyNameValueLabel.Name = "companyNameValueLabel";
            this.companyNameValueLabel.Size = new System.Drawing.Size(82, 13);
            this.companyNameValueLabel.TabIndex = 1;
            this.companyNameValueLabel.Text = "Company Name";
            this.companyNameValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // warningLabel
            // 
            this.warningLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.warningLabel.AutoSize = true;
            this.mTableLayoutPanel.SetColumnSpan(this.warningLabel, 2);
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.warningLabel.ForeColor = System.Drawing.Color.DimGray;
            this.warningLabel.LanguageKey = "About_Warning";
            this.warningLabel.Location = new System.Drawing.Point(6, 322);
            this.warningLabel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(419, 13);
            this.warningLabel.TabIndex = 7;
            this.warningLabel.Text = "Warning! This computer program is protected by copyright law and international tr" +
    "eaties.";
            // 
            // descriptionRichTextBox
            // 
            this.mTableLayoutPanel.SetColumnSpan(this.descriptionRichTextBox, 2);
            this.descriptionRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionRichTextBox.Location = new System.Drawing.Point(8, 168);
            this.descriptionRichTextBox.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.ReadOnly = true;
            this.descriptionRichTextBox.Size = new System.Drawing.Size(602, 140);
            this.descriptionRichTextBox.TabIndex = 6;
            this.descriptionRichTextBox.Text = "";
            this.descriptionRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.descriptionRichTextBox_LinkClicked);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.titleLabel.Location = new System.Drawing.Point(5, 5);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(150, 24);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Program Name";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // detailsLabel
            // 
            this.detailsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.detailsLabel.ForeColor = System.Drawing.Color.DimGray;
            this.detailsLabel.LanguageKey = "About_Details";
            this.detailsLabel.Location = new System.Drawing.Point(6, 147);
            this.detailsLabel.Margin = new System.Windows.Forms.Padding(6, 14, 6, 0);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(96, 13);
            this.detailsLabel.TabIndex = 5;
            this.detailsLabel.Text = "Product details:";
            // 
            // versionFlowLayoutPanel
            // 
            this.versionFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.versionFlowLayoutPanel.Controls.Add(this.versionLabel);
            this.versionFlowLayoutPanel.Controls.Add(this.versionValueLabel);
            this.versionFlowLayoutPanel.Controls.Add(this.updateButton);
            this.versionFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionFlowLayoutPanel.Location = new System.Drawing.Point(0, 34);
            this.versionFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.versionFlowLayoutPanel.Name = "versionFlowLayoutPanel";
            this.versionFlowLayoutPanel.Size = new System.Drawing.Size(478, 24);
            this.versionFlowLayoutPanel.TabIndex = 1;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.versionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.versionLabel.LanguageKey = "About_Version";
            this.versionLabel.Location = new System.Drawing.Point(6, 7);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(53, 13);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version:";
            // 
            // versionValueLabel
            // 
            this.versionValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.versionValueLabel.AutoSize = true;
            this.versionValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.versionValueLabel.ForeColor = System.Drawing.Color.DimGray;
            this.versionValueLabel.Location = new System.Drawing.Point(59, 7);
            this.versionValueLabel.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.versionValueLabel.Name = "versionValueLabel";
            this.versionValueLabel.Size = new System.Drawing.Size(42, 13);
            this.versionValueLabel.TabIndex = 1;
            this.versionValueLabel.Text = "Version";
            this.versionValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updateButton.AutoSize = true;
            this.updateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.updateButton.FlatAppearance.BorderSize = 0;
            this.updateButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.updateButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Image = ((System.Drawing.Image)(resources.GetObject("updateButton.Image")));
            this.updateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateButton.Location = new System.Drawing.Point(104, 3);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(22, 22);
            this.updateButton.TabIndex = 2;
            this.updateButton.UseMnemonic = false;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // licenseFlowLayoutPanel
            // 
            this.licenseFlowLayoutPanel.AutoSize = true;
            this.licenseFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.licenseFlowLayoutPanel.Controls.Add(this.licenseLabel);
            this.licenseFlowLayoutPanel.Controls.Add(this.licenseValueLabel);
            this.licenseFlowLayoutPanel.Location = new System.Drawing.Point(0, 108);
            this.licenseFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.licenseFlowLayoutPanel.Name = "licenseFlowLayoutPanel";
            this.licenseFlowLayoutPanel.Size = new System.Drawing.Size(122, 25);
            this.licenseFlowLayoutPanel.TabIndex = 4;
            // 
            // licenseLabel
            // 
            this.licenseLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.licenseLabel.AutoSize = true;
            this.licenseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.licenseLabel.ForeColor = System.Drawing.Color.DimGray;
            this.licenseLabel.LanguageKey = "About_License";
            this.licenseLabel.Location = new System.Drawing.Point(6, 6);
            this.licenseLabel.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.licenseLabel.Name = "licenseLabel";
            this.licenseLabel.Size = new System.Drawing.Size(55, 13);
            this.licenseLabel.TabIndex = 0;
            this.licenseLabel.Text = "License:";
            // 
            // licenseValueLabel
            // 
            this.licenseValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.licenseValueLabel.AutoSize = true;
            this.licenseValueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.licenseValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.licenseValueLabel.ForeColor = System.Drawing.Color.Blue;
            this.licenseValueLabel.Location = new System.Drawing.Point(61, 6);
            this.licenseValueLabel.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.licenseValueLabel.Name = "licenseValueLabel";
            this.licenseValueLabel.Size = new System.Drawing.Size(55, 13);
            this.licenseValueLabel.TabIndex = 1;
            this.licenseValueLabel.Text = "GNU GPL";
            // 
            // mPanel
            // 
            this.mPanel.Controls.Add(this.mTableLayoutPanel);
            this.mPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPanel.Location = new System.Drawing.Point(0, 0);
            this.mPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mPanel.Name = "mPanel";
            this.mPanel.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.mPanel.Size = new System.Drawing.Size(634, 395);
            this.mPanel.TabIndex = 1;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(634, 395);
            this.Controls.Add(this.mPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "About_FormTitle";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About {0}";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.mTableLayoutPanel.ResumeLayout(false);
            this.mTableLayoutPanel.PerformLayout();
            this.copyrightFlowLayoutPanel.ResumeLayout(false);
            this.copyrightFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.companyNameFlowLayoutPanel.ResumeLayout(false);
            this.companyNameFlowLayoutPanel.PerformLayout();
            this.versionFlowLayoutPanel.ResumeLayout(false);
            this.versionFlowLayoutPanel.PerformLayout();
            this.licenseFlowLayoutPanel.ResumeLayout(false);
            this.licenseFlowLayoutPanel.PerformLayout();
            this.mPanel.ResumeLayout(false);
            this.mPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label versionValueLabel;
        private System.Windows.Forms.Label copyrightValueLabel;
        private System.Windows.Forms.Label companyNameValueLabel;
        private ScreenLoadPlugin.Controls.ScreenLoadButton okButton;
        private System.Windows.Forms.Label licenseValueLabel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel warningLabel;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel detailsLabel;
        private System.Windows.Forms.FlowLayoutPanel versionFlowLayoutPanel;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel versionLabel;
        private System.Windows.Forms.FlowLayoutPanel copyrightFlowLayoutPanel;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel copyrightLabel;
        private System.Windows.Forms.FlowLayoutPanel companyNameFlowLayoutPanel;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel companyNameLabel;
        private System.Windows.Forms.FlowLayoutPanel licenseFlowLayoutPanel;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel licenseLabel;
        private System.Windows.Forms.Panel mPanel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.IContainer components;
    }
}