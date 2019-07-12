using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class MaximumArea
    {
        public static IShape FindMaximumArea(IShape[] shapes)
        {
            Array.Sort(shapes, new AreaComparer());
            return shapes[shapes.Length - 1];
        }
    }
}
