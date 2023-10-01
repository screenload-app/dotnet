/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2014 Thomas Braun, Jens Klingen, Robin Krom, Francis Noel
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on Sourceforge: http://sourceforge.net/projects/greenshot/
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Greenshot.IniFile;
using Greenshot.Plugin;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;

namespace GreenshotDownloadRuPlugin {
	/// <summary>
	/// This is the Box base code
	/// </summary>
	public class DownloadRuPlugin : IGreenshotPlugin {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(typeof(DownloadRuPlugin));
		private static DownloadRuConfiguration config;
		public static PluginAttribute Attributes;
		private IGreenshotHost host;
		private ComponentResourceManager resources;
		private ToolStripMenuItem itemPlugInConfig;

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (disposing) {
				if (itemPlugInConfig != null) {
					itemPlugInConfig.Dispose();
					itemPlugInConfig = null;
				}
			}
		}

		public DownloadRuPlugin() {
		}

		public IEnumerable<IDestination> Destinations() {
			yield return new DownloadRuDestination(this);
		}


		public IEnumerable<IProcessor> Processors() {
			yield break;
		}

		/// <summary>
		/// Implementation of the IGreenshotPlugin.Initialize
		/// </summary>
		/// <param name="host">Use the IGreenshotPluginHost interface to register events</param>
		/// <param name="pluginAttribute">My own attributes</param>
		public virtual bool Initialize(IGreenshotHost pluginHost, PluginAttribute myAttributes) {
			this.host = (IGreenshotHost)pluginHost;
			Attributes = myAttributes;

			// Register configuration (don't need the configuration itself)
			config = IniConfig.GetIniSection<DownloadRuConfiguration>();
			resources = new ComponentResourceManager(typeof(DownloadRuPlugin));

			itemPlugInConfig = new ToolStripMenuItem();
            itemPlugInConfig.Image = (Image)resources.GetObject("DownloadRu16x16");
			itemPlugInConfig.Text = Language.GetString("downloadru", LangKey.Configure);
			itemPlugInConfig.Click += new System.EventHandler(ConfigMenuClick);

			PluginUtils.AddToContextMenu(host, itemPlugInConfig);
			Language.LanguageChanged += new LanguageChangedHandler(OnLanguageChanged);
			return true;
		}

		public void OnLanguageChanged(object sender, EventArgs e) {
			if (itemPlugInConfig != null) {
				itemPlugInConfig.Text = Language.GetString("downloadru", LangKey.Configure);
			}
		}

		public virtual void Shutdown() {
            LOG.Debug("DownloadRu Plugin shutdown.");
		}

		/// <summary>
		/// Implementation of the IPlugin.Configure
		/// </summary>
		public virtual void Configure() {
			config.ShowConfigDialog();
		}

		/// <summary>
		/// This will be called when Greenshot is shutting down
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Closing(object sender, FormClosingEventArgs e) {
            LOG.Debug("Application closing, de-registering DownloadRu Plugin!");
			Shutdown();
		}

		public void ConfigMenuClick(object sender, EventArgs eventArgs) {
			config.ShowConfigDialog();
		}

		/// <summary>
		/// This will be called when the menu item in the Editor is clicked
		/// </summary>
		public string Upload(ICaptureDetails captureDetails, ISurface surfaceToUpload) {
			SurfaceOutputSettings outputSettings = new SurfaceOutputSettings(config.UploadFormat, config.UploadJpegQuality, false);
			try {
				string url = null;
				string filename = Path.GetFileName(FilenameHelper.GetFilename(config.UploadFormat, captureDetails));
				SurfaceContainer imageToUpload = new SurfaceContainer(surfaceToUpload, outputSettings, filename);
				
				new PleaseWaitForm().ShowAndWait(DownloadRuPlugin.Attributes.Name, Language.GetString("downloadru", LangKey.communication_wait), 
					delegate() {
						url = DownloadRuUtils.UploadToDownloadRu(imageToUpload, captureDetails.Title, filename);
					}
				);

				if (url != null && config.AfterUploadLinkToClipBoard) {
					ClipboardHelper.SetClipboardData(url);
				}

				return url;
			} catch (Exception ex) {
                LOG.Error("Error uploading.", ex);
				MessageBox.Show(Language.GetString("downloadru", LangKey.upload_failure) + " " + ex.Message);
				return null;
			}
		}
	}
}
