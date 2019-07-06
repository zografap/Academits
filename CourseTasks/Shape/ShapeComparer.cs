using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class ShapeComparer : IComparer<Shape>
    {
        public int Compare(Shape shape1, Shape shape2)
        {
            if (shape1.GetArea() > shape2.GetArea())
                return 1;
            else if (shape1.GetArea() < shape2.GetArea())
                return -1;
            else
                return 0;
        }
    }
}
