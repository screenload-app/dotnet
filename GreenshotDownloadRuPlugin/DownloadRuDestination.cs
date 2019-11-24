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

using System.ComponentModel;
using System.Drawing;
using Greenshot.Plugin;
using GreenshotPlugin.Core;

namespace GreenshotDownloadRuPlugin
{
    public class DownloadRuDestination : AbstractDestination
    {
        private readonly DownloadRuPlugin _plugin;

        public DownloadRuDestination(DownloadRuPlugin plugin)
        {
            _plugin = plugin;
        }

        public override string Designation => "DownloadRu";

        public override string Description => Language.GetString(Constants.LanguagePrefix, LangKey.upload_menu_item);

        public override Image DisplayIcon
        {
            get
            {
                var resources = new ComponentResourceManager(typeof(DownloadRuPlugin));
                return (Image) resources.GetObject("DownloadRu16x16");
            }
        }

        public override ExportInformation ExportCapture(bool manuallyInitiated, ISurface surface,
            ICaptureDetails captureDetails)
        {
            string successMessage = Language.GetString(Constants.LanguagePrefix, LangKey.upload_success);

            if (_plugin.Configuration.AfterUploadLinkToClipBoard)
            {
                switch (_plugin.Configuration.AfterUploadLinkToClipBoardMode)
                {
                    case LinkType.Image:
                        successMessage = Language.GetString(Constants.LanguagePrefix, LangKey.upload_success_and_copy_imagelink);
                        break;
                    case LinkType.Page:
                        successMessage = Language.GetString(Constants.LanguagePrefix, LangKey.upload_success_and_copy_pagelink);
                        break;
                }
            }

            var exportInformation = new ExportInformation(Designation, Description)
            {
                SuccessMessage = successMessage
            };

            string uploadUrl = _plugin.Upload(captureDetails, surface);

            if (uploadUrl != null)
            {
                exportInformation.ExportMade = true;
                exportInformation.Uri = uploadUrl;
            }

            ProcessExport(exportInformation, surface);
            return exportInformation;
        }
    }
}