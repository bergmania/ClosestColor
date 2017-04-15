using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClosestColor.Test
{
    [TestClass]
    public class RgbClosestColorUnitTests : BaseUnitTests
    {
        public RgbClosestColorUnitTests()
            : base(new RgbClosestColor())
        {
        }


        [TestMethod]
        public void The_exact_color_must_be_found_if_inputed()
        {
            foreach (var hexColor in HexColorGroups)
            {
                TestColor(hexColor, hexColor);
            }
        }

        [TestMethod]
        public void LightBlue()
        {
            TestColor(Color.LightBlue, Color.BlanchedAlmond);
        }

        [TestMethod]
        public void LightSeaGreen()
        {
            TestColor(Color.LightSeaGreen, Color.CadetBlue);
        }

        [TestMethod]
        public void GreenYellow()
        {
            TestColor(Color.GreenYellow, Color.Yellow);
        }

        [TestMethod]
        public void YellowGreen()
        {
            TestColor(Color.YellowGreen, Color.Gray);
        }


        [TestMethod]
        public void Magenta()
        {
            TestColor(Color.Magenta, Color.Purple);
        }

        [TestMethod]
        public void DarkMagenta()
        {
            TestColor(Color.DarkMagenta, Color.Purple);
        }

        [TestMethod]
        public void Fuchsia()
        {
            TestColor(Color.Fuchsia, Color.Purple);
        }

        [TestMethod]
        public void Indigo()
        {
            TestColor(Color.Indigo, Color.Purple);
        }

        [TestMethod]
        public void DarkViolet()
        {
            TestColor(Color.DarkViolet, Color.Purple);
        }

        [TestMethod]
        public void MediumOrchid()
        {
            TestColor(Color.MediumOrchid, Color.Gray);
        }

        [TestMethod]
        public void Crimson()
        {
            TestColor(Color.Crimson, Color.Brown);
        }

        [TestMethod]
        public void OrangeRed()
        {
            TestColor(Color.OrangeRed, Color.Red);
        }

        [TestMethod]
        public void Tomato()
        {
            TestColor(Color.Tomato, Color.Orange);
        }

        [TestMethod]
        public void Chocolate()
        {
            TestColor(Color.Chocolate, Color.Brown);
        }

        [TestMethod]
        public void Khaki()
        {
            TestColor(Color.Khaki, Color.BlanchedAlmond);
        }

        [TestMethod]
        public void LawnGreen()
        {
            TestColor(Color.LawnGreen, Color.Yellow);
        }

        [TestMethod]
        public void Olive()
        {
            TestColor(Color.Olive, Color.Brown);
        }

        [TestMethod]
        public void Sienna()
        {
            TestColor(Color.Sienna, Color.Brown);
        }

        [TestMethod]
        public void OliveDrab()
        {
            TestColor(Color.OliveDrab, Color.Gray);
        }
    }
}