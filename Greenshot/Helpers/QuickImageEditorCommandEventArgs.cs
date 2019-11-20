using System;

namespace Greenshot.Helpers
{
    public enum QuickImageEditorCommand
    {
        Select,
        Arrow,
        Pencil,
        Line,
        Rectangle,
        Ellipse,
        Text,
        Blur,
        Counter,
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
