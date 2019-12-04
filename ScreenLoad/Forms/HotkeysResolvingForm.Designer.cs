namespace ScreenLoad
{
    partial class HotkeysResolvingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeysResolvingForm));
            this.captionLabel = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.conflictsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.okButton = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.mFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bottomFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mFlowLayoutPanel.SuspendLayout();
            this.bottomFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captionLabel.LanguageKey = "hotkeys_resolving_caption";
            this.captionLabel.Location = new System.Drawing.Point(3, 3);
            this.captionLabel.Margin = new System.Windows.Forms.Padding(3);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(74, 13);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "Set hotkeys";
            // 
            // conflictsFlowLayoutPanel
            // 
            this.conflictsFlowLayoutPanel.AutoSize = true;
            this.conflictsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.conflictsFlowLayoutPanel.Location = new System.Drawing.Point(3, 22);
            this.conflictsFlowLayoutPanel.MinimumSize = new System.Drawing.Size(266, 102);
            this.conflictsFlowLayoutPanel.Name = "conflictsFlowLayoutPanel";
            this.conflictsFlowLayoutPanel.Size = new System.Drawing.Size(266, 102);
            this.conflictsFlowLayoutPanel.TabIndex = 2;
            this.conflictsFlowLayoutPanel.WrapContents = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.LanguageKey = "hotkeys_resolving_cancel";
            this.cancelButton.Location = new System.Drawing.Point(188, 9);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.LanguageKey = "hotkeys_resolving_ok";
            this.okButton.Location = new System.Drawing.Point(107, 9);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // mFlowLayoutPanel
            // 
            this.mFlowLayoutPanel.AutoSize = true;
            this.mFlowLayoutPanel.Controls.Add(this.captionLabel);
            this.mFlowLayoutPanel.Controls.Add(this.conflictsFlowLayoutPanel);
            this.mFlowLayoutPanel.Controls.Add(this.bottomFlowLayoutPanel);
            this.mFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.mFlowLayoutPanel.MinimumSize = new System.Drawing.Size(272, 0);
            this.mFlowLayoutPanel.Name = "mFlowLayoutPanel";
            this.mFlowLayoutPanel.Size = new System.Drawing.Size(272, 168);
            this.mFlowLayoutPanel.TabIndex = 5;
            this.mFlowLayoutPanel.WrapContents = false;
            // 
            // bottomFlowLayoutPanel
            // 
            this.bottomFlowLayoutPanel.AutoSize = true;
            this.bottomFlowLayoutPanel.Controls.Add(this.cancelButton);
            this.bottomFlowLayoutPanel.Controls.Add(this.okButton);
            this.bottomFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.bottomFlowLayoutPanel.Location = new System.Drawing.Point(3, 130);
            this.bottomFlowLayoutPanel.MinimumSize = new System.Drawing.Size(266, 0);
            this.bottomFlowLayoutPanel.Name = "bottomFlowLayoutPanel";
            this.bottomFlowLayoutPanel.Size = new System.Drawing.Size(266, 35);
            this.bottomFlowLayoutPanel.TabIndex = 6;
            this.bottomFlowLayoutPanel.WrapContents = false;
            // 
            // HotkeysResolvingForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(277, 168);
            this.Controls.Add(this.mFlowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeysResolvingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenLoad";
            this.Load += new System.EventHandler(this.HotkeysResolvingForm_Load);
            this.mFlowLayoutPanel.ResumeLayout(false);
            this.mFlowLayoutPanel.PerformLayout();
            this.bottomFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ScreenLoadPlugin.Controls.ScreenLoadLabel captionLabel;
        private System.Windows.Forms.FlowLayoutPanel conflictsFlowLayoutPanel;
        private ScreenLoadPlugin.Controls.ScreenLoadButton cancelButton;
        private ScreenLoadPlugin.Controls.ScreenLoadButton okButton;
        private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel bottomFlowLayoutPanel;
    }
}