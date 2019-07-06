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
                
        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }
        // реализация методов GetHeight, GetArea
    }
}
