/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2014 Thomas Braun, Jens Klingen, Robin Krom, Francis Noel
 * 
 * For more information see: http://getgreenshot.org/
 * The ScreenLoad project is hosted on Sourceforge: http://sourceforge.net/projects/ScreenLoad/
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
using System.Windows.Forms;
using ScreenLoad.IniFile;
using ScreenLoadDownloadRuPlugin.Forms;
using ScreenLoadPlugin.Core;

namespace ScreenLoadDownloadRuPlugin
{
    /// <summary>
    /// Description of DownloadRuConfiguration.
    /// </summary>
    [IniSection("DownloadRu", Description = "ScreenLoad Download.Ru Plugin configuration")]
    public class DownloadRuConfiguration : IniSection
    {
        [IniProperty("UploadFormat", Description = "What file type to use for uploading", DefaultValue = "png")]
        public OutputFormat UploadFormat;

        [IniProperty("UploadJpegQuality", Description = "JPEG file save quality in %.", DefaultValue = "80")]
        public int UploadJpegQuality;

        [IniProperty("AfterUploadLinkToClipBoard", Description = "After upload send Download.Ru link to clipboard.",
            DefaultValue = "true")]
        public bool AfterUploadLinkToClipBoard;

        [IniProperty("AfterUploadOpenInBrowser", Description = "After upload open Download.Ru link in browser.",
            DefaultValue = "true")]
        public bool AfterUploadOpenInBrowser;

        [IniProperty("AfterUploadShowDetails", Description = "After open a window with the detailed information.",
            DefaultValue = "true")]
        public bool AfterUploadShowDetails;

        [IniProperty("AfterUploadShowNotification", DefaultValue = "true")]
        public bool AfterUploadShowNotification;

        [IniProperty("AfterUploadLinkToClipBoardMode", DefaultValue = "Image")]
        public LinkType AfterUploadLinkToClipBoardMode;

        [IniProperty("AfterUploadOpenInBrowserMode", DefaultValue = "Image")]
        public LinkType AfterUploadOpenInBrowserMode;

        [IniProperty("AutomaticallyCloseSuccessForm", Description = "Automatically close success form.",
            DefaultValue = "true")]
        public bool AutomaticallyCloseSuccessForm;

        //[IniProperty("UseSharedLink", Description = "Use the shared link, instead of the private, on the clipboard", DefaultValue = "True")]
        //public bool UseSharedLink;

        [IniProperty("DownloadRuToken", Description = "Token.", DefaultValue = "")]
        public string DownloadRuToken;

        [IniProperty("AnonymousAccess", Description = "Use anonymous access to Download.Ru", DefaultValue = "false")]
        public bool AnonymousAccess;

        [IniProperty("SharedLink", Description = "Share the image after it is loaded", DefaultValue = "true")]
        public bool SharedLink;

        /// <summary>
        /// A form for token
        /// </summary>
        /// <returns>bool true if OK was pressed, false if cancel</returns>
        public bool ShowConfigDialog()
        {
            var result = new SettingsForm(this).ShowDialog();
            return result == DialogResult.OK;
        }
    }
}