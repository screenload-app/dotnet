using System;
using Greenshot.Drawing;

namespace Greenshot.Helpers
{
    public enum QuickImageEditorAction
    {
        None,
        Cancel,
        DownloadRu,
        Editor
    }

    public sealed class QuickImageEditorResult
    {
        public QuickImageEditorAction Action { get; }
        public Surface Surface { get; }

        public QuickImageEditorResult(QuickImageEditorAction action, Surface surface = null)
        {
            switch (action)
            {
                case QuickImageEditorAction.DownloadRu:
                case QuickImageEditorAction.Editor:

                    if (null == surface)
                        throw new ArgumentNullException(nameof(surface));

                    break;
            }

            Action = action;
            Surface = surface;
        }
    }
}
