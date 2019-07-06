using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3 )
        {
            this.X1 = x1;

            this.Y1 = y1;

            this.X2 = x2;

            this.Y2 = y2;

            this.X3 = x3;

            this.Y3 = y3;
        }

        public double GetWidth()
        {
            double[] arrayX = { X1, X2, X3 };
            return arrayX.Max()- arrayX.Min();
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

        public double GetPerimeter()
        {
            return Math.Sqrt(Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2)) +
                Math.Sqrt(Math.Pow((X2 - X3), 2) + Math.Pow((Y2 - Y3), 2)) +
                Math.Sqrt(Math.Pow((X3 - X1), 2) + Math.Pow((Y3 - Y1), 2));
        }
        
    }
}
