/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
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

using System.Reflection;

namespace Greenshot {
	partial class AboutForm {
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
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
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLicense = new GreenshotPlugin.Controls.GreenshotLabel();
            this.lblHost = new GreenshotPlugin.Controls.GreenshotLabel();
            this.linkLblLicense = new System.Windows.Forms.LinkLabel();
            this.linkLblHost = new System.Windows.Forms.LinkLabel();
            this.linkLblBugs = new System.Windows.Forms.LinkLabel();
            this.lblBugs = new GreenshotPlugin.Controls.GreenshotLabel();
            this.linkLblDonations = new System.Windows.Forms.LinkLabel();
            this.lblDonations = new GreenshotPlugin.Controls.GreenshotLabel();
            this.linkLblIcons = new System.Windows.Forms.LinkLabel();
            this.lblIcons = new GreenshotPlugin.Controls.GreenshotLabel();
            this.downloadRuLinkLabel = new System.Windows.Forms.LinkLabel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.lblTranslation = new GreenshotPlugin.Controls.GreenshotLabel();
            this.helpButton = new System.Windows.Forms.Button();
            this.donateButton = new System.Windows.Forms.Button();
            this.updatesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(109, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(263, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Greenshot x.x.xxx";
            // 
            // lblLicense
            // 
            this.lblLicense.LanguageKey = "about_license";
            this.lblLicense.Location = new System.Drawing.Point(108, 31);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(399, 71);
            this.lblLicense.TabIndex = 2;
            this.lblLicense.Text = resources.GetString("lblLicense.Text");
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.LanguageKey = "about_host";
            this.lblHost.Location = new System.Drawing.Point(15, 108);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(197, 13);
            this.lblHost.TabIndex = 4;
            this.lblHost.Text = "Greenshot is hosted by Download.RU at";
            // 
            // linkLblLicense
            // 
            this.linkLblLicense.Location = new System.Drawing.Point(109, 85);
            this.linkLblLicense.Name = "linkLblLicense";
            this.linkLblLicense.Size = new System.Drawing.Size(369, 23);
            this.linkLblLicense.TabIndex = 3;
            this.linkLblLicense.TabStop = true;
            this.linkLblLicense.Text = "http://www.gnu.org/licenses/gpl.html";
            this.linkLblLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // linkLblHost
            // 
            this.linkLblHost.AutoSize = true;
            this.linkLblHost.Location = new System.Drawing.Point(15, 127);
            this.linkLblHost.Name = "linkLblHost";
            this.linkLblHost.Size = new System.Drawing.Size(173, 13);
            this.linkLblHost.TabIndex = 5;
            this.linkLblHost.TabStop = true;
            this.linkLblHost.Text = "https://download.ru/greenshot/get";
            this.linkLblHost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // linkLblBugs
            // 
            this.linkLblBugs.AutoSize = true;
            this.linkLblBugs.Location = new System.Drawing.Point(15, 173);
            this.linkLblBugs.Name = "linkLblBugs";
            this.linkLblBugs.Size = new System.Drawing.Size(219, 13);
            this.linkLblBugs.TabIndex = 7;
            this.linkLblBugs.TabStop = true;
            this.linkLblBugs.Text = "http://getgreenshot.org/tickets/?version={0}";
            this.linkLblBugs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // lblBugs
            // 
            this.lblBugs.AutoSize = true;
            this.lblBugs.LanguageKey = "about_bugs";
            this.lblBugs.Location = new System.Drawing.Point(15, 154);
            this.lblBugs.Name = "lblBugs";
            this.lblBugs.Size = new System.Drawing.Size(107, 13);
            this.lblBugs.TabIndex = 6;
            this.lblBugs.Text = "Please report bugs to";
            // 
            // linkLblDonations
            // 
            this.linkLblDonations.AutoSize = true;
            this.linkLblDonations.Location = new System.Drawing.Point(15, 219);
            this.linkLblDonations.Name = "linkLblDonations";
            this.linkLblDonations.Size = new System.Drawing.Size(223, 13);
            this.linkLblDonations.TabIndex = 9;
            this.linkLblDonations.TabStop = true;
            this.linkLblDonations.Text = "http://getgreenshot.org/support/?version={0}";
            this.linkLblDonations.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // lblDonations
            // 
            this.lblDonations.AutoSize = true;
            this.lblDonations.LanguageKey = "about_donations";
            this.lblDonations.Location = new System.Drawing.Point(15, 200);
            this.lblDonations.Name = "lblDonations";
            this.lblDonations.Size = new System.Drawing.Size(257, 13);
            this.lblDonations.TabIndex = 8;
            this.lblDonations.Text = "If you like Greenshot, you are welcome to support us:";
            // 
            // linkLblIcons
            // 
            this.linkLblIcons.AutoSize = true;
            this.linkLblIcons.Location = new System.Drawing.Point(15, 265);
            this.linkLblIcons.Name = "linkLblIcons";
            this.linkLblIcons.Size = new System.Drawing.Size(163, 13);
            this.linkLblIcons.TabIndex = 11;
            this.linkLblIcons.TabStop = true;
            this.linkLblIcons.Text = "http://p.yusukekamiyamane.com";
            this.linkLblIcons.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // lblIcons
            // 
            this.lblIcons.AutoSize = true;
            this.lblIcons.LanguageKey = "about_icons";
            this.lblIcons.Location = new System.Drawing.Point(15, 246);
            this.lblIcons.Name = "lblIcons";
            this.lblIcons.Size = new System.Drawing.Size(439, 13);
            this.lblIcons.TabIndex = 10;
            this.lblIcons.Text = "Icons from Yusuke Kamiyamane\'s Fugue icon set (Creative Commons Attribution 3.0 l" +
    "icense)";
            // 
            // downloadRuLinkLabel
            // 
            this.downloadRuLinkLabel.Location = new System.Drawing.Point(394, 9);
            this.downloadRuLinkLabel.Name = "downloadRuLinkLabel";
            this.downloadRuLinkLabel.Size = new System.Drawing.Size(113, 23);
            this.downloadRuLinkLabel.TabIndex = 1;
            this.downloadRuLinkLabel.TabStop = true;
            this.downloadRuLinkLabel.Text = "https://download.ru";
            this.downloadRuLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.downloadRuLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClicked);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(90, 90);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 14;
            this.logoPictureBox.TabStop = false;
            // 
            // lblTranslation
            // 
            this.lblTranslation.AutoSize = true;
            this.lblTranslation.LanguageKey = "about_translation";
            this.lblTranslation.Location = new System.Drawing.Point(15, 293);
            this.lblTranslation.Name = "lblTranslation";
            this.lblTranslation.Size = new System.Drawing.Size(0, 13);
            this.lblTranslation.TabIndex = 12;
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.helpButton.Location = new System.Drawing.Point(12, 322);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(161, 23);
            this.helpButton.TabIndex = 13;
            this.helpButton.Text = "Справка";
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // donateButton
            // 
            this.donateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.donateButton.Location = new System.Drawing.Point(179, 322);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(161, 23);
            this.donateButton.TabIndex = 14;
            this.donateButton.Text = "Поддержать автора";
            this.donateButton.UseVisualStyleBackColor = true;
            // 
            // updatesButton
            // 
            this.updatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updatesButton.Location = new System.Drawing.Point(346, 322);
            this.updatesButton.Name = "updatesButton";
            this.updatesButton.Size = new System.Drawing.Size(161, 23);
            this.updatesButton.TabIndex = 15;
            this.updatesButton.Text = "Проверить обновления";
            this.updatesButton.UseVisualStyleBackColor = true;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(519, 360);
            this.Controls.Add(this.updatesButton);
            this.Controls.Add(this.donateButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.lblTranslation);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.downloadRuLinkLabel);
            this.Controls.Add(this.linkLblIcons);
            this.Controls.Add(this.lblIcons);
            this.Controls.Add(this.linkLblDonations);
            this.Controls.Add(this.lblDonations);
            this.Controls.Add(this.linkLblBugs);
            this.Controls.Add(this.lblBugs);
            this.Controls.Add(this.linkLblHost);
            this.Controls.Add(this.linkLblLicense);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "about_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Greenshot";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.LinkLabel downloadRuLinkLabel;
		private System.Windows.Forms.LinkLabel linkLblHost;
		private System.Windows.Forms.LinkLabel linkLblDonations;
		private System.Windows.Forms.LinkLabel linkLblBugs;
		private System.Windows.Forms.LinkLabel linkLblLicense;
		private System.Windows.Forms.LinkLabel linkLblIcons;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private GreenshotPlugin.Controls.GreenshotLabel lblTranslation;
		private GreenshotPlugin.Controls.GreenshotLabel lblHost;
		private GreenshotPlugin.Controls.GreenshotLabel lblDonations;
		private GreenshotPlugin.Controls.GreenshotLabel lblBugs;
		private GreenshotPlugin.Controls.GreenshotLabel lblIcons;
		private GreenshotPlugin.Controls.GreenshotLabel lblLicense;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button donateButton;
        private System.Windows.Forms.Button updatesButton;
    }
}
