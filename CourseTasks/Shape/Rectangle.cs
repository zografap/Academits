using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Rectangle : Shape, IShape
    {
        public double WidthRectangle { get; set; }

        public double HeightRectangle { get; set; }

        public Rectangle(double widthRectangle, double heightRectangle)
        {
            this.WidthRectangle = widthRectangle;

            this.HeightRectangle = heightRectangle;
        }

        public double GetWidth()
        {
            return WidthRectangle;
        }

        public double GetHeight()
        {
            return HeightRectangle;
        }

        public double GetArea()
        {
            return HeightRectangle * WidthRectangle;
        }

        public double GetPerimeter()
        {
            return WidthRectangle * 2 + HeightRectangle * 2;
        }
    }
}
