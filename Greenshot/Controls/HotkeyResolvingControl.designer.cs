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
            this.mTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.actionLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.hotkeyLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.messageLabel = new GreenshotPlugin.Controls.GreenshotLabel();
            this.rightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.otherCombinationRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.retryRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.ignoreRadioButton = new GreenshotPlugin.Controls.GreenshotRadioButton();
            this.otherCombinationHotkeyControl = new GreenshotPlugin.Controls.HotkeyControl();
            this.mTimer = new System.Windows.Forms.Timer(this.components);
            this.mErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mTableLayoutPanel.SuspendLayout();
            this.leftFlowLayoutPanel.SuspendLayout();
            this.rightTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // mTableLayoutPanel
            // 
            this.mTableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.mTableLayoutPanel.ColumnCount = 2;
            this.mTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mTableLayoutPanel.Controls.Add(this.leftFlowLayoutPanel, 0, 0);
            this.mTableLayoutPanel.Controls.Add(this.rightTableLayoutPanel, 1, 0);
            this.mTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTableLayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.mTableLayoutPanel.Name = "mTableLayoutPanel";
            this.mTableLayoutPanel.RowCount = 1;
            this.mTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel.Size = new System.Drawing.Size(593, 80);
            this.mTableLayoutPanel.TabIndex = 0;
            // 
            // leftFlowLayoutPanel
            // 
            this.leftFlowLayoutPanel.Controls.Add(this.actionLabel);
            this.leftFlowLayoutPanel.Controls.Add(this.hotkeyLabel);
            this.leftFlowLayoutPanel.Controls.Add(this.messageLabel);
            this.leftFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.leftFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.leftFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftFlowLayoutPanel.Name = "leftFlowLayoutPanel";
            this.leftFlowLayoutPanel.Size = new System.Drawing.Size(338, 80);
            this.leftFlowLayoutPanel.TabIndex = 0;
            this.leftFlowLayoutPanel.WrapContents = false;
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.actionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.actionLabel.Location = new System.Drawing.Point(3, 0);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(167, 24);
            this.actionLabel.TabIndex = 0;
            this.actionLabel.Text = "Capture full screen";
            // 
            // hotkeyLabel
            // 
            this.hotkeyLabel.AutoSize = true;
            this.hotkeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hotkeyLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.hotkeyLabel.Location = new System.Drawing.Point(0, 24);
            this.hotkeyLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.hotkeyLabel.Name = "hotkeyLabel";
            this.hotkeyLabel.Size = new System.Drawing.Size(186, 26);
            this.hotkeyLabel.TabIndex = 1;
            this.hotkeyLabel.Text = "[Ctrl] + [Prnt Scrn]";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.BackColor = System.Drawing.Color.White;
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.LanguageKey = "hotkey_resolving_message";
            this.messageLabel.Location = new System.Drawing.Point(3, 50);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(310, 26);
            this.messageLabel.TabIndex = 2;
            this.messageLabel.Text = "The combination cannot be used because it is already in use by another program!";
            // 
            // rightTableLayoutPanel
            // 
            this.rightTableLayoutPanel.AutoSize = true;
            this.rightTableLayoutPanel.ColumnCount = 2;
            this.rightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightTableLayoutPanel.Controls.Add(this.otherCombinationRadioButton, 0, 1);
            this.rightTableLayoutPanel.Controls.Add(this.retryRadioButton, 0, 0);
            this.rightTableLayoutPanel.Controls.Add(this.ignoreRadioButton, 1, 1);
            this.rightTableLayoutPanel.Controls.Add(this.otherCombinationHotkeyControl, 1, 1);
            this.rightTableLayoutPanel.Location = new System.Drawing.Point(338, 0);
            this.rightTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightTableLayoutPanel.Name = "rightTableLayoutPanel";
            this.rightTableLayoutPanel.RowCount = 3;
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightTableLayoutPanel.Size = new System.Drawing.Size(255, 72);
            this.rightTableLayoutPanel.TabIndex = 1;
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
            // retryRadioButton
            // 
            this.retryRadioButton.AutoSize = true;
            this.retryRadioButton.Checked = true;
            this.rightTableLayoutPanel.SetColumnSpan(this.retryRadioButton, 2);
            this.retryRadioButton.Location = new System.Drawing.Point(3, 3);
            this.retryRadioButton.Name = "retryRadioButton";
            this.retryRadioButton.Size = new System.Drawing.Size(115, 17);
            this.retryRadioButton.TabIndex = 0;
            this.retryRadioButton.TabStop = true;
            this.retryRadioButton.Text = "Try again to set {0}";
            this.retryRadioButton.UseVisualStyleBackColor = true;
            this.retryRadioButton.CheckedChanged += new System.EventHandler(this.retryRadioButton_CheckedChanged);
            // 
            // ignoreRadioButton
            // 
            this.ignoreRadioButton.AutoSize = true;
            this.rightTableLayoutPanel.SetColumnSpan(this.ignoreRadioButton, 2);
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
            this.otherCombinationHotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.otherCombinationHotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.mErrorProvider.SetIconPadding(this.otherCombinationHotkeyControl, -18);
            this.otherCombinationHotkeyControl.Location = new System.Drawing.Point(152, 26);
            this.otherCombinationHotkeyControl.Name = "otherCombinationHotkeyControl";
            this.otherCombinationHotkeyControl.Size = new System.Drawing.Size(100, 20);
            this.otherCombinationHotkeyControl.TabIndex = 4;
            this.otherCombinationHotkeyControl.TextChanged += new System.EventHandler(this.otherCombinationHotkeyControl_TextChanged);
            this.otherCombinationHotkeyControl.Enter += new System.EventHandler(this.otherCombinationHotkeyControl_Enter);
            // 
            // mTimer
            // 
            this.mTimer.Enabled = true;
            this.mTimer.Interval = 300;
            this.mTimer.Tick += new System.EventHandler(this.mTimer_Tick);
            // 
            // mErrorProvider
            // 
            this.mErrorProvider.ContainerControl = this;
            // 
            // HotkeyResolvingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.mTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Name = "HotkeyResolvingControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(595, 82);
            this.mTableLayoutPanel.ResumeLayout(false);
            this.mTableLayoutPanel.PerformLayout();
            this.leftFlowLayoutPanel.ResumeLayout(false);
            this.leftFlowLayoutPanel.PerformLayout();
            this.rightTableLayoutPanel.ResumeLayout(false);
            this.rightTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel leftFlowLayoutPanel;
        private GreenshotPlugin.Controls.GreenshotLabel actionLabel;
        private GreenshotPlugin.Controls.GreenshotLabel hotkeyLabel;
        private GreenshotPlugin.Controls.GreenshotLabel messageLabel;
        private GreenshotPlugin.Controls.GreenshotRadioButton retryRadioButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton otherCombinationRadioButton;
        private GreenshotPlugin.Controls.GreenshotRadioButton ignoreRadioButton;
        private System.Windows.Forms.TableLayoutPanel rightTableLayoutPanel;
        private GreenshotPlugin.Controls.HotkeyControl otherCombinationHotkeyControl;
        private System.Windows.Forms.ErrorProvider mErrorProvider;
        private System.Windows.Forms.Timer mTimer;
    }
}
