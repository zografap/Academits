
using System;

namespace Shape
{
    public class Square :IShape
    {
        public double SideLength { get; set; }

        public string Name { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public  double GetWidth()
        {
            return SideLength;
        }

        public  double GetHeight()
        {
            return SideLength;
        }

        public  double GetArea()
        {
            return SideLength * SideLength;
        }

        public  double GetPerimeter()
        {
            return SideLength * 4;
        }

        public override string ToString()
        {
            return "Имя фигуры: " + Name + Environment.NewLine +
                "Тип фигуры: Квадрат" + Environment.NewLine +
                "Ширина = " + GetWidth() + Environment.NewLine +
                "Высота = " + GetHeight() + Environment.NewLine +
                "Площадь = " + GetArea() + Environment.NewLine +
                "Периметр = " + GetPerimeter();
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
            {
                return false;
            }

            Square p = (Square)o;

            return SideLength == p.SideLength;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + SideLength.GetHashCode();
            return hash;
        }
    }
}
