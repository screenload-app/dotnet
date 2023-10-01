using System.Drawing;

namespace ScreenLoad.Helpers
{
    internal static class ColorUtility
    {
        public static Color CalculateContrastColor(Color color)
        {
            var contrastColor = Color.White;

            if (color.R > 127 && color.G > 127 && color.B > 127)
                contrastColor = Color.DimGray;

            return contrastColor;
        }

        public static bool IsDark(Color color)
        {
            if (color.R > 127 && color.G > 127 && color.B > 127)
                return false;

            return true;
        }
    }
}
