using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle shape1 = new Triangle(3, 4, 5, 3, 4, 5);
            Triangle shape2 = new Triangle(30, 40, 50, 30, 40, 50);
            Circle shape3 = new Circle(3);
            Circle shape4 = new Circle(30);
            Rectangle shape5 = new Rectangle(3, 4);
            Rectangle shape6 = new Rectangle(30, 40);
            Shape[] shapes = new Shape[] { shape1, shape2, shape3, shape5, shape6 };
            Array.Sort(shapes, new ShapeComparer());
            Console.WriteLine(
        }
    }
}
