using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenLoadPlugin.Controls
{
    public class ScreenLoadToolStripSplitButton : ToolStripSplitButton, IScreenLoadLanguageBindable
    {
        [Category("ScreenLoad"), DefaultValue(null),
         Description("Specifies key of the language file to use when displaying the text.")]
        public string LanguageKey { get; set; }

        public Icon Icon
        {
            set => Image = new Icon(value, Owner.ImageScalingSize).ToBitmap();
        }
    }
}