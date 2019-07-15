
using System;

namespace Shape.Shapes
{
    class Rectangle : IShape
    {
        private double Width { get; set; }

        private double Height { get; set; }

        public string Name { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;

            Height = height;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Height * Width;
        }

        public double GetPerimeter()
        {
            return Width * 2 + Height * 2;
        }

        public override string ToString()
        {
            return "Имя фигуры: " + Name + Environment.NewLine +
                "Тип фигуры: Прямоугольник" + Environment.NewLine +
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

            Rectangle p = (Rectangle)o;

            return Width == p.Width && Height == p.Height;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Height.GetHashCode();
            return hash;
        }
    }
}
