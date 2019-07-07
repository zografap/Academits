using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Circle : Shape, IShape 
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetWidth()
        {
            return Radius * 2;
        }

        public override double GetHeight()
        {
            return Radius * 2;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return "Имя фигуры: " + Name + "\n" +
                "Тип фигуры: Окружность \n" +
                "Радиус = " + Radius + "\n" +
                "Ширина = " + GetWidth() + "\n" +
                "Высота = " + GetHeight() + "\n" +
                 "Площадь = " + GetArea() + "\n" +
                "Периметр = " + GetPerimeter();
        }
    }
}
