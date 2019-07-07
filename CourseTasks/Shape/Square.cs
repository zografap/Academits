using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Square : Shape, IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            this.SideLength = sideLength;
        }
                
        public override double GetWidth()
        {
            return SideLength;
        }

        public override double GetHeight()
        {
            return SideLength;
        }

        public override double GetArea()
        {
            return SideLength * SideLength;
        }

        public override double GetPerimeter()
        {
            return SideLength * 4;
        }

        public override string ToString()
        {
            return "Имя фигуры: " + Name + "\n" +
                "Тип фигуры: Квадрат \n" +
                "Ширина = " + GetWidth() + "\n" +
                "Высота = " + GetHeight() + "\n" +
                "Площадь = " + GetArea() + "\n" +
                "Периметр = " + GetPerimeter();
        }
    }
}
