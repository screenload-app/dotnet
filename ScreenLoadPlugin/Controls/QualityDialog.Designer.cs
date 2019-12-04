/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The ScreenLoad project is hosted on GitHub https://github.com/greenshot/greenshot
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
namespace ScreenLoadPlugin.Controls {
	partial class QualityDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualityDialog));
            this.label_choosejpegquality = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.textBoxJpegQuality = new System.Windows.Forms.TextBox();
            this.trackBarJpegQuality = new System.Windows.Forms.TrackBar();
            this.checkbox_dontaskagain = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.button_ok = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.checkBox_reduceColors = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarJpegQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // label_choosejpegquality
            // 
            this.label_choosejpegquality.AutoSize = true;
            this.label_choosejpegquality.LanguageKey = "jpegqualitydialog_choosejpegquality";
            this.label_choosejpegquality.Location = new System.Drawing.Point(12, 53);
            this.label_choosejpegquality.Name = "label_choosejpegquality";
            this.label_choosejpegquality.Size = new System.Drawing.Size(230, 13);
            this.label_choosejpegquality.TabIndex = 15;
            this.label_choosejpegquality.Text = "Please choose the JPEG quality for your image.";
            // 
            // textBoxJpegQuality
            // 
            this.textBoxJpegQuality.Location = new System.Drawing.Point(357, 69);
            this.textBoxJpegQuality.Name = "textBoxJpegQuality";
            this.textBoxJpegQuality.ReadOnly = true;
            this.textBoxJpegQuality.Size = new System.Drawing.Size(35, 20);
            this.textBoxJpegQuality.TabIndex = 4;
            this.textBoxJpegQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // trackBarJpegQuality
            // 
            this.trackBarJpegQuality.LargeChange = 10;
            this.trackBarJpegQuality.Location = new System.Drawing.Point(12, 69);
            this.trackBarJpegQuality.Maximum = 100;
            this.trackBarJpegQuality.Name = "trackBarJpegQuality";
            this.trackBarJpegQuality.Size = new System.Drawing.Size(339, 45);
            this.trackBarJpegQuality.TabIndex = 3;
            this.trackBarJpegQuality.TickFrequency = 10;
            this.trackBarJpegQuality.Scroll += new System.EventHandler(this.TrackBarJpegQualityScroll);
            // 
            // checkbox_dontaskagain
            // 
            this.checkbox_dontaskagain.AutoSize = true;
            this.checkbox_dontaskagain.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkbox_dontaskagain.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkbox_dontaskagain.LanguageKey = "qualitydialog_dontaskagain";
            this.checkbox_dontaskagain.Location = new System.Drawing.Point(15, 120);
            this.checkbox_dontaskagain.Name = "checkbox_dontaskagain";
            this.checkbox_dontaskagain.Size = new System.Drawing.Size(236, 17);
            this.checkbox_dontaskagain.TabIndex = 5;
            this.checkbox_dontaskagain.Text = "Save as default quality and do not ask again";
            this.checkbox_dontaskagain.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkbox_dontaskagain.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_ok.LanguageKey = "OK";
            this.button_ok.Location = new System.Drawing.Point(317, 160);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_okClick);
            // 
            // checkBox_reduceColors
            // 
            this.checkBox_reduceColors.AutoSize = true;
            this.checkBox_reduceColors.LanguageKey = "settings_reducecolors";
            this.checkBox_reduceColors.Location = new System.Drawing.Point(12, 12);
            this.checkBox_reduceColors.Name = "checkBox_reduceColors";
            this.checkBox_reduceColors.Size = new System.Drawing.Size(263, 17);
            this.checkBox_reduceColors.TabIndex = 2;
            this.checkBox_reduceColors.Text = "Reduce the amount of colors to a maximum of 256";
            this.checkBox_reduceColors.UseVisualStyleBackColor = true;
            // 
            // QualityDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(404, 195);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_reduceColors);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.checkbox_dontaskagain);
            this.Controls.Add(this.label_choosejpegquality);
            this.Controls.Add(this.textBoxJpegQuality);
            this.Controls.Add(this.trackBarJpegQuality);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "qualitydialog_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QualityDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ScreenLoad quality";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarJpegQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private ScreenLoadPlugin.Controls.ScreenLoadButton button_ok;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_dontaskagain;
		private System.Windows.Forms.TrackBar trackBarJpegQuality;
		private System.Windows.Forms.TextBox textBoxJpegQuality;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_choosejpegquality;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkBox_reduceColors;
	}
}
