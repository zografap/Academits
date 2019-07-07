using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public abstract class Shape
    {
        public string Name { get; set; }

        private double Width { get; set; }

        private double Height { get; set; }

        private double Area { get; set; }

        public abstract double GetWidth();

        public abstract double GetHeight();

        public abstract double GetArea();        public abstract double GetPerimeter();        public static Shape FindMaximumArea(Shape[] shapes)
        {
            Array.Sort(shapes, new ShapeComparer());
            return shapes[shapes.Length - 1];
        }    }
}
