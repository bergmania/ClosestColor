using System;
using System.Collections.Generic;
using System.Linq;
using Colourful;
using Colourful.Conversion;
using Colourful.Difference;

namespace ClosestColor
{
    public class LabClosestColor : IClosestColor
    {
        private readonly CIEDE2000ColorDifference _ciede2000ColorDifference = new CIEDE2000ColorDifference();

        private readonly ColourfulConverter _converter = new ColourfulConverter {WhitePoint = Illuminants.D65};


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


            var labColor = GetLabColor(color);
            var labColorGroups = colorGroups.Select(GetLabColor).ToList();

            var diffs = labColorGroups.Select(n => _ciede2000ColorDifference.ComputeDifference(n, labColor))
                                      .ToList();
            var diffMin = diffs.Min(x => x);

            return colorGroups.Where(
                                     (x, i) => diffs.FindAllIndexes(n => Math.Abs(n - diffMin) < float.Epsilon).Contains(i))
                              .ToList();
        }

        private LabColor GetLabColor(IColor color)
        {
            var input = new RGBColor(color.Red / 255.0f, color.Green / 255.0f, color.Blue / 255.0f);

            return _converter.ToLab(input);
        }
    }
}