namespace ScreenLoad.Forms
{
    partial class MovableShowColorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovableShowColorForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.alpha = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.label5 = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.blue = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.label6 = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.green = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.label4 = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.red = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.label2 = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.html = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.preview = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.alpha);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.blue);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.green);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.red);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.html);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.preview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 99);
            this.panel1.TabIndex = 0;
            // 
            // alpha
            // 
            this.alpha.Location = new System.Drawing.Point(78, 76);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(35, 13);
            this.alpha.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.LanguageKey = "colorpicker_alpha";
            this.label5.Location = new System.Drawing.Point(2, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alpha";
            // 
            // blue
            // 
            this.blue.Location = new System.Drawing.Point(78, 63);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(35, 13);
            this.blue.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.LanguageKey = "colorpicker_blue";
            this.label6.Location = new System.Drawing.Point(2, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Blue";
            // 
            // green
            // 
            this.green.Location = new System.Drawing.Point(78, 50);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(35, 13);
            this.green.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.LanguageKey = "colorpicker_green";
            this.label4.Location = new System.Drawing.Point(2, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Green";
            // 
            // red
            // 
            this.red.Location = new System.Drawing.Point(78, 37);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(35, 13);
            this.red.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.LanguageKey = "colorpicker_red";
            this.label2.Location = new System.Drawing.Point(2, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Red";
            // 
            // html
            // 
            this.html.Location = new System.Drawing.Point(40, 18);
            this.html.Name = "html";
            this.html.Size = new System.Drawing.Size(73, 19);
            this.html.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HTML";
            // 
            // preview
            // 
            this.preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preview.Location = new System.Drawing.Point(5, 5);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(32, 32);
            this.preview.TabIndex = 0;
            // 
            // MovableShowColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(118, 99);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(-10000, -10000);
            this.Name = "MovableShowColorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label html;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label preview;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel alpha;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel label5;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel blue;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel label6;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel green;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel label4;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel red;
        private ScreenLoadPlugin.Controls.ScreenLoadLabel label2;
    }
}
