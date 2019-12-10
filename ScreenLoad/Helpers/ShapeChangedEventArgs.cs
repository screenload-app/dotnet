using System;

namespace ScreenLoad.Helpers
{
    public enum ToolboxShape
    {
        Rectangle,
        Ellipse,
        Line
    }

    public sealed class ShapeChangedEventArgs : EventArgs
    {
        public ToolboxShape Shape { get; }

        public ShapeChangedEventArgs(ToolboxShape shape)
        {
            Shape = shape;
        }
    }
}
