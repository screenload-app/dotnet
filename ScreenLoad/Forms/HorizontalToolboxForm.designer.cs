namespace ScreenLoad
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
            this.expandMarkImageList = new System.Windows.Forms.ImageList(this.components);
            this.sep2Label = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.arrowButton = new System.Windows.Forms.RadioButton();
            this.pencilButton = new System.Windows.Forms.RadioButton();
            this.textButton = new System.Windows.Forms.RadioButton();
            this.blurButton = new System.Windows.Forms.RadioButton();
            this.counterButton = new System.Windows.Forms.RadioButton();
            this.selectButton = new System.Windows.Forms.RadioButton();
            this.sep1Label = new System.Windows.Forms.Label();
            this.markerButton = new System.Windows.Forms.RadioButton();
            this.shapesButton = new System.Windows.Forms.RadioButton();
            this.shapesImageList = new System.Windows.Forms.ImageList(this.components);
            this.shapesExpandButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // undoButton
            // 
            this.undoButton.Enabled = false;
            this.undoButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.undoButton.FlatAppearance.BorderSize = 0;
            this.undoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.Location = new System.Drawing.Point(439, 6);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(38, 38);
            this.undoButton.TabIndex = 12;
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Red;
            this.colorButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.colorButton.FlatAppearance.BorderSize = 0;
            this.colorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.colorButton.ImageKey = "White";
            this.colorButton.ImageList = this.expandMarkImageList;
            this.colorButton.Location = new System.Drawing.Point(388, 6);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(38, 38);
            this.colorButton.TabIndex = 10;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // expandMarkImageList
            // 
            this.expandMarkImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("expandMarkImageList.ImageStream")));
            this.expandMarkImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.expandMarkImageList.Images.SetKeyName(0, "Black");
            this.expandMarkImageList.Images.SetKeyName(1, "White");
            // 
            // sep2Label
            // 
            this.sep2Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sep2Label.Location = new System.Drawing.Point(431, 6);
            this.sep2Label.Name = "sep2Label";
            this.sep2Label.Size = new System.Drawing.Size(2, 38);
            this.sep2Label.TabIndex = 11;
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // arrowButton
            // 
            this.arrowButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.arrowButton.Checked = true;
            this.arrowButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.arrowButton.FlatAppearance.BorderSize = 0;
            this.arrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arrowButton.Image = ((System.Drawing.Image)(resources.GetObject("arrowButton.Image")));
            this.arrowButton.Location = new System.Drawing.Point(59, 6);
            this.arrowButton.Name = "arrowButton";
            this.arrowButton.Size = new System.Drawing.Size(38, 38);
            this.arrowButton.TabIndex = 2;
            this.arrowButton.TabStop = true;
            this.arrowButton.UseVisualStyleBackColor = true;
            this.arrowButton.Click += new System.EventHandler(this.ArrowButton_Click);
            // 
            // pencilButton
            // 
            this.pencilButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.pencilButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.pencilButton.FlatAppearance.BorderSize = 0;
            this.pencilButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pencilButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilButton.Image")));
            this.pencilButton.Location = new System.Drawing.Point(103, 6);
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.Size = new System.Drawing.Size(38, 38);
            this.pencilButton.TabIndex = 3;
            this.pencilButton.TabStop = true;
            this.pencilButton.UseVisualStyleBackColor = true;
            this.pencilButton.Click += new System.EventHandler(this.PencilButton_Click);
            // 
            // textButton
            // 
            this.textButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.textButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.textButton.FlatAppearance.BorderSize = 0;
            this.textButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textButton.Image = ((System.Drawing.Image)(resources.GetObject("textButton.Image")));
            this.textButton.Location = new System.Drawing.Point(256, 6);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(38, 38);
            this.textButton.TabIndex = 7;
            this.textButton.TabStop = true;
            this.textButton.UseVisualStyleBackColor = true;
            this.textButton.Click += new System.EventHandler(this.TextButton_Click);
            // 
            // blurButton
            // 
            this.blurButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.blurButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.blurButton.FlatAppearance.BorderSize = 0;
            this.blurButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blurButton.Image = ((System.Drawing.Image)(resources.GetObject("blurButton.Image")));
            this.blurButton.Location = new System.Drawing.Point(300, 6);
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(38, 38);
            this.blurButton.TabIndex = 8;
            this.blurButton.TabStop = true;
            this.blurButton.UseVisualStyleBackColor = true;
            this.blurButton.Click += new System.EventHandler(this.BlurButton_Click);
            // 
            // counterButton
            // 
            this.counterButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.counterButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.counterButton.FlatAppearance.BorderSize = 0;
            this.counterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.counterButton.Image = ((System.Drawing.Image)(resources.GetObject("counterButton.Image")));
            this.counterButton.Location = new System.Drawing.Point(344, 6);
            this.counterButton.Name = "counterButton";
            this.counterButton.Size = new System.Drawing.Size(38, 38);
            this.counterButton.TabIndex = 9;
            this.counterButton.TabStop = true;
            this.counterButton.UseVisualStyleBackColor = true;
            this.counterButton.Click += new System.EventHandler(this.CounterButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.selectButton.FlatAppearance.BorderSize = 0;
            this.selectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.Location = new System.Drawing.Point(6, 6);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(38, 38);
            this.selectButton.TabIndex = 0;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // sep1Label
            // 
            this.sep1Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sep1Label.Location = new System.Drawing.Point(51, 6);
            this.sep1Label.Name = "sep1Label";
            this.sep1Label.Size = new System.Drawing.Size(2, 38);
            this.sep1Label.TabIndex = 1;
            // 
            // markerButton
            // 
            this.markerButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.markerButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.markerButton.FlatAppearance.BorderSize = 0;
            this.markerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.markerButton.Image = ((System.Drawing.Image)(resources.GetObject("markerButton.Image")));
            this.markerButton.Location = new System.Drawing.Point(147, 6);
            this.markerButton.Name = "markerButton";
            this.markerButton.Size = new System.Drawing.Size(38, 38);
            this.markerButton.TabIndex = 4;
            this.markerButton.TabStop = true;
            this.markerButton.UseVisualStyleBackColor = true;
            this.markerButton.Click += new System.EventHandler(this.markerButton_Click);
            // 
            // shapesButton
            // 
            this.shapesButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.shapesButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.shapesButton.FlatAppearance.BorderSize = 0;
            this.shapesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shapesButton.ImageKey = "Rectangle";
            this.shapesButton.ImageList = this.shapesImageList;
            this.shapesButton.Location = new System.Drawing.Point(191, 6);
            this.shapesButton.Name = "shapesButton";
            this.shapesButton.Size = new System.Drawing.Size(38, 38);
            this.shapesButton.TabIndex = 5;
            this.shapesButton.TabStop = true;
            this.shapesButton.UseVisualStyleBackColor = true;
            this.shapesButton.CheckedChanged += new System.EventHandler(this.shapesButton_CheckedChanged);
            this.shapesButton.Click += new System.EventHandler(this.shapesButton_Click);
            // 
            // shapesImageList
            // 
            this.shapesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("shapesImageList.ImageStream")));
            this.shapesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.shapesImageList.Images.SetKeyName(0, "Rectangle");
            this.shapesImageList.Images.SetKeyName(1, "Ellipse");
            this.shapesImageList.Images.SetKeyName(2, "Line");
            // 
            // shapesExpandButton
            // 
            this.shapesExpandButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("shapesExpandButton.BackgroundImage")));
            this.shapesExpandButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.shapesExpandButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.shapesExpandButton.FlatAppearance.BorderSize = 0;
            this.shapesExpandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shapesExpandButton.ImageKey = "(none)";
            this.shapesExpandButton.Location = new System.Drawing.Point(229, 6);
            this.shapesExpandButton.Name = "shapesExpandButton";
            this.shapesExpandButton.Size = new System.Drawing.Size(21, 38);
            this.shapesExpandButton.TabIndex = 6;
            this.shapesExpandButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.shapesExpandButton.UseVisualStyleBackColor = true;
            this.shapesExpandButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shapesExpandButton_MouseDown);
            // 
            // HorizontalToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(482, 50);
            this.ControlBox = false;
            this.Controls.Add(this.shapesExpandButton);
            this.Controls.Add(this.shapesButton);
            this.Controls.Add(this.markerButton);
            this.Controls.Add(this.sep1Label);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.counterButton);
            this.Controls.Add(this.blurButton);
            this.Controls.Add(this.textButton);
            this.Controls.Add(this.pencilButton);
            this.Controls.Add(this.arrowButton);
            this.Controls.Add(this.sep2Label);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.HorizontalToolboxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label sep2Label;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.RadioButton arrowButton;
        private System.Windows.Forms.RadioButton pencilButton;
        private System.Windows.Forms.RadioButton textButton;
        private System.Windows.Forms.RadioButton blurButton;
        private System.Windows.Forms.RadioButton counterButton;
        private System.Windows.Forms.ImageList expandMarkImageList;
        private System.Windows.Forms.RadioButton selectButton;
        private System.Windows.Forms.Label sep1Label;
        private System.Windows.Forms.RadioButton markerButton;
        private System.Windows.Forms.RadioButton shapesButton;
        private System.Windows.Forms.ImageList shapesImageList;
        private System.Windows.Forms.Button shapesExpandButton;
    }
}