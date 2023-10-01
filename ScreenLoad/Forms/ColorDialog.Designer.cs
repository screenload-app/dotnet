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
namespace ScreenLoad {
	public partial class ColorDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorDialog));
            this.btnTransparent = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.labelHtmlColor = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.textBoxHtmlColor = new System.Windows.Forms.TextBox();
            this.labelRed = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.labelGreen = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.labelBlue = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.textBoxRed = new System.Windows.Forms.TextBox();
            this.textBoxGreen = new System.Windows.Forms.TextBox();
            this.textBoxBlue = new System.Windows.Forms.TextBox();
            this.labelRecentColors = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.labelAlpha = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.btnApply = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.pipette = new ScreenLoad.Controls.Pipette();
            this.SuspendLayout();
            // 
            // btnTransparent
            // 
            this.btnTransparent.BackColor = System.Drawing.Color.Transparent;
            this.btnTransparent.LanguageKey = "colorpicker_transparent";
            this.btnTransparent.Location = new System.Drawing.Point(222, 12);
            this.btnTransparent.Name = "btnTransparent";
            this.btnTransparent.Size = new System.Drawing.Size(173, 24);
            this.btnTransparent.TabIndex = 0;
            this.btnTransparent.TabStop = false;
            this.btnTransparent.Text = "Transparent";
            this.btnTransparent.UseVisualStyleBackColor = false;
            this.btnTransparent.Click += new System.EventHandler(this.BtnTransparentClick);
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel.Location = new System.Drawing.Point(321, 42);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(34, 24);
            this.colorPanel.TabIndex = 1;
            // 
            // labelHtmlColor
            // 
            this.labelHtmlColor.AutoSize = true;
            this.labelHtmlColor.LanguageKey = "colorpicker_htmlcolor";
            this.labelHtmlColor.Location = new System.Drawing.Point(219, 75);
            this.labelHtmlColor.Name = "labelHtmlColor";
            this.labelHtmlColor.Size = new System.Drawing.Size(63, 13);
            this.labelHtmlColor.TabIndex = 2;
            this.labelHtmlColor.Text = "HTML color";
            // 
            // textBoxHtmlColor
            // 
            this.textBoxHtmlColor.Location = new System.Drawing.Point(321, 72);
            this.textBoxHtmlColor.Name = "textBoxHtmlColor";
            this.textBoxHtmlColor.Size = new System.Drawing.Size(74, 20);
            this.textBoxHtmlColor.TabIndex = 1;
            this.textBoxHtmlColor.Click += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxHtmlColor.TextChanged += new System.EventHandler(this.TextBoxHexadecimalTextChanged);
            this.textBoxHtmlColor.GotFocus += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxHtmlColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.LanguageKey = "colorpicker_red";
            this.labelRed.Location = new System.Drawing.Point(219, 101);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(27, 13);
            this.labelRed.TabIndex = 4;
            this.labelRed.Text = "Red";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.LanguageKey = "colorpicker_green";
            this.labelGreen.Location = new System.Drawing.Point(219, 127);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(36, 13);
            this.labelGreen.TabIndex = 5;
            this.labelGreen.Text = "Green";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.LanguageKey = "colorpicker_blue";
            this.labelBlue.Location = new System.Drawing.Point(219, 153);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(28, 13);
            this.labelBlue.TabIndex = 6;
            this.labelBlue.Text = "Blue";
            // 
            // textBoxRed
            // 
            this.textBoxRed.Location = new System.Drawing.Point(321, 98);
            this.textBoxRed.Name = "textBoxRed";
            this.textBoxRed.Size = new System.Drawing.Size(74, 20);
            this.textBoxRed.TabIndex = 2;
            this.textBoxRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxRed.Click += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxRed.TextChanged += new System.EventHandler(this.TextBoxRgbTextChanged);
            this.textBoxRed.GotFocus += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxRed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // textBoxGreen
            // 
            this.textBoxGreen.Location = new System.Drawing.Point(321, 124);
            this.textBoxGreen.Name = "textBoxGreen";
            this.textBoxGreen.Size = new System.Drawing.Size(74, 20);
            this.textBoxGreen.TabIndex = 3;
            this.textBoxGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxGreen.Click += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxGreen.TextChanged += new System.EventHandler(this.TextBoxRgbTextChanged);
            this.textBoxGreen.GotFocus += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxGreen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // textBoxBlue
            // 
            this.textBoxBlue.Location = new System.Drawing.Point(321, 150);
            this.textBoxBlue.Name = "textBoxBlue";
            this.textBoxBlue.Size = new System.Drawing.Size(74, 20);
            this.textBoxBlue.TabIndex = 4;
            this.textBoxBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxBlue.Click += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxBlue.TextChanged += new System.EventHandler(this.TextBoxRgbTextChanged);
            this.textBoxBlue.GotFocus += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxBlue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // labelRecentColors
            // 
            this.labelRecentColors.AutoSize = true;
            this.labelRecentColors.LanguageKey = "colorpicker_recentcolors";
            this.labelRecentColors.Location = new System.Drawing.Point(9, 189);
            this.labelRecentColors.Name = "labelRecentColors";
            this.labelRecentColors.Size = new System.Drawing.Size(106, 13);
            this.labelRecentColors.TabIndex = 10;
            this.labelRecentColors.Text = "Recently used colors";
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(321, 176);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(74, 20);
            this.textBoxAlpha.TabIndex = 5;
            this.textBoxAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAlpha.Click += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxAlpha.TextChanged += new System.EventHandler(this.TextBoxRgbTextChanged);
            this.textBoxAlpha.GotFocus += new System.EventHandler(this.TextBoxGotFocus);
            this.textBoxAlpha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.LanguageKey = "colorpicker_alpha";
            this.labelAlpha.Location = new System.Drawing.Point(219, 179);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(34, 13);
            this.labelAlpha.TabIndex = 11;
            this.labelAlpha.Text = "Alpha";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Transparent;
            this.btnApply.LanguageKey = "colorpicker_apply";
            this.btnApply.Location = new System.Drawing.Point(222, 202);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(173, 24);
            this.btnApply.TabIndex = 12;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
            // 
            // pipette
            // 
            this.pipette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pipette.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pipette.Image = ((System.Drawing.Image)(resources.GetObject("pipette.Image")));
            this.pipette.Location = new System.Drawing.Point(361, 42);
            this.pipette.Name = "pipette";
            this.pipette.Size = new System.Drawing.Size(34, 24);
            this.pipette.TabIndex = 13;
            this.pipette.PipetteUsed += new System.EventHandler<ScreenLoad.Controls.PipetteUsedArgs>(this.PipetteUsed);
            // 
            // ColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(407, 239);
            this.Controls.Add(this.pipette);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.textBoxAlpha);
            this.Controls.Add(this.labelAlpha);
            this.Controls.Add(this.labelRecentColors);
            this.Controls.Add(this.textBoxBlue);
            this.Controls.Add(this.textBoxGreen);
            this.Controls.Add(this.textBoxRed);
            this.Controls.Add(this.labelBlue);
            this.Controls.Add(this.labelGreen);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.textBoxHtmlColor);
            this.Controls.Add(this.labelHtmlColor);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.btnTransparent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "colorpicker_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Color picker";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private ScreenLoadPlugin.Controls.ScreenLoadLabel labelRed;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel labelGreen;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel labelBlue;
		private System.Windows.Forms.TextBox textBoxHtmlColor;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel labelRecentColors;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel labelAlpha;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel labelHtmlColor;
		private ScreenLoadPlugin.Controls.ScreenLoadButton btnApply;
		private System.Windows.Forms.TextBox textBoxAlpha;
		private System.Windows.Forms.TextBox textBoxRed;
		private System.Windows.Forms.TextBox textBoxGreen;
		private System.Windows.Forms.TextBox textBoxBlue;
		private System.Windows.Forms.Panel colorPanel;
		private ScreenLoadPlugin.Controls.ScreenLoadButton btnTransparent;
		private ScreenLoad.Controls.Pipette pipette;
	}
}
