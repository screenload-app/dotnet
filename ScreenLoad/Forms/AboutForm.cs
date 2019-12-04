/*
* ScreenLoad - a free and open source screenshot tool
* Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
*
* For more information see: http://getgreenshot.org/
* The ScreenLoad project is hosted on GitHub https://github.com/greenshot/greenshot
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 1 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

using ScreenLoad.Helpers;
using ScreenLoad.Configuration;
using ScreenLoadPlugin.Core;
using ScreenLoad.IniFile;
using System.Security.Permissions;
using log4net;
using System.Globalization;
using ScreenLoad.Help;

namespace ScreenLoad {
	/// <summary>
	/// The about form
	/// </summary>
	public partial class AboutForm : AnimatingBaseForm {
		private static readonly ILog LOG = LogManager.GetLogger(typeof(AboutForm));

		/// <summary>
		/// Constructor
		/// </summary>
		public AboutForm() {
			// Enable animation for this form, when we don't set this the timer doesn't start as soon as the form is loaded.
			EnableAnimation = true;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			// Only use double-buffering when we are NOT in a Terminal Server session
			DoubleBuffered = !IsTerminalServerSession;

			Version v = Assembly.GetExecutingAssembly().GetName().Version;

			// Format is like this:  AssemblyVersion("Major.Minor.Build.Revision")]
			lblTitle.Text = "ScreenLoad " + v.Major + "." + v.Minor + "." + v.Build + " Build " + v.Revision + (IniConfig.IsPortable ? " Portable" : "") + (" (" + OsInfo.Bits) + " bit)";
            linkLblBugs.Text = string.Format(CultureInfo.InvariantCulture, linkLblBugs.Text, Assembly.GetEntryAssembly().GetName().Version);
            linkLblDonations.Text = string.Format(CultureInfo.InvariantCulture, linkLblDonations.Text, Assembly.GetEntryAssembly().GetName().Version);
        }

		/// <summary>
		/// This is called when a link is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			LinkLabel linkLabel = sender as LinkLabel;
			if (linkLabel != null) {
				try {
					linkLabel.LinkVisited = true;
					Process.Start(linkLabel.Text);
				} catch (Exception) {
					MessageBox.Show(Language.GetFormattedString(LangKey.error_openlink, linkLabel.Text), Language.GetString(LangKey.error));
				}
			}
		}

		/// <summary>
		/// CmdKey handler
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			try {
				switch (keyData) {
					case Keys.Escape:
						DialogResult = DialogResult.Cancel;
						break;
					case Keys.E:
						MessageBox.Show(EnvironmentInfo.EnvironmentToString(true));
						break;
					case Keys.L:
						try {
							if (File.Exists(MainForm.LogFileLocation)) {
								using (Process.Start("\"" + MainForm.LogFileLocation + "\"")) {
									// nothing to do, just using dispose to cleanup
								}
							} else {
								MessageBox.Show("ScreenLoad can't find the logfile, it should have been here: " + MainForm.LogFileLocation);
							}
						} catch (Exception) {
							MessageBox.Show("Couldn't open the ScreenLoad.log, it's located here: " + MainForm.LogFileLocation, "Error opening greeenshot.log", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						break;
					case Keys.I:
						try {
							using (Process.Start("\"" + IniConfig.ConfigLocation + "\"")) {
							}
						} catch (Exception) {
							MessageBox.Show("Couldn't open the ScreenLoad.ini, it's located here: " + IniConfig.ConfigLocation, "Error opening greeenshot.ini", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						break;
					default:
						return base.ProcessCmdKey(ref msg, keyData);
				}
			} catch (Exception ex) {
				LOG.Error(string.Format("Error handling key '{0}'", keyData), ex);
			}
			return true;
		}

        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpFileLoader.LoadHelp();
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://getgreenshot.org/support/?version=" +
                          Assembly.GetEntryAssembly().GetName().Version);
        }

        private void updatesButton_Click(object sender, EventArgs e)
        {
            updateButton.Text = Language.GetString("checkingforupdates");
            updateButton.Enabled = false;

            UpdateHelper.CheckAndAskForUpdateInThread(UpdateRaised.Manually, coreConfiguration, 0, result =>
            {
                this.InvokeAction(() =>
                {
                    if (IsDisposed)
                        return;

                    updateButton.Text = Language.GetString("About_UpdateButton");
                    updateButton.Enabled = true;

                    if (UpdateCheckingResult.NotFound == result)
                    {
                        MainForm.Instance.NotifyIcon.ShowBalloonTip(10000, "ScreenLoad",
                            Language.GetString("noupdatesfound"), ToolTipIcon.Info);
                    }
                });
            });
        }
    }
}