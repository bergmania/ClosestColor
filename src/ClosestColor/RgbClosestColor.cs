using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestColor
{
    public class RgbClosestColor : IClosestColor
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

            var colorDiffs = hexColorGroups.Select(n => ColorHelper.ColorDiff(HexColor.Create(n).Value, hexColor.Value))
                                           .Min(n => n);

            return colorGroups.Where(
                (x, i) => hexColorGroups.FindAllIndexes(n => 
                ColorHelper.ColorDiff(n.Value, hexColor.Value) ==colorDiffs).Contains(i))
                .ToList();
           

        }

  
    }
}