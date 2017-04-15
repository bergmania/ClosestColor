using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClosestColor.Test
{
    [TestClass]
    public class HueClosestColorUnitTests : BaseUnitTests
    {
        public HueClosestColorUnitTests()
            : base(new HueClosestColor())
        {
        }

        [TestMethod]
        public void The_hue_distance_to_red_and_lime_is_equal_from_blue()
        {
            IReadOnlyList<IColor> colorGroups = new List<IColor>()
                {
                    HexColor.Create(ColorToHex(Color.Red)),
                    HexColor.Create(ColorToHex(Color.Lime)),
                    HexColor.Create(ColorToHex(Color.Yellow)),
                };

            var color = HexColor.Create(ColorToHex(Color.Blue));


            var actual = Sut.GetClosestColorInGroup(colorGroups, color);

            Assert.AreEqual(2, actual.Count);
        }
    }
}