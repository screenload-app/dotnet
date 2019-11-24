/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2014 Thomas Braun, Jens Klingen, Robin Krom, Francis Noel
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on Sourceforge: http://sourceforge.net/projects/greenshot/
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
namespace GreenshotDownloadRuPlugin.Forms
{
	partial class SettingsForm {
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.buttonOK = new GreenshotPlugin.Controls.GreenshotButton();
            this.buttonCancel = new GreenshotPlugin.Controls.GreenshotButton();
            this.combobox_uploadimageformat = new GreenshotPlugin.Controls.GreenshotComboBox();
            this.label_upload_format = new GreenshotPlugin.Controls.GreenshotLabel();
            this.checkboxAfterUploadLinkToClipBoard = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.checkboxAfterUploadSharedLink = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.afterUploadGroupBox = new GreenshotPlugin.Controls.GreenshotGroupBox();
            this.openInBrowserComboBox = new GreenshotPlugin.Controls.GreenshotComboBox();
            this.toClipBoardComboBox = new GreenshotPlugin.Controls.GreenshotComboBox();
            this.showDetailsCheckBox = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.openInBrowserCheckBox = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.anonymousAccessCheckBox = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.afterUploadGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.LanguageKey = "OK";
            this.buttonOK.Location = new System.Drawing.Point(264, 217);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.LanguageKey = "CANCEL";
            this.buttonCancel.Location = new System.Drawing.Point(345, 217);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // combobox_uploadimageformat
            // 
            this.combobox_uploadimageformat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combobox_uploadimageformat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_uploadimageformat.FormattingEnabled = true;
            this.combobox_uploadimageformat.Location = new System.Drawing.Point(231, 15);
            this.combobox_uploadimageformat.Name = "combobox_uploadimageformat";
            this.combobox_uploadimageformat.PropertyName = "UploadFormat";
            this.combobox_uploadimageformat.SectionName = "DownloadRu";
            this.combobox_uploadimageformat.Size = new System.Drawing.Size(189, 21);
            this.combobox_uploadimageformat.TabIndex = 1;
            // 
            // label_upload_format
            // 
            this.label_upload_format.LanguageKey = "downloadru.label_upload_format";
            this.label_upload_format.Location = new System.Drawing.Point(12, 15);
            this.label_upload_format.Name = "label_upload_format";
            this.label_upload_format.Size = new System.Drawing.Size(213, 20);
            this.label_upload_format.TabIndex = 0;
            this.label_upload_format.Text = "Image format";
            // 
            // checkboxAfterUploadLinkToClipBoard
            // 
            this.checkboxAfterUploadLinkToClipBoard.AutoSize = true;
            this.checkboxAfterUploadLinkToClipBoard.LanguageKey = "downloadru.label_AfterUploadLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.Location = new System.Drawing.Point(6, 42);
            this.checkboxAfterUploadLinkToClipBoard.Name = "checkboxAfterUploadLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.PropertyName = "AfterUploadLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.SectionName = "DownloadRu";
            this.checkboxAfterUploadLinkToClipBoard.Size = new System.Drawing.Size(108, 17);
            this.checkboxAfterUploadLinkToClipBoard.TabIndex = 1;
            this.checkboxAfterUploadLinkToClipBoard.Text = "Copy to clipboard";
            this.checkboxAfterUploadLinkToClipBoard.UseVisualStyleBackColor = true;
            this.checkboxAfterUploadLinkToClipBoard.CheckedChanged += new System.EventHandler(this.checkboxAfterUploadLinkToClipBoard_CheckedChanged);
            // 
            // checkboxAfterUploadSharedLink
            // 
            this.checkboxAfterUploadSharedLink.AccessibleName = "";
            this.checkboxAfterUploadSharedLink.AutoSize = true;
            this.checkboxAfterUploadSharedLink.LanguageKey = "downloadru.label_AfterUploadSharedLink";
            this.checkboxAfterUploadSharedLink.Location = new System.Drawing.Point(6, 19);
            this.checkboxAfterUploadSharedLink.Name = "checkboxAfterUploadSharedLink";
            this.checkboxAfterUploadSharedLink.PropertyName = "SharedLink";
            this.checkboxAfterUploadSharedLink.SectionName = "DownloadRu";
            this.checkboxAfterUploadSharedLink.Size = new System.Drawing.Size(85, 17);
            this.checkboxAfterUploadSharedLink.TabIndex = 0;
            this.checkboxAfterUploadSharedLink.Text = "Share image";
            this.checkboxAfterUploadSharedLink.UseVisualStyleBackColor = true;
            // 
            // afterUploadGroupBox
            // 
            this.afterUploadGroupBox.Controls.Add(this.openInBrowserComboBox);
            this.afterUploadGroupBox.Controls.Add(this.toClipBoardComboBox);
            this.afterUploadGroupBox.Controls.Add(this.showDetailsCheckBox);
            this.afterUploadGroupBox.Controls.Add(this.openInBrowserCheckBox);
            this.afterUploadGroupBox.Controls.Add(this.checkboxAfterUploadLinkToClipBoard);
            this.afterUploadGroupBox.Controls.Add(this.checkboxAfterUploadSharedLink);
            this.afterUploadGroupBox.LanguageKey = "downloadru.label_AfterUpload";
            this.afterUploadGroupBox.Location = new System.Drawing.Point(12, 39);
            this.afterUploadGroupBox.Name = "afterUploadGroupBox";
            this.afterUploadGroupBox.Size = new System.Drawing.Size(408, 112);
            this.afterUploadGroupBox.TabIndex = 2;
            this.afterUploadGroupBox.TabStop = false;
            this.afterUploadGroupBox.Text = "After upload";
            // 
            // openInBrowserComboBox
            // 
            this.openInBrowserComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openInBrowserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.openInBrowserComboBox.Enabled = false;
            this.openInBrowserComboBox.FormattingEnabled = true;
            this.openInBrowserComboBox.LanguagePrefix = "downloadru";
            this.openInBrowserComboBox.Location = new System.Drawing.Point(219, 61);
            this.openInBrowserComboBox.Name = "openInBrowserComboBox";
            this.openInBrowserComboBox.PropertyName = "AfterUploadLinkOpenInBrowserMode";
            this.openInBrowserComboBox.SectionName = "DownloadRu";
            this.openInBrowserComboBox.Size = new System.Drawing.Size(183, 21);
            this.openInBrowserComboBox.TabIndex = 4;
            // 
            // toClipBoardComboBox
            // 
            this.toClipBoardComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toClipBoardComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toClipBoardComboBox.Enabled = false;
            this.toClipBoardComboBox.FormattingEnabled = true;
            this.toClipBoardComboBox.LanguagePrefix = "downloadru";
            this.toClipBoardComboBox.Location = new System.Drawing.Point(219, 38);
            this.toClipBoardComboBox.Name = "toClipBoardComboBox";
            this.toClipBoardComboBox.PropertyName = "AfterUploadLinkToClipBoardMode";
            this.toClipBoardComboBox.SectionName = "DownloadRu";
            this.toClipBoardComboBox.Size = new System.Drawing.Size(183, 21);
            this.toClipBoardComboBox.TabIndex = 2;
            // 
            // showDetailsCheckBox
            // 
            this.showDetailsCheckBox.AutoSize = true;
            this.showDetailsCheckBox.LanguageKey = "downloadru.label_AfterUploadLinkShowDetails";
            this.showDetailsCheckBox.Location = new System.Drawing.Point(6, 88);
            this.showDetailsCheckBox.Name = "showDetailsCheckBox";
            this.showDetailsCheckBox.PropertyName = "AfterUploadLinkShowDetails";
            this.showDetailsCheckBox.SectionName = "DownloadRu";
            this.showDetailsCheckBox.Size = new System.Drawing.Size(234, 17);
            this.showDetailsCheckBox.TabIndex = 5;
            this.showDetailsCheckBox.Text = "Open a window with the detailed information";
            this.showDetailsCheckBox.UseVisualStyleBackColor = true;
            // 
            // openInBrowserCheckBox
            // 
            this.openInBrowserCheckBox.AutoSize = true;
            this.openInBrowserCheckBox.LanguageKey = "downloadru.label_AfterUploadLinkOpenInBrowser";
            this.openInBrowserCheckBox.Location = new System.Drawing.Point(6, 65);
            this.openInBrowserCheckBox.Name = "openInBrowserCheckBox";
            this.openInBrowserCheckBox.PropertyName = "AfterUploadLinkOpenInBrowser";
            this.openInBrowserCheckBox.SectionName = "DownloadRu";
            this.openInBrowserCheckBox.Size = new System.Drawing.Size(106, 17);
            this.openInBrowserCheckBox.TabIndex = 3;
            this.openInBrowserCheckBox.Text = "Open in browser:";
            this.openInBrowserCheckBox.UseVisualStyleBackColor = true;
            this.openInBrowserCheckBox.CheckedChanged += new System.EventHandler(this.openInBrowserCheckBox_CheckedChanged);
            // 
            // anonymousAccessCheckBox
            // 
            this.anonymousAccessCheckBox.AutoSize = true;
            this.anonymousAccessCheckBox.LanguageKey = "downloadru.anonymous_access";
            this.anonymousAccessCheckBox.Location = new System.Drawing.Point(18, 175);
            this.anonymousAccessCheckBox.Name = "anonymousAccessCheckBox";
            this.anonymousAccessCheckBox.PropertyName = "AnonymousAccess";
            this.anonymousAccessCheckBox.SectionName = "DownloadRu";
            this.anonymousAccessCheckBox.Size = new System.Drawing.Size(122, 17);
            this.anonymousAccessCheckBox.TabIndex = 3;
            this.anonymousAccessCheckBox.Text = "Use anonym access";
            this.anonymousAccessCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(432, 252);
            this.Controls.Add(this.anonymousAccessCheckBox);
            this.Controls.Add(this.afterUploadGroupBox);
            this.Controls.Add(this.label_upload_format);
            this.Controls.Add(this.combobox_uploadimageformat);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "downloadru.settings_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Download.Ru settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.afterUploadGroupBox.ResumeLayout(false);
            this.afterUploadGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private GreenshotPlugin.Controls.GreenshotComboBox combobox_uploadimageformat;
		private GreenshotPlugin.Controls.GreenshotLabel label_upload_format;
		private GreenshotPlugin.Controls.GreenshotButton buttonCancel;
		private GreenshotPlugin.Controls.GreenshotButton buttonOK;
		private GreenshotPlugin.Controls.GreenshotCheckBox checkboxAfterUploadLinkToClipBoard;
        private GreenshotPlugin.Controls.GreenshotCheckBox checkboxAfterUploadSharedLink;
        private GreenshotPlugin.Controls.GreenshotGroupBox afterUploadGroupBox;
        private GreenshotPlugin.Controls.GreenshotComboBox toClipBoardComboBox;
        private GreenshotPlugin.Controls.GreenshotCheckBox showDetailsCheckBox;
        private GreenshotPlugin.Controls.GreenshotCheckBox openInBrowserCheckBox;
        private GreenshotPlugin.Controls.GreenshotCheckBox anonymousAccessCheckBox;
        private GreenshotPlugin.Controls.GreenshotComboBox openInBrowserComboBox;
    }
}
