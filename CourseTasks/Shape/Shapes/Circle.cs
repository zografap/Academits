using System;

namespace Shape
{
    class Circle : IShape
    {
        public string Name { get; set; }

        private double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public  double GetWidth()
        {
            return Radius * 2;
        }

        public  double GetHeight()
        {
            return Radius * 2;
        }

        public  double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public  double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return "Имя фигуры: " + Name + Environment.NewLine + 
                "Тип фигуры: Окружность" + Environment.NewLine +
                "Радиус = " + Radius + Environment.NewLine +
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

            Circle p = (Circle)o;

            return Radius == p.Radius;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + Radius.GetHashCode();
            return hash;
        }
    }
}
