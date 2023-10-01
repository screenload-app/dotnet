using System;

namespace ScreenLoad.Helpers
{
    public enum QuickImageEditorCommand
    {
        Tool,
        Color,
        Undo,
        Upload,
        Copy,
        Save,
        Close,
        More
    }

    public sealed class QuickImageEditorCommandEventArgs : EventArgs
    {
        public QuickImageEditorCommand Command { get; set; }
        public object Argument { get; set; }

        public QuickImageEditorCommandEventArgs(QuickImageEditorCommand command)
        {
            Command = command;
        }
    }
}
