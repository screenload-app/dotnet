namespace Greenshot.Controls
{
    partial class HotkeyResolvingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mGroupBox = new System.Windows.Forms.GroupBox();
            this.otherCombinationRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.defaultRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.ignoreRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.otherCombinationHotkeyControl = new GreenshotPlugin.Controls.HotkeyControl();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).BeginInit();
            this.mTableLayoutPanel.SuspendLayout();
            this.mGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mErrorProvider
            // 
            this.mErrorProvider.ContainerControl = this;
            // 
            // mTableLayoutPanel
            // 
            this.mTableLayoutPanel.ColumnCount = 2;
            this.mTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel.Controls.Add(this.otherCombinationRadioButton, 0, 1);
            this.mTableLayoutPanel.Controls.Add(this.defaultRadioButton, 0, 0);
            this.mTableLayoutPanel.Controls.Add(this.ignoreRadioButton, 1, 1);
            this.mTableLayoutPanel.Controls.Add(this.otherCombinationHotkeyControl, 1, 1);
            this.mTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.mTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mTableLayoutPanel.Name = "mTableLayoutPanel";
            this.mTableLayoutPanel.RowCount = 3;
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel.Size = new System.Drawing.Size(254, 73);
            this.mTableLayoutPanel.TabIndex = 0;
            // 
            // mGroupBox
            // 
            this.mGroupBox.Controls.Add(this.mTableLayoutPanel);
            this.mGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mGroupBox.Name = "mGroupBox";
            this.mGroupBox.Size = new System.Drawing.Size(260, 96);
            this.mGroupBox.TabIndex = 0;
            this.mGroupBox.TabStop = false;
            this.mGroupBox.Text = "Capture full screen";
            // 
            // otherCombinationRadioButton
            // 
            this.otherCombinationRadioButton.AutoSize = true;
            this.otherCombinationRadioButton.LanguageKey = "hotkey_resolving_other_combination";
            this.otherCombinationRadioButton.Location = new System.Drawing.Point(3, 26);
            this.otherCombinationRadioButton.Name = "otherCombinationRadioButton";
            this.otherCombinationRadioButton.Size = new System.Drawing.Size(143, 17);
            this.otherCombinationRadioButton.TabIndex = 1;
            this.otherCombinationRadioButton.Text = "Set another combination:";
            this.otherCombinationRadioButton.UseVisualStyleBackColor = true;
            this.otherCombinationRadioButton.CheckedChanged += new System.EventHandler(this.otherCombinationRadioButton_CheckedChanged);
            // 
            // defaultRadioButton
            // 
            this.defaultRadioButton.AutoSize = true;
            this.mTableLayoutPanel.SetColumnSpan(this.defaultRadioButton, 2);
            this.defaultRadioButton.Location = new System.Drawing.Point(3, 3);
            this.defaultRadioButton.Name = "defaultRadioButton";
            this.defaultRadioButton.Size = new System.Drawing.Size(82, 17);
            this.defaultRadioButton.TabIndex = 0;
            this.defaultRadioButton.Text = "Default [{0}]";
            this.defaultRadioButton.UseVisualStyleBackColor = true;
            this.defaultRadioButton.CheckedChanged += new System.EventHandler(this.defaultRadioButton_CheckedChanged);
            // 
            // ignoreRadioButton
            // 
            this.ignoreRadioButton.AutoSize = true;
            this.mTableLayoutPanel.SetColumnSpan(this.ignoreRadioButton, 2);
            this.ignoreRadioButton.LanguageKey = "hotkey_resolving_ignore";
            this.ignoreRadioButton.Location = new System.Drawing.Point(3, 52);
            this.ignoreRadioButton.Name = "ignoreRadioButton";
            this.ignoreRadioButton.Size = new System.Drawing.Size(95, 17);
            this.ignoreRadioButton.TabIndex = 3;
            this.ignoreRadioButton.Text = "Disable hotkey";
            this.ignoreRadioButton.UseVisualStyleBackColor = true;
            this.ignoreRadioButton.CheckedChanged += new System.EventHandler(this.ignoreRadioButton_CheckedChanged);
            // 
            // otherCombinationHotkeyControl
            // 
            this.otherCombinationHotkeyControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.otherCombinationHotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.otherCombinationHotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.mErrorProvider.SetIconPadding(this.otherCombinationHotkeyControl, -18);
            this.otherCombinationHotkeyControl.Location = new System.Drawing.Point(152, 26);
            this.otherCombinationHotkeyControl.Name = "otherCombinationHotkeyControl";
            this.otherCombinationHotkeyControl.Size = new System.Drawing.Size(99, 20);
            this.otherCombinationHotkeyControl.TabIndex = 2;
            this.otherCombinationHotkeyControl.TextChanged += new System.EventHandler(this.otherCombinationHotkeyControl_TextChanged);
            this.otherCombinationHotkeyControl.Enter += new System.EventHandler(this.otherCombinationHotkeyControl_Enter);
            // 
            // HotkeyResolvingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.mGroupBox);
            this.Name = "HotkeyResolvingControl";
            this.Size = new System.Drawing.Size(260, 96);
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).EndInit();
            this.mTableLayoutPanel.ResumeLayout(false);
            this.mTableLayoutPanel.PerformLayout();
            this.mGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GreenshotPlugin.Controls.GreenshotRadioButton defaultRadioButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton otherCombinationRadioButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton ignoreRadioButton;
        private GreenshotPlugin.Controls.HotkeyControl otherCombinationHotkeyControl;
        private System.Windows.Forms.ErrorProvider mErrorProvider;
        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel;
        private System.Windows.Forms.GroupBox mGroupBox;
    }
}
