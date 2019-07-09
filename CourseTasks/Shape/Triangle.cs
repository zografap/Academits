using System;
using System.Linq;

namespace Shape
{
    class Triangle : Shape, IShape
    {
        public double X1 { get; set; }

        public double X2 { get; set; }

        public double X3 { get; set; }

        public double Y1 { get; set; }

        public double Y2 { get; set; }

        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;

            Y1 = y1;

            X2 = x2;

            Y2 = y2;

            X3 = x3;

            Y3 = y3;
        }

        public override double GetWidth()
        {
            double[] arrayX = { X1, X2, X3 };
            return arrayX.Max() - arrayX.Min();
        }

        public override double GetHeight()
        {
            double[] arrayY = { Y1, Y2, Y3 };
            return arrayY.Max() - arrayY.Min();
        }

        public override double GetArea()
        {
            return 0.5 * GetWidth();
        }

        public override double GetPerimeter()
        {
            return Math.Sqrt(Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2)) +
                Math.Sqrt(Math.Pow((X2 - X3), 2) + Math.Pow((Y2 - Y3), 2)) +
                Math.Sqrt(Math.Pow((X3 - X1), 2) + Math.Pow((Y3 - Y1), 2));
        }

        public override string ToString()
        {
            return "Имя фигуры: " + Name + "\n" +
                "Тип фигуры: Треугольник \n" +
                "X1 = " + X1 + "  " + "Y1 = " + Y1 + "\n" +
                "X2 = " + X2 + "  " + "Y2 = " + Y2 + "\n" +
                "X3 = " + X3 + "  " + "Y3 = " + Y3 + "\n" +
                "Ширина = " + GetWidth() + "\n" +
                "Высота = " + GetHeight() + "\n" +
                "Площадь = " + GetArea() + "\n" +
                "Периметр = " + GetPerimeter();
        }
    }
}
