using System.Collections.Generic;

namespace Shape
{
    class ComparePerimetr : IComparer<Shape>
    {
        public int Compare(Shape shape1, Shape shape2)
        {
            if (shape1.GetPerimeter() > shape2.GetPerimeter())
                return 1;
            else if (shape1.GetPerimeter() < shape2.GetPerimeter())
                return -1;
            else
                return 0;
        }

    }
}
