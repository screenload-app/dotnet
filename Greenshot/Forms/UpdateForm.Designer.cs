namespace Greenshot
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.mTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.captionLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.mProgressBar = new Greenshot.Controls.ProgressBarWithText();
            this.bottomFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new GreenshotPlugin.Controls.GreenshotButton();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.mTableLayoutPanel.SuspendLayout();
            this.bottomFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTableLayoutPanel
            // 
            this.mTableLayoutPanel.ColumnCount = 1;
            this.mTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel.Controls.Add(this.captionLabel, 0, 0);
            this.mTableLayoutPanel.Controls.Add(this.mProgressBar, 0, 1);
            this.mTableLayoutPanel.Controls.Add(this.bottomFlowLayoutPanel, 0, 3);
            this.mTableLayoutPanel.Controls.Add(this.infoTextBox, 0, 2);
            this.mTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mTableLayoutPanel.Name = "mTableLayoutPanel";
            this.mTableLayoutPanel.RowCount = 4;
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.Size = new System.Drawing.Size(485, 229);
            this.mTableLayoutPanel.TabIndex = 0;
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captionLabel.LanguageKey = "";
            this.captionLabel.Location = new System.Drawing.Point(12, 12);
            this.captionLabel.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(226, 13);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "Downloading Greenshot, please wait...";
            // 
            // mProgressBar
            // 
            this.mProgressBar.CustomText = null;
            this.mProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mProgressBar.Location = new System.Drawing.Point(12, 37);
            this.mProgressBar.Margin = new System.Windows.Forms.Padding(12);
            this.mProgressBar.Name = "mProgressBar";
            this.mProgressBar.Size = new System.Drawing.Size(461, 23);
            this.mProgressBar.TabIndex = 1;
            // 
            // bottomFlowLayoutPanel
            // 
            this.bottomFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomFlowLayoutPanel.AutoSize = true;
            this.bottomFlowLayoutPanel.Controls.Add(this.cancelButton);
            this.bottomFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.bottomFlowLayoutPanel.Location = new System.Drawing.Point(386, 182);
            this.bottomFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomFlowLayoutPanel.Name = "bottomFlowLayoutPanel";
            this.bottomFlowLayoutPanel.Size = new System.Drawing.Size(99, 47);
            this.bottomFlowLayoutPanel.TabIndex = 3;
            this.bottomFlowLayoutPanel.WrapContents = false;
            // 
            // cancelButton
            // 
            this.cancelButton.LanguageKey = "updateform_cancel";
            this.cancelButton.Location = new System.Drawing.Point(12, 12);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTextBox.Location = new System.Drawing.Point(12, 72);
            this.infoTextBox.Margin = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoTextBox.Size = new System.Drawing.Size(461, 98);
            this.infoTextBox.TabIndex = 4;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 229);
            this.Controls.Add(this.mTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "updateform";
            this.MaximizeBox = false;
            this.Name = "UpdateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateForm_FormClosing);
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.mTableLayoutPanel.ResumeLayout(false);
            this.mTableLayoutPanel.PerformLayout();
            this.bottomFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel;
        private GreenshotPlugin.Controls.GreenshotLabel captionLabel;
        private Greenshot.Controls.ProgressBarWithText mProgressBar;
        private System.Windows.Forms.FlowLayoutPanel bottomFlowLayoutPanel;
        private GreenshotPlugin.Controls.GreenshotButton cancelButton;
        private System.Windows.Forms.TextBox infoTextBox;
    }
}