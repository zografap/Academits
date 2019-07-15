using Shape.Shapes;
using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape GetShapeMaximumArea(IShape[] figures)
            {
                Array.Sort(figures, new AreaComparer());
                return figures[figures.Length - 1];
            }

            IShape GetFigureSecondLargestPerimeter(IShape[] figures)
            {
                Array.Sort(figures, new PerimeterComparer());
                return figures[figures.Length - 2];
            }

            Triangle shape1 = new Triangle(3, 4, 5, 3, 4, 5);
            shape1.Name = "shape1";

            Triangle shape2 = new Triangle(0, 0, 150, 0, 0, 150);
            shape2.Name = "shape2";

            Circle shape3 = new Circle(0.5);
            shape3.Name = "shape3";

            Circle shape4 = new Circle(1);
            shape4.Name = "shape4";

            Rectangle shape5 = new Rectangle(3, 4);
            shape5.Name = "shape5";

            Rectangle shape6 = new Rectangle(1, 5);
            shape6.Name = "shape6";

            Square shape7 = new Square(150);
            shape7.Name = "shape7";

            IShape[] shapes = new IShape[] { shape1, shape2, shape3, shape4, shape5, shape6, shape7 };

            IShape shapeMaximumArea = GetShapeMaximumArea(shapes);
            Console.WriteLine("Фигура с максимальной площадью:");
            Console.WriteLine(shapeMaximumArea.ToString());

            IShape shapeSecondLargestPerimeter = GetFigureSecondLargestPerimeter(shapes);
            Console.WriteLine("Фигура со вторым по величине периметром:");
            Console.WriteLine(shapeSecondLargestPerimeter.ToString());

            Console.ReadKey();
        }
    }
}
