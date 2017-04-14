using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestColor
{
    public class HueClosestColor : IClosestColor
    {
        public IColor GetClosestColorInGroup(IEnumerable<IColor> colorGroups, IColor color)
        {
            var hexColor = HexColor.Create(color);
            var hexColorGroups = colorGroups.Select(HexColor.Create).ToList();

            var hue1 = hexColor.Value.GetHue();
            var diffs = hexColorGroups.Select(n => ColorHelper.GetHueDistance(n.Value.GetHue(), hue1)).ToList();
            var diffMin = diffs.Min(n => n);
            return hexColorGroups[diffs.ToList().FindIndex(n => Math.Abs(n - (diffMin)) < float.Epsilon)];
        }
    }
}