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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Greenshot.IniFile;
using Greenshot.Plugin;
using GreenshotDownloadRuPlugin.Forms;
using GreenshotPlugin.Core;
using log4net;

namespace GreenshotDownloadRuPlugin
{
    /// <summary>
    /// This is the Box base code
    /// </summary>
    public class DownloadRuPlugin : IGreenshotPlugin
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DownloadRuPlugin));

        private static DownloadRuConfiguration _config;
        public static PluginAttribute Attributes;

        private IGreenshotHost _host;
        private ComponentResourceManager _resources;
        private ToolStripMenuItem _itemPlugInConfig;

        internal DownloadRuConfiguration Configuration => _config;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_itemPlugInConfig != null)
                {
                    _itemPlugInConfig.Dispose();
                    _itemPlugInConfig = null;
                }
            }
        }

        public IEnumerable<IDestination> Destinations()
        {
            yield return new DownloadRuDestination(this);
        }


        public IEnumerable<IProcessor> Processors()
        {
            yield break;
        }

        public virtual bool Initialize(IGreenshotHost pluginHost, PluginAttribute myAttributes)
        {
            _host = pluginHost;
            Attributes = myAttributes;

            // Register configuration (don't need the configuration itself)
            _config = IniConfig.GetIniSection<DownloadRuConfiguration>();
            _resources = new ComponentResourceManager(typeof(DownloadRuPlugin));

            _itemPlugInConfig = new ToolStripMenuItem
            {
                Image = (Image) _resources.GetObject("DownloadRu16x16"),
                Text = Language.GetString("downloadru", LangKey.Configure)
            };

            _itemPlugInConfig.Click += ConfigMenuClick;

            PluginUtils.AddToContextMenu(_host, _itemPlugInConfig);
            Language.LanguageChanged += OnLanguageChanged;
            return true;
        }

        public void OnLanguageChanged(object sender, EventArgs e)
        {
            if (_itemPlugInConfig != null)
                _itemPlugInConfig.Text = Language.GetString("downloadru", LangKey.Configure);
        }

        public virtual void Shutdown()
        {
            Log.Debug("DownloadRu Plugin shutdown.");
        }

        /// <summary>
        /// Implementation of the IPlugin.Configure
        /// </summary>
        public virtual void Configure()
        {
            _config.ShowConfigDialog();
        }

        /// <summary>
        /// This will be called when Greenshot is shutting down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Closing(object sender, FormClosingEventArgs e)
        {
            Log.Debug("Application closing, de-registering DownloadRu Plugin!");
            Shutdown();
        }

        public void ConfigMenuClick(object sender, EventArgs eventArgs)
        {
            _config.ShowConfigDialog();
        }

        /// <summary>
        /// This will be called when the menu item in the Editor is clicked
        /// </summary>
        public string Upload(ICaptureDetails captureDetails, ISurface surfaceToUpload)
        {
            var outputSettings =
                new SurfaceOutputSettings(_config.UploadFormat, _config.UploadJpegQuality, false);

            try
            {
                string filename = Path.GetFileName(FilenameHelper.GetFilename(_config.UploadFormat, captureDetails));
                var imageToUpload = new SurfaceContainer(surfaceToUpload, outputSettings, filename);

                FileEntry fileEntry = null;

                ProgressForm.ShowAndProcess(() =>
                {
                    fileEntry = DownloadRuUtils.UploadToDownloadRu(imageToUpload, captureDetails.Title, filename);
                });

                if (null == fileEntry)
                    return null;

                string defaultUrl = LinkHelper.BuildDirectLink(fileEntry);

                if (fileEntry != null && _config.AfterUploadLinkToClipBoard)
                {
                    string clipboardUrl;

                    switch (_config.AfterUploadLinkToClipBoardMode)
                    {
                        case LinkType.Image:
                            clipboardUrl = LinkHelper.BuildDirectLink(fileEntry);
                            break;
                        case LinkType.Page:
                            clipboardUrl = LinkHelper.BuildPageLink(fileEntry);
                            break;
                        default:
                            clipboardUrl = null;
                            break;
                    }

                    if (null != clipboardUrl)
                    {
                        ClipboardHelper.SetClipboardData(clipboardUrl);
                        defaultUrl = clipboardUrl;
                    }
                }

                if (_config.AfterUploadLinkShowDetails)
                {
                    var successForm = new SuccessForm(_config, fileEntry);
                    successForm.Show();
                }

                if (_config.AfterUploadLinkOpenInBrowser)
                {
                    string browserUrl;

                    switch (_config.AfterUploadLinkOpenInBrowserMode)
                    {
                        case LinkType.Image:
                            browserUrl = LinkHelper.BuildDirectLink(fileEntry);
                            break;
                        case LinkType.Page:
                            browserUrl = LinkHelper.BuildPageLink(fileEntry);
                            break;
                        default:
                            browserUrl = null;
                            break;
                    }

                    if (null == browserUrl)
                        return defaultUrl;

                    try
                    {
                        Process.Start(browserUrl);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception);
                    }
                }

                return defaultUrl;
            }
            catch (Exception ex)
            {
                Log.Error("Error uploading.", ex);
                MessageBox.Show(Language.GetString("downloadru", LangKey.upload_failure) + @" " + ex.Message);
                return null;
            }
        }
    }
}