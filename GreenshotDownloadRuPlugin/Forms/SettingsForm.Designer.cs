﻿/*
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
            this.buttonOK = new GreenshotPlugin.Controls.GreenshotButton();
            this.buttonCancel = new GreenshotPlugin.Controls.GreenshotButton();
            this.combobox_uploadimageformat = new GreenshotPlugin.Controls.GreenshotComboBox();
            this.label_upload_format = new GreenshotPlugin.Controls.GreenshotLabel();
            this.label_AfterUpload = new GreenshotPlugin.Controls.GreenshotLabel();
            this.checkboxAfterUploadLinkToClipBoard = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.checkbox_anonymous_access = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.label_anonymous_access = new GreenshotPlugin.Controls.GreenshotLabel();
            this.checkboxAfterUploadSharedLink = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.greenshotLabel1 = new GreenshotPlugin.Controls.GreenshotLabel();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.LanguageKey = "OK";
            this.buttonOK.Location = new System.Drawing.Point(267, 119);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.LanguageKey = "CANCEL";
            this.buttonCancel.Location = new System.Drawing.Point(348, 119);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // combobox_uploadimageformat
            // 
            this.combobox_uploadimageformat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.combobox_uploadimageformat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_uploadimageformat.FormattingEnabled = true;
            this.combobox_uploadimageformat.Location = new System.Drawing.Point(208, 12);
            this.combobox_uploadimageformat.Name = "combobox_uploadimageformat";
            this.combobox_uploadimageformat.PropertyName = "UploadFormat";
            this.combobox_uploadimageformat.SectionName = "DownloadRu";
            this.combobox_uploadimageformat.Size = new System.Drawing.Size(215, 21);
            this.combobox_uploadimageformat.TabIndex = 5;
            // 
            // label_upload_format
            // 
            this.label_upload_format.LanguageKey = "downloadru.label_upload_format";
            this.label_upload_format.Location = new System.Drawing.Point(10, 12);
            this.label_upload_format.Name = "label_upload_format";
            this.label_upload_format.Size = new System.Drawing.Size(192, 20);
            this.label_upload_format.TabIndex = 4;
            this.label_upload_format.Text = "Image format";
            // 
            // label_AfterUpload
            // 
            this.label_AfterUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_AfterUpload.LanguageKey = "downloadru.label_AfterUpload";
            this.label_AfterUpload.Location = new System.Drawing.Point(10, 44);
            this.label_AfterUpload.Name = "label_AfterUpload";
            this.label_AfterUpload.Size = new System.Drawing.Size(179, 21);
            this.label_AfterUpload.TabIndex = 8;
            this.label_AfterUpload.Text = "After upload";
            // 
            // checkboxAfterUploadLinkToClipBoard
            // 
            this.checkboxAfterUploadLinkToClipBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkboxAfterUploadLinkToClipBoard.AutoSize = true;
            this.checkboxAfterUploadLinkToClipBoard.LanguageKey = "downloadru.label_AfterUploadLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.Location = new System.Drawing.Point(208, 43);
            this.checkboxAfterUploadLinkToClipBoard.Name = "checkboxAfterUploadLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.PropertyName = "AfterUploadLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.SectionName = "DownloadRu";
            this.checkboxAfterUploadLinkToClipBoard.Size = new System.Drawing.Size(104, 17);
            this.checkboxAfterUploadLinkToClipBoard.TabIndex = 10;
            this.checkboxAfterUploadLinkToClipBoard.Text = "Link to clipboard";
            this.checkboxAfterUploadLinkToClipBoard.UseVisualStyleBackColor = true;
            // 
            // checkbox_anonymous_access
            // 
            this.checkbox_anonymous_access.AutoSize = true;
            this.checkbox_anonymous_access.Location = new System.Drawing.Point(208, 95);
            this.checkbox_anonymous_access.Name = "checkbox_anonymous_access";
            this.checkbox_anonymous_access.PropertyName = "AnonymousAccess";
            this.checkbox_anonymous_access.SectionName = "DownloadRu";
            this.checkbox_anonymous_access.Size = new System.Drawing.Size(15, 14);
            this.checkbox_anonymous_access.TabIndex = 14;
            this.checkbox_anonymous_access.UseVisualStyleBackColor = true;
            // 
            // label_anonymous_access
            // 
            this.label_anonymous_access.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_anonymous_access.LanguageKey = "downloadru.anonymous_access";
            this.label_anonymous_access.Location = new System.Drawing.Point(10, 95);
            this.label_anonymous_access.Name = "label_anonymous_access";
            this.label_anonymous_access.Size = new System.Drawing.Size(192, 21);
            this.label_anonymous_access.TabIndex = 15;
            this.label_anonymous_access.Text = "Use anonym access";
            // 
            // checkboxAfterUploadSharedLink
            // 
            this.checkboxAfterUploadSharedLink.AccessibleName = "";
            this.checkboxAfterUploadSharedLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkboxAfterUploadSharedLink.AutoSize = true;
            this.checkboxAfterUploadSharedLink.LanguageKey = "downloadru.label_AfterUploadSharedLink";
            this.checkboxAfterUploadSharedLink.Location = new System.Drawing.Point(208, 68);
            this.checkboxAfterUploadSharedLink.Name = "checkboxAfterUploadSharedLink";
            this.checkboxAfterUploadSharedLink.PropertyName = "SharedLink";
            this.checkboxAfterUploadSharedLink.SectionName = "DownloadRu";
            this.checkboxAfterUploadSharedLink.Size = new System.Drawing.Size(85, 17);
            this.checkboxAfterUploadSharedLink.TabIndex = 17;
            this.checkboxAfterUploadSharedLink.Text = "Share image";
            this.checkboxAfterUploadSharedLink.UseVisualStyleBackColor = true;
            // 
            // greenshotLabel1
            // 
            this.greenshotLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.greenshotLabel1.LanguageKey = "downloadru.label_AfterUpload";
            this.greenshotLabel1.Location = new System.Drawing.Point(10, 69);
            this.greenshotLabel1.Name = "greenshotLabel1";
            this.greenshotLabel1.Size = new System.Drawing.Size(179, 21);
            this.greenshotLabel1.TabIndex = 16;
            this.greenshotLabel1.Text = "After upload";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(432, 151);
            this.Controls.Add(this.checkboxAfterUploadSharedLink);
            this.Controls.Add(this.greenshotLabel1);
            this.Controls.Add(this.label_anonymous_access);
            this.Controls.Add(this.checkbox_anonymous_access);
            this.Controls.Add(this.checkboxAfterUploadLinkToClipBoard);
            this.Controls.Add(this.label_AfterUpload);
            this.Controls.Add(this.label_upload_format);
            this.Controls.Add(this.combobox_uploadimageformat);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LanguageKey = "downloadru.settings_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "DownloadRu settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private GreenshotPlugin.Controls.GreenshotComboBox combobox_uploadimageformat;
		private GreenshotPlugin.Controls.GreenshotLabel label_upload_format;
		private GreenshotPlugin.Controls.GreenshotButton buttonCancel;
		private GreenshotPlugin.Controls.GreenshotButton buttonOK;
		private GreenshotPlugin.Controls.GreenshotLabel label_AfterUpload;
		private GreenshotPlugin.Controls.GreenshotCheckBox checkboxAfterUploadLinkToClipBoard;
        private GreenshotPlugin.Controls.GreenshotCheckBox checkbox_anonymous_access;
        private GreenshotPlugin.Controls.GreenshotLabel label_anonymous_access;
        private GreenshotPlugin.Controls.GreenshotCheckBox checkboxAfterUploadSharedLink;
        private GreenshotPlugin.Controls.GreenshotLabel greenshotLabel1;
	}
}
