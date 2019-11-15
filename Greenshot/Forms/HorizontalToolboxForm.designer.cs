namespace Greenshot
{
    partial class HorizontalToolboxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HorizontalToolboxForm));
            this.undoButton = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.sep1Label = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.arrowButton = new System.Windows.Forms.RadioButton();
            this.pencilButton = new System.Windows.Forms.RadioButton();
            this.rectangleButton = new System.Windows.Forms.RadioButton();
            this.textButton = new System.Windows.Forms.RadioButton();
            this.blurButton = new System.Windows.Forms.RadioButton();
            this.counterButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // undoButton
            // 
            this.undoButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.undoButton.FlatAppearance.BorderSize = 0;
            this.undoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.undoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.undoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.Location = new System.Drawing.Point(322, 6);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(38, 38);
            this.undoButton.TabIndex = 8;
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Red;
            this.colorButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.colorButton.FlatAppearance.BorderSize = 0;
            this.colorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.Image = ((System.Drawing.Image)(resources.GetObject("colorButton.Image")));
            this.colorButton.Location = new System.Drawing.Point(270, 6);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(38, 38);
            this.colorButton.TabIndex = 6;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // sep1Label
            // 
            this.sep1Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sep1Label.Location = new System.Drawing.Point(314, 6);
            this.sep1Label.Name = "sep1Label";
            this.sep1Label.Size = new System.Drawing.Size(2, 38);
            this.sep1Label.TabIndex = 7;
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // arrowButton
            // 
            this.arrowButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.arrowButton.Checked = true;
            this.arrowButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.arrowButton.FlatAppearance.BorderSize = 0;
            this.arrowButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.arrowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.arrowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.arrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arrowButton.Image = ((System.Drawing.Image)(resources.GetObject("arrowButton.Image")));
            this.arrowButton.Location = new System.Drawing.Point(6, 6);
            this.arrowButton.Name = "arrowButton";
            this.arrowButton.Size = new System.Drawing.Size(38, 38);
            this.arrowButton.TabIndex = 0;
            this.arrowButton.TabStop = true;
            this.arrowButton.UseVisualStyleBackColor = true;
            this.arrowButton.Click += new System.EventHandler(this.ArrowButton_Click);
            // 
            // pencilButton
            // 
            this.pencilButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.pencilButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.pencilButton.FlatAppearance.BorderSize = 0;
            this.pencilButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.pencilButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.pencilButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.pencilButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pencilButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilButton.Image")));
            this.pencilButton.Location = new System.Drawing.Point(50, 6);
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.Size = new System.Drawing.Size(38, 38);
            this.pencilButton.TabIndex = 1;
            this.pencilButton.UseVisualStyleBackColor = true;
            this.pencilButton.Click += new System.EventHandler(this.PencilButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.rectangleButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.rectangleButton.FlatAppearance.BorderSize = 0;
            this.rectangleButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.rectangleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.rectangleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.rectangleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
            this.rectangleButton.Location = new System.Drawing.Point(94, 6);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(38, 38);
            this.rectangleButton.TabIndex = 2;
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // textButton
            // 
            this.textButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.textButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.textButton.FlatAppearance.BorderSize = 0;
            this.textButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.textButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.textButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.textButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textButton.Image = ((System.Drawing.Image)(resources.GetObject("textButton.Image")));
            this.textButton.Location = new System.Drawing.Point(138, 6);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(38, 38);
            this.textButton.TabIndex = 3;
            this.textButton.UseVisualStyleBackColor = true;
            this.textButton.Click += new System.EventHandler(this.TextButton_Click);
            // 
            // blurButton
            // 
            this.blurButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.blurButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.blurButton.FlatAppearance.BorderSize = 0;
            this.blurButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.blurButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.blurButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.blurButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blurButton.Image = ((System.Drawing.Image)(resources.GetObject("blurButton.Image")));
            this.blurButton.Location = new System.Drawing.Point(182, 6);
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(38, 38);
            this.blurButton.TabIndex = 4;
            this.blurButton.UseVisualStyleBackColor = true;
            this.blurButton.Click += new System.EventHandler(this.BlurButton_Click);
            // 
            // counterButton
            // 
            this.counterButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.counterButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.counterButton.FlatAppearance.BorderSize = 0;
            this.counterButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.counterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.counterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.counterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.counterButton.Image = ((System.Drawing.Image)(resources.GetObject("counterButton.Image")));
            this.counterButton.Location = new System.Drawing.Point(226, 6);
            this.counterButton.Name = "counterButton";
            this.counterButton.Size = new System.Drawing.Size(38, 38);
            this.counterButton.TabIndex = 5;
            this.counterButton.UseVisualStyleBackColor = true;
            this.counterButton.Click += new System.EventHandler(this.CounterButton_Click);
            // 
            // HorizontalToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(366, 50);
            this.ControlBox = false;
            this.Controls.Add(this.counterButton);
            this.Controls.Add(this.blurButton);
            this.Controls.Add(this.textButton);
            this.Controls.Add(this.rectangleButton);
            this.Controls.Add(this.pencilButton);
            this.Controls.Add(this.arrowButton);
            this.Controls.Add(this.sep1Label);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.colorButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "HorizontalToolboxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.HorizontalToolboxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label sep1Label;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.RadioButton arrowButton;
        private System.Windows.Forms.RadioButton pencilButton;
        private System.Windows.Forms.RadioButton rectangleButton;
        private System.Windows.Forms.RadioButton textButton;
        private System.Windows.Forms.RadioButton blurButton;
        private System.Windows.Forms.RadioButton counterButton;
    }
}