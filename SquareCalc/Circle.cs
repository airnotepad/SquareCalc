using SquareCalc.Base;

namespace SquareCalc
{
    public class Circle : Shape
    {
        private double _radius;

        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius { get { return _radius; } set { Validate(nameof(Radius), value); _radius = value; } }

        /// <summary>
        /// Конструктор круга
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Площадь круга по формуле Архимеда (PR^2)
        /// </summary>
        /// <returns></returns>
        private protected override double CalculateSquare() => Math.PI* Radius * Radius;

        /// <summary>
        /// Валидация параметров для инициализации длины радиуса
        /// </summary>
        /// <param name="ParamName">Обозначение радиуса</param>
        /// <param name="input">Значение параметра</param>
        /// <exception cref="ArgumentOutOfRangeException">Неправильное значение длины</exception>
        private void Validate(string ParamName, double input)
        {
            if (input <= 0) throw new ArgumentOutOfRangeException(ParamName, $"Сторона {ParamName} должна быть больше нуля");
        }
    }
}