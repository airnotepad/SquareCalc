using NUnit.Framework;
using SquareCalc;

namespace Tests
{
    [TestFixture]
    public class CircleShape
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void InputValidator(double input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(input));
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var shape = new Circle(5);
                shape.Radius = input;
            });
        }

        [TestCase(10, ExpectedResult = 314.1592653589793)]
        public double Square(double input)
        {
            var shape = new Circle(input);

            return shape.Square;
        }
    }
}