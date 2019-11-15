namespace Greenshot
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
            this.sizeLabel = new Greenshot.Controls.TransparentLabel();
            this.holePanel = new Greenshot.Controls.DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.BackColor = System.Drawing.Color.Black;
            this.sizeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeLabel.ForeColor = System.Drawing.Color.White;
            this.sizeLabel.Location = new System.Drawing.Point(39, 37);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(150, 41);
            this.sizeLabel.TabIndex = 0;
            this.sizeLabel.Text = "250x200";
            this.sizeLabel.Visible = false;
            // 
            // holePanel
            // 
            this.holePanel.BackColor = System.Drawing.Color.Fuchsia;
            this.holePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.holePanel.Location = new System.Drawing.Point(39, 85);
            this.holePanel.Name = "holePanel";
            this.holePanel.Size = new System.Drawing.Size(400, 200);
            this.holePanel.TabIndex = 1;
            this.holePanel.Visible = false;
            this.holePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HolePanel_Paint);
            this.holePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseDown);
            this.holePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseMove);
            this.holePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HolePanel_MouseUp);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickImageEditorForm";
            this.Opacity = 0.3D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuickImageEditorForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QuickImageEditorCoverForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.QuickImageEditorCoverForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.QuickImageEditorCoverForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Greenshot.Controls.DoubleBufferedPanel holePanel;
        private Greenshot.Controls.TransparentLabel sizeLabel;
    }
}