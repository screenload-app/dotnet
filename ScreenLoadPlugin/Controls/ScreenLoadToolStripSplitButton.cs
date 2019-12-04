using System.ComponentModel;
using System.Windows.Forms;

namespace ScreenLoadPlugin.Controls
{
    public class ScreenLoadToolStripSplitButton : ToolStripSplitButton, IScreenLoadLanguageBindable
    {
        [Category("ScreenLoad"), DefaultValue(null),
         Description("Specifies key of the language file to use when displaying the text.")]
        public string LanguageKey { get; set; }
    }
}