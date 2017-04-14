using System;
using System.Drawing;

namespace ClosestColor
{
    internal static class ColorHelper
    {
        public static float GetHueDistance(float hue1, float hue2)
        {
            var d = Math.Abs(hue1 - hue2);
            return d > 180 ? 360 - d : d;
        }

        public static int ColorDiff(Color c1, Color c2)
        {
            return (int) Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
                                   + (c1.G - c2.G) * (c1.G - c2.G)
                                   + (c1.B - c2.B) * (c1.B - c2.B));
        }
    }
}