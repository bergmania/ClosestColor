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
    }
}