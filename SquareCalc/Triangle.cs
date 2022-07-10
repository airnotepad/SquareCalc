using SquareCalc.Base;
using static SquareCalc.Exceptions.TriangleExceptions;

namespace SquareCalc
{
    public class Triangle : Shape
    {
        private double _a;
        private double _b;
        private double _c;

        /// <summary>
        /// Сторона A
        /// </summary>
        public double A { get { return _a; } set { Validate(nameof(A), value); _a = value; CheckTriangle(); } }

        /// <summary>
        /// Сторона B
        /// </summary>
        public double B { get { return _b; } set { Validate(nameof(B), value); _b = value; CheckTriangle(); } }

        /// <summary>
        /// Сторона C
        /// </summary>
        public double C { get { return _c; } set { Validate(nameof(C), value); _c = value; CheckTriangle(); } }

        /// <summary>
        /// Определяет есть ли в треугольнике прямой угол 
        /// </summary>
        public bool IsRightTriangle
        {
            get => CheckIsRightTriangle();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="A">Сторона A</param>
        /// <param name="B">Сторона B</param>
        /// <param name="C">Сторона C</param>
        /// <exception cref="ArgumentOutOfRangeException">Исключение при проверке стороны (радиуса должен быть больше нуля)</exception>
        public Triangle(double A, double B, double C)
        {
            Validate(nameof(A), A);
            Validate(nameof(B), B);
            Validate(nameof(C), C);

            _a = A;
            _b = B;
            _c = C;

            CheckTriangle();
        }

        /// <summary>
        /// Вычисление площади треугольника по трем сторонам (формул Герона)
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        private protected override double CalculateSquare()
        {
            double semiperimeter = (A + B + C) / 2;

            return Math.Sqrt(semiperimeter * (semiperimeter - A) * (semiperimeter - B) * (semiperimeter - C));
        }

        /// <summary>
        /// Проверка треугольника на прямоугольность по теореме Пифагора
        /// </summary>
        /// <returns>Значение соответствия треугольника прямоугольному</returns>
        private protected bool CheckIsRightTriangle()
        {
            var sides = new[] { A, B, C };
            var hypotenuse = sides.Max();
            var cathetus = sides.Where(side => side != hypotenuse);

            return (float)(hypotenuse * hypotenuse) == cathetus.Sum(side => side * side);
        }

        private void Validate(string ParamName, double input)
        {
            if (input <= 0) throw new ArgumentOutOfRangeException(ParamName, $"Сторона {ParamName} должна быть больше нуля");
        }

        private void CheckTriangle()
        {
            var isTriangle = _a + _b > _c
                          && _a + _c > _b
                          && _b + _c > _a;

            if (!isTriangle) throw new NotTriangleException("Треугольника с такими размерами сторон не существует");
        }
    }
}
