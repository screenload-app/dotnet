namespace ScreenLoad
{
    partial class ToolboxShapesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolboxShapesForm));
            this.lineRadioButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.mFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineRadioButton
            // 
            this.lineRadioButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.lineRadioButton.FlatAppearance.BorderSize = 0;
            this.lineRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineRadioButton.Image = ((System.Drawing.Image)(resources.GetObject("lineRadioButton.Image")));
            this.lineRadioButton.Location = new System.Drawing.Point(0, 91);
            this.lineRadioButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lineRadioButton.Name = "lineRadioButton";
            this.lineRadioButton.Size = new System.Drawing.Size(38, 38);
            this.lineRadioButton.TabIndex = 1;
            this.lineRadioButton.UseVisualStyleBackColor = false;
            this.lineRadioButton.Click += new System.EventHandler(this.lineRadioButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.rectangleButton.FlatAppearance.BorderSize = 0;
            this.rectangleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
            this.rectangleButton.Location = new System.Drawing.Point(0, 3);
            this.rectangleButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(38, 38);
            this.rectangleButton.TabIndex = 0;
            this.rectangleButton.UseVisualStyleBackColor = false;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ellipseButton.FlatAppearance.BorderSize = 0;
            this.ellipseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ellipseButton.Image = ((System.Drawing.Image)(resources.GetObject("ellipseButton.Image")));
            this.ellipseButton.Location = new System.Drawing.Point(0, 44);
            this.ellipseButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(38, 38);
            this.ellipseButton.TabIndex = 1;
            this.ellipseButton.UseVisualStyleBackColor = false;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // mFlowLayoutPanel
            // 
            this.mFlowLayoutPanel.AutoSize = true;
            this.mFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mFlowLayoutPanel.Controls.Add(this.rectangleButton);
            this.mFlowLayoutPanel.Controls.Add(this.ellipseButton);
            this.mFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mFlowLayoutPanel.Name = "mFlowLayoutPanel";
            this.mFlowLayoutPanel.Size = new System.Drawing.Size(38, 82);
            this.mFlowLayoutPanel.TabIndex = 0;
            this.mFlowLayoutPanel.WrapContents = false;
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // ToolboxShapesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(38, 82);
            this.ControlBox = false;
            this.Controls.Add(this.mFlowLayoutPanel);
            this.Controls.Add(this.lineRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "ToolboxShapesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.ToolboxShapesForm_Deactivate);
            this.Load += new System.EventHandler(this.ToolboxShapesForm_Load);
            this.mFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lineRadioButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}