namespace GreenshotDownloadRuPlugin.Forms
{
    partial class SuccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuccessForm));
            this.captionLabel = new System.Windows.Forms.Label();
            this.mPictureBox = new System.Windows.Forms.PictureBox();
            this.directLinkLabel = new System.Windows.Forms.Label();
            this.pageLinkLabel = new System.Windows.Forms.Label();
            this.directLinkTextBox = new System.Windows.Forms.TextBox();
            this.directLinkButton = new System.Windows.Forms.Button();
            this.pageLinkButton = new System.Windows.Forms.Button();
            this.pageLinkTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.doNotShowCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // captionLabel
            // 
            this.captionLabel.Location = new System.Drawing.Point(82, 39);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(456, 28);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "Изображение было успешно сохранено на Download.Ru! Вы можете получить к нему дост" +
    "уп по этим ссылкам:";
            // 
            // mPictureBox
            // 
            this.mPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mPictureBox.Image")));
            this.mPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mPictureBox.Name = "mPictureBox";
            this.mPictureBox.Size = new System.Drawing.Size(64, 64);
            this.mPictureBox.TabIndex = 1;
            this.mPictureBox.TabStop = false;
            // 
            // directLinkLabel
            // 
            this.directLinkLabel.AutoSize = true;
            this.directLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directLinkLabel.Location = new System.Drawing.Point(9, 105);
            this.directLinkLabel.Name = "directLinkLabel";
            this.directLinkLabel.Size = new System.Drawing.Size(105, 13);
            this.directLinkLabel.TabIndex = 2;
            this.directLinkLabel.Text = "Прямая ссылка:";
            // 
            // pageLinkLabel
            // 
            this.pageLinkLabel.AutoSize = true;
            this.pageLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageLinkLabel.Location = new System.Drawing.Point(9, 143);
            this.pageLinkLabel.Name = "pageLinkLabel";
            this.pageLinkLabel.Size = new System.Drawing.Size(132, 13);
            this.pageLinkLabel.TabIndex = 3;
            this.pageLinkLabel.Text = "Ссылка на страницу:";
            // 
            // directLinkTextBox
            // 
            this.directLinkTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.directLinkTextBox.Location = new System.Drawing.Point(164, 102);
            this.directLinkTextBox.Name = "directLinkTextBox";
            this.directLinkTextBox.ReadOnly = true;
            this.directLinkTextBox.Size = new System.Drawing.Size(293, 20);
            this.directLinkTextBox.TabIndex = 4;
            // 
            // directLinkButton
            // 
            this.directLinkButton.Location = new System.Drawing.Point(463, 100);
            this.directLinkButton.Name = "directLinkButton";
            this.directLinkButton.Size = new System.Drawing.Size(75, 23);
            this.directLinkButton.TabIndex = 5;
            this.directLinkButton.Text = "Копировать";
            this.directLinkButton.UseVisualStyleBackColor = true;
            this.directLinkButton.Click += new System.EventHandler(this.DirectLinkButton_Click);
            // 
            // pageLinkButton
            // 
            this.pageLinkButton.Location = new System.Drawing.Point(463, 138);
            this.pageLinkButton.Name = "pageLinkButton";
            this.pageLinkButton.Size = new System.Drawing.Size(75, 23);
            this.pageLinkButton.TabIndex = 7;
            this.pageLinkButton.Text = "Копировать";
            this.pageLinkButton.UseVisualStyleBackColor = true;
            this.pageLinkButton.Click += new System.EventHandler(this.PageLinkButton_Click);
            // 
            // pageLinkTextBox
            // 
            this.pageLinkTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.pageLinkTextBox.Location = new System.Drawing.Point(164, 140);
            this.pageLinkTextBox.Name = "pageLinkTextBox";
            this.pageLinkTextBox.ReadOnly = true;
            this.pageLinkTextBox.Size = new System.Drawing.Size(293, 20);
            this.pageLinkTextBox.TabIndex = 6;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(463, 224);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // doNotShowCheckBox
            // 
            this.doNotShowCheckBox.AutoSize = true;
            this.doNotShowCheckBox.Location = new System.Drawing.Point(12, 191);
            this.doNotShowCheckBox.Name = "doNotShowCheckBox";
            this.doNotShowCheckBox.Size = new System.Drawing.Size(153, 17);
            this.doNotShowCheckBox.TabIndex = 9;
            this.doNotShowCheckBox.Text = "Не отображать это окно.";
            this.doNotShowCheckBox.UseVisualStyleBackColor = true;
            // 
            // SuccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 259);
            this.Controls.Add(this.doNotShowCheckBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.pageLinkButton);
            this.Controls.Add(this.pageLinkTextBox);
            this.Controls.Add(this.directLinkButton);
            this.Controls.Add(this.directLinkTextBox);
            this.Controls.Add(this.pageLinkLabel);
            this.Controls.Add(this.directLinkLabel);
            this.Controls.Add(this.mPictureBox);
            this.Controls.Add(this.captionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuccessForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Greenshot";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.PictureBox mPictureBox;
        private System.Windows.Forms.Label directLinkLabel;
        private System.Windows.Forms.Label pageLinkLabel;
        private System.Windows.Forms.TextBox directLinkTextBox;
        private System.Windows.Forms.Button directLinkButton;
        private System.Windows.Forms.Button pageLinkButton;
        private System.Windows.Forms.TextBox pageLinkTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox doNotShowCheckBox;
    }
}