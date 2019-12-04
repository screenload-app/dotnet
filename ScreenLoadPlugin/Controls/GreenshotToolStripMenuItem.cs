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

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenLoadPlugin.Controls
{
    public class ScreenLoadToolStripMenuItem : ToolStripMenuItem, IScreenLoadLanguageBindable
    {
        private Image _image;
        private Icon _icon;

        [Category("ScreenLoad"), DefaultValue(null),
         Description("Specifies key of the language file to use when displaying the text.")]
        public string LanguageKey { get; set; }

        public Icon Icon
        {
            get => _icon;
            set
            {
                _image = null;
                _icon = value;
            }
        }

        public override Image Image
        {
            get
            {
                if (null != _image && PixelFormat.DontCare != _image.PixelFormat &&
                    _image.Size.Width == Owner.ImageScalingSize.Width)
                    return _image;

                if (null == Icon)
                    return _image;

                _image = new Icon(Icon, Owner.ImageScalingSize).ToBitmap();

                return _image;
            }
            set => _image = value;
        }
    }
}
