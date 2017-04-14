using System.Drawing;

namespace ClosestColor
{
    public struct HexColor : IColor
    {
        internal Color Value { get; }
        public byte Red => Value.R;
        public byte Green => Value.G;
        public byte Blue => Value.B;

        private HexColor(Color color)
        {
            Value = color;
        }

        public static HexColor Create(IColor color)
        {
            var value = Color.FromArgb(color.Red, color.Green, color.Blue);
            return new HexColor(value);
        }

        public static HexColor Create(string value)
        {
            var color = ColorTranslator.FromHtml(value);

            return new HexColor(color);
        }

        public override string ToString()
        {
            var hex = "#" + Red.ToString(format: "X2") + Green.ToString(format: "X2") + Blue.ToString(format: "X2");

            return hex;

   
        }
    }
}