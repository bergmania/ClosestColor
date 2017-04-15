using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ClosestColor
{
    public class HueSaturationAndBrightnessClosestColor : IClosestColor
    {
        private readonly float _factorBrightness = 1.0f;
        private readonly float _factorSaturation = 1.5f;
        private readonly float _factorHue = 0.028f;


        public HueSaturationAndBrightnessClosestColor(float factorSaturation, float factorBrightness, float factorHue)
        {
            _factorSaturation = factorSaturation;
            _factorBrightness = factorBrightness;
            _factorHue = factorHue;
        }

        public HueSaturationAndBrightnessClosestColor()
        {
        }


        public IColor GetClosestColorInGroup(IEnumerable<IColor> colorGroups, IColor color)
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
            var num1 = ColorNum(hexColor.Value);
            var diffs = hexColorGroups.Select(n => Math.Abs(ColorNum(n.Value) - num1) +
                                                   _factorHue * ColorHelper.GetHueDistance(n.Value.GetHue(), hue1))
                                      .ToList();
            var diffMin = diffs.Min(x => x);
            return hexColorGroups[diffs.FindIndex(n => Math.Abs(n - diffMin) < float.Epsilon)];
        }

        /// <summary>
        ///     Gets¨a perceived brightness value for a colour.
        /// </summary>
        /// <param name="color">The colour to get the brightness from.</param>
        /// <returns>The float value indicating the brightness. The returned valuge is between 0.0 (Black) and 1.0 (White).</returns>
        /// <remarks>
        ///     Note: This algorithm is taken from a formula for converting RGB values to YIQ values.This brightness value gives a
        ///     perceived brightness for a color.
        ///     See https://www.w3.org/TR/AERT#color-contrast.
        /// </remarks>
        private static float GetBrightness(Color color)
        {
            return (color.R * 0.299f + color.G * 0.587f + color.B * 0.114f) / 256f;
        }


        private float ColorNum(Color c)
        {
            return c.GetSaturation() * _factorSaturation + GetBrightness(c) * _factorBrightness;
        }
    }
}