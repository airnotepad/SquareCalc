using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalc.Exceptions
{
    public class TriangleExceptions
    {
        /// <summary>
        /// Обозначает невозможность существования треугольника
        /// </summary>
        public class NotTriangleException : Exception
        {
            public NotTriangleException(string? message) : base(message) { }
        }
    }
}
