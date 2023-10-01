﻿/*
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
using System.Drawing;
using System.Windows.Forms;

using ScreenLoad.Configuration;
using ScreenLoadPlugin.Core;
using ScreenLoad.Plugin;

namespace ScreenLoad.Destinations {
	/// <summary>
	/// Description of ClipboardDestination.
	/// </summary>
	public class ClipboardDestination : AbstractDestination {
		public const string DESIGNATION = "Clipboard";

		public override string Designation {
			get {
				return DESIGNATION;
			}
		}

		public override string Description {
			get {
				return Language.GetString(LangKey.settings_destination_clipboard);
			}
		}
		public override int Priority {
			get {
				return 2;
			}
		}
		
		public override Keys EditorShortcutKeys => Keys.Control | Keys.Shift | Keys.C;

        public override Icon DisplayIcon => ScreenLoadResources.Copy;

        public override ExportInformation ExportCapture(bool manuallyInitiated, ISurface surface, ICaptureDetails captureDetails) {
            var exportInformation = new ExportInformation(Designation, Description)
            {
                SuccessMessage = Language.GetString("exported_to_Clipboard")
            };

            try {
				ClipboardHelper.SetClipboardData(surface);
				exportInformation.ExportMade = true;
			} catch (Exception) {
				// TODO: Change to general logic in ProcessExport
				surface.SendMessageEvent(this, SurfaceMessageTyp.Error, Language.GetString(LangKey.editor_clipboardfailed));
			}
			ProcessExport(exportInformation, surface);
			return exportInformation;
		}
	}
}
