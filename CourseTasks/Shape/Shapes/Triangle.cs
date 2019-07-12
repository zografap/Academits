using System;
using System.Linq;

namespace Shape
{
    class Triangle : IShape
    {
        public double X1 { get; set; }

        public double X2 { get; set; }

        public double X3 { get; set; }

        public double Y1 { get; set; }

        public double Y2 { get; set; }

        public double Y3 { get; set; }

        public string Name { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;

            Y1 = y1;

            X2 = x2;

            Y2 = y2;

            X3 = x3;

            Y3 = y3;
        }

        public double GetWidth()
        {
            double[] arrayX = { X1, X2, X3 };
            return arrayX.Max() - arrayX.Min();
        }

        public double GetHeight()
        {
            double[] arrayY = { Y1, Y2, Y3 };
            return arrayY.Max() - arrayY.Min();
        }

        public double GetArea()
        {
            return 0.5 * GetWidth();
        }

        public double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }

        public double GetPerimeter()
        {
            return GetDistance(X1, Y1, X2, Y2) + GetDistance(X2, Y2, X3, Y3) +
                GetDistance(X3, Y3, X1, Y1);
        }

        public override string ToString()
        {
            return "Имя фигуры: " + Name + Environment.NewLine +
                "Тип фигуры: Треугольник" + Environment.NewLine +
                "X1 = " + X1 + "  " + "Y1 = " + Y1 + Environment.NewLine +
                "X2 = " + X2 + "  " + "Y2 = " + Y2 + Environment.NewLine +
                "X3 = " + X3 + "  " + "Y3 = " + Y3 + Environment.NewLine +
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

            Triangle p = (Triangle)o;

            return X1 == p.X1 && Y1 == p.Y1 && X2 == p.X2 && Y2 == p.Y2
                && X3 == p.X3 && Y1 == p.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();
            return hash;
        }
    }
}
