namespace ScreenLoad
{
    partial class QuickImageEditorForm
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
            this.sizeLabel = new ScreenLoad.Controls.TransparentLabel();
            this.holePanel = new ScreenLoad.Controls.DoubleBufferedPanel();
            this.innerPanel = new ScreenLoad.Controls.DoubleBufferedPanel();
            this.holePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sizeLabel
            // 
            this.sizeLabel.BackColor = System.Drawing.Color.Black;
            this.sizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeLabel.ForeColor = System.Drawing.Color.White;
            this.sizeLabel.Location = new System.Drawing.Point(39, 37);
            this.sizeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(150, 41);
            this.sizeLabel.TabIndex = 0;
            this.sizeLabel.Text = "250x200";
            this.sizeLabel.Visible = false;
            // 
            // holePanel
            // 
            this.holePanel.BackColor = System.Drawing.Color.Transparent;
            this.holePanel.Controls.Add(this.innerPanel);
            this.holePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.holePanel.Location = new System.Drawing.Point(39, 85);
            this.holePanel.Name = "holePanel";
            this.holePanel.Padding = new System.Windows.Forms.Padding(8);
            this.holePanel.Size = new System.Drawing.Size(400, 200);
            this.holePanel.TabIndex = 1;
            this.holePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HolePanel_Paint);
            this.holePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseDown);
            this.holePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseMove);
            this.holePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseUp);
            // 
            // innerPanel
            // 
            this.innerPanel.BackColor = System.Drawing.Color.Fuchsia;
            this.innerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerPanel.Location = new System.Drawing.Point(8, 8);
            this.innerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Size = new System.Drawing.Size(384, 184);
            this.innerPanel.TabIndex = 0;
            this.innerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InnerPanel_Paint);
            this.innerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseDown);
            this.innerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseMove);
            this.innerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseUp);
            // 
            // QuickImageEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(477, 325);
            this.ControlBox = false;
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.holePanel);
            this.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickImageEditorForm";
            this.Opacity = 0.4D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.QuickImageEditorForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QuickImageEditorCoverForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.QuickImageEditorCoverForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.QuickImageEditorCoverForm_MouseUp);
            this.holePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ScreenLoad.Controls.DoubleBufferedPanel holePanel;
        private ScreenLoad.Controls.TransparentLabel sizeLabel;
        private ScreenLoad.Controls.DoubleBufferedPanel innerPanel;
    }
}