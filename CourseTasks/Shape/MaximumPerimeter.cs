using System;

namespace Shape
{
    class MaximumPerimeter
    {
        public static IShape FindMaximumPerimeter(IShape[] shapes)
        {
            Array.Sort(shapes, new PerimeterComparer());
            return shapes[shapes.Length - 1];
        }
    }
}
