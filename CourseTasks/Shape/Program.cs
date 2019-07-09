using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Shape[] shapes = new Shape[] { shape1, shape2, shape3, shape4, shape5, shape6, shape7 };
            Shape shapeMaximumArea = Shape.FindMaximumArea(shapes);
            Console.WriteLine("Фигура с максимальной площадью:");
            Console.WriteLine(shapeMaximumArea.ToString());
            Array.Sort(shapes, new ComparePerimetr());
            Shape shapeMaximumPerimetr = shapes[shapes.Length - 2];
            Console.WriteLine("Фигура со вторым по величине периметром:");
            Console.WriteLine(shapeMaximumPerimetr.ToString());
            Console.ReadKey();
        }
    }
}
