using NUnit.Framework;
using SquareCalc;
using SquareCalc.Base;
using static SquareCalc.Exceptions.TriangleExceptions;

namespace Tests
{
    [TestFixture]
    public class TriangleShape
    {
        [TestCase(0, 1, 2)]
        public void InputValidator(double A, double B, double C)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(A, B, C));
        }

        [TestCase(1, 2, 3)]
        public void IsTriangleValidator(double A, double B, double C)
        {
            Assert.Throws<NotTriangleException>(() => new Triangle(A, B, C));

            Assert.Throws<NotTriangleException>(() =>
            {
                var shape = new Triangle(3, 4, 5);
                shape.A = 1;
            });
        }

        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(5, 5, 5, ExpectedResult = false)]
        public bool IsRightTriangleValidator(double A, double B, double C)
        {
            var shape = new Triangle(A, B, C);

            return shape.IsRightTriangle;
        }

        [TestCase(3, 4, 5, ExpectedResult = 6)]
        [TestCase(5, 5, 5, ExpectedResult = 10.825317547305483)]
        [TestCase(6, 6, 3, ExpectedResult = 8.714212528966687)]
        [TestCase(3, 5, 6, ExpectedResult = 7.483314773547883)]
        public double Square(double sideA, double sideB, double sideC)
        {
            var shape = new Triangle(sideA, sideB, sideC);

            return shape.Square;
        }

        [TestCase(3, 4, 5, ExpectedResult = 6)]
        public double BaseSquare(double sideA, double sideB, double sideC)
        {
            var shape = new Triangle(sideA, sideB, sideC);

            return (shape as Shape).Square;
        }
    }
}
