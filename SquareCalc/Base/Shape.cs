namespace SquareCalc.Base
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public double Square
        {
            get { return CalculateSquare(); }
        }
        /// <summary>
        /// Метод для переопределения
        /// Используется для расчета площади
        /// </summary>
        private protected abstract double CalculateSquare();
    }
}