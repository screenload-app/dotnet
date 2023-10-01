﻿/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2016  Thomas Braun, Jens Klingen, Robin Krom
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

using ScreenLoad.IniFile;
using ScreenLoadPlugin.Core;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenLoad.Controls
{
    /// <summary>
    /// ToolStripProfessionalRenderer which draws the Check correctly when the icons are larger
    /// </summary>
    public class ContextMenuToolStripProfessionalRenderer : ToolStripProfessionalRenderer
    {
        private static readonly CoreConfiguration CoreConfig = IniConfig.GetIniSection<CoreConfiguration>();

        private static Image _scaledCheckbox;

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            if (_scaledCheckbox == null || _scaledCheckbox.Size != CoreConfig.IconSize)
            {
                _scaledCheckbox?.Dispose();
                _scaledCheckbox = ImageHelper.ResizeImage(e.Image, true, CoreConfig.IconSize.Width,
                    CoreConfig.IconSize.Height, null);
            }

            ToolStripItemImageRenderEventArgs clone = new ToolStripItemImageRenderEventArgs(e.Graphics, e.Item,
                _scaledCheckbox, e.ImageRectangle);

            base.OnRenderItemCheck(clone);
        }

    }
}