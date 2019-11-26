namespace Greenshot
{
    partial class VerticalToolboxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerticalToolboxForm));
            this.sep1Label = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.moreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sep1Label
            // 
            this.sep1Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sep1Label.Location = new System.Drawing.Point(6, 179);
            this.sep1Label.Name = "sep1Label";
            this.sep1Label.Size = new System.Drawing.Size(38, 2);
            this.sep1Label.TabIndex = 4;
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(6, 184);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(38, 38);
            this.closeButton.TabIndex = 5;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(6, 94);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(38, 38);
            this.saveButton.TabIndex = 2;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.copyButton.FlatAppearance.BorderSize = 0;
            this.copyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyButton.Image = ((System.Drawing.Image)(resources.GetObject("copyButton.Image")));
            this.copyButton.Location = new System.Drawing.Point(6, 50);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(38, 38);
            this.copyButton.TabIndex = 1;
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.uploadButton.FlatAppearance.BorderSize = 0;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Image = ((System.Drawing.Image)(resources.GetObject("uploadButton.Image")));
            this.uploadButton.Location = new System.Drawing.Point(6, 6);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(38, 38);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // moreButton
            // 
            this.moreButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.moreButton.FlatAppearance.BorderSize = 0;
            this.moreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moreButton.Image = ((System.Drawing.Image)(resources.GetObject("moreButton.Image")));
            this.moreButton.Location = new System.Drawing.Point(6, 138);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(38, 38);
            this.moreButton.TabIndex = 3;
            this.moreButton.UseVisualStyleBackColor = true;
            this.moreButton.Click += new System.EventHandler(this.MoreButton_Click);
            // 
            // VerticalToolboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(50, 229);
            this.ControlBox = false;
            this.Controls.Add(this.moreButton);
            this.Controls.Add(this.sep1Label);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.uploadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "VerticalToolboxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "VerticalToolboxForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VerticalToolboxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label sep1Label;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button moreButton;
    }
}