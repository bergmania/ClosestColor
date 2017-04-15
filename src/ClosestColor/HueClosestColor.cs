using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestColor
{
    public class HueClosestColor : IClosestColor
    {
        public IReadOnlyList<IColor> GetClosestColorInGroup(IReadOnlyList<IColor> colorGroups, IColor color)
        {
            if (colorGroups == null)
            {
                throw new ArgumentNullException(nameof(colorGroups));
            }
            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            var hexColor = HexColor.Create(color);
            var hexColorGroups = colorGroups.Select(HexColor.Create).ToList();

            var hue1 = hexColor.Value.GetHue();
            var diffs = hexColorGroups.Select(n => ColorHelper.GetHueDistance(n.Value.GetHue(), hue1)).ToList();
            var diffMin = diffs.Min(n => n);

            return colorGroups.Where(
                                     (x, i) => diffs.FindAllIndexes(n => Math.Abs(n - diffMin) < float.Epsilon)
                                                    .Contains(i))
                              .ToList();
        }
    }
}