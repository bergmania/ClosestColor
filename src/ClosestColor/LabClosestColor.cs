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


        public IColor GetClosestColorInGroup(IEnumerable<IColor> colorGroups, IColor color)
        {
            var labColor = GetLabColor(color);
            var labColorGroups = colorGroups.Select(GetLabColor).ToList();

            var diffs = labColorGroups.Select(n => _ciede2000ColorDifference.ComputeDifference(n, labColor))
                                      .ToList();
            var diffMin = diffs.Min(x => x);
            var bestMatch = labColorGroups[diffs.FindIndex(n => Math.Abs(n - diffMin) < float.Epsilon)];

            return GetRgbColor(bestMatch);
        }

        private IColor GetRgbColor(LabColor labColor)
        {
            var rgbColor = _converter.ToRGB(labColor);

            var hex = "#"
                      + ((byte) Math.Round(rgbColor.R * 255.0d, digits: 0)).ToString(format: "X2")
                      + ((byte) Math.Round(rgbColor.G * 255.0d, digits: 0)).ToString(format: "X2")
                      + ((byte) Math.Round(rgbColor.B * 255.0d, digits: 0)).ToString(format: "X2");

            return HexColor.Create(hex);
        }

        private LabColor GetLabColor(IColor color)
        {
            var input = new RGBColor(color.Red / 255.0f, color.Green / 255.0f, color.Blue / 255.0f);

            return _converter.ToLab(input);
        }
    }
}