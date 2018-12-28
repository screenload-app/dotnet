namespace Greenshot.Forms
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
            this.infoLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.captionLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.mFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new GreenshotPlugin.Controls.GreenshotButton();
            this.okButton = new GreenshotPlugin.Controls.GreenshotButton();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.ForeColor = System.Drawing.Color.Black;
            this.infoLabel.LanguageKey = "hotkeys_resolving_info";
            this.infoLabel.Location = new System.Drawing.Point(14, 38);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(609, 70);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = resources.GetString("infoLabel.Text");
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.captionLabel.LanguageKey = "hotkeys_resolving_caption";
            this.captionLabel.Location = new System.Drawing.Point(12, 9);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(239, 29);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "Failed to set hotkeys!";
            // 
            // mFlowLayoutPanel
            // 
            this.mFlowLayoutPanel.AutoScroll = true;
            this.mFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mFlowLayoutPanel.Location = new System.Drawing.Point(17, 108);
            this.mFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mFlowLayoutPanel.Name = "mFlowLayoutPanel";
            this.mFlowLayoutPanel.Size = new System.Drawing.Size(606, 432);
            this.mFlowLayoutPanel.TabIndex = 2;
            this.mFlowLayoutPanel.WrapContents = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.LanguageKey = "hotkeys_resolving_cancel";
            this.cancelButton.Location = new System.Drawing.Point(464, 557);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(159, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Disable these hotkeys";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.LanguageKey = "hotkeys_resolving_ok";
            this.okButton.Location = new System.Drawing.Point(383, 557);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // HotkeysResolvingForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(640, 595);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.mFlowLayoutPanel);
            this.Controls.Add(this.captionLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "hotkeys_resolving_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeysResolvingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Failed to set hotkeys!";
            this.Load += new System.EventHandler(this.HotkeyErrorsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GreenshotPlugin.Controls.GreenshotLabel infoLabel;
        private GreenshotPlugin.Controls.GreenshotLabel captionLabel;
        private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel;
        private GreenshotPlugin.Controls.GreenshotButton cancelButton;
        private GreenshotPlugin.Controls.GreenshotButton okButton;
    }
}