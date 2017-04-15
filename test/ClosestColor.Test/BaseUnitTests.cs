using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Colourful;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClosestColor.Test
{
    [TestClass]
    public abstract class BaseUnitTests
    {
        protected readonly IList<IColor> HexColorGroups = new[]
            {
                HexColor.Create(ColorToHex(Color.White)),
                HexColor.Create(ColorToHex(Color.Yellow)),
                HexColor.Create(ColorToHex(Color.Green)),
                HexColor.Create(ColorToHex(Color.BlanchedAlmond)),
                HexColor.Create(ColorToHex(Color.Red)),
                HexColor.Create(ColorToHex(Color.LightPink)),
                HexColor.Create(ColorToHex(Color.Purple)),
                HexColor.Create(ColorToHex(Color.Blue)),
                HexColor.Create(ColorToHex(Color.Orange)),
                HexColor.Create(ColorToHex(Color.CadetBlue)),
                HexColor.Create(ColorToHex(Color.Brown)),
                HexColor.Create(ColorToHex(Color.Gray)),
                HexColor.Create(ColorToHex(Color.Black))
            }.Cast<IColor>()
             .ToArray();


        protected readonly IClosestColor Sut;


        protected BaseUnitTests(IClosestColor sut)
        {
            Sut = sut;
        }




        private static string ColorToHex(Color c)
        {
            var hex = "#" + c.R.ToString(format: "X2") + c.G.ToString(format: "X2") + c.B.ToString(format: "X2");

            return hex;
        }

        protected void TestColor(Color target, Color expectedColor)
        {
            var expectedStr = ColorToHex(expectedColor);
            var expected = HexColor.Create(expectedStr);
            var color = HexColor.Create(ColorToHex(target));

            TestColor(expected, color);
        }

        protected void TestColor(IColor expected, IColor color)
        {
            var actuel = Sut.GetClosestColorInGroup(HexColorGroups, color);

            Assert.AreEqual(expected.Red, actuel.Red, $"Expected {expected} but was {actuel}");
            Assert.AreEqual(expected.Green, actuel.Green, $"Expected {expected} but was {actuel}");
            Assert.AreEqual(expected.Blue, actuel.Blue, $"Expected {expected} but was {actuel}");
        }


        [TestMethod]
        public void Input_null_for_color_groups()
        {
            
            Assert.ThrowsException<ArgumentNullException>(() => Sut.GetClosestColorInGroup(null, HexColor.Create("#000000")));
        }

        [TestMethod]
        public void Input_null_for_color()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Sut.GetClosestColorInGroup(HexColorGroups, null));

        }
    }
}