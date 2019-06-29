using System;

namespace Range
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начало диапазона");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец диапазона");
            double to = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(from, to);

            Console.WriteLine("Введите число X");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Длинна диапазона = " + range1.GetLength());

            if (range1.IsInside(x))
            {
                Console.WriteLine("Число принадлежит диапазону");
            }
            else
            {
                Console.WriteLine("Число не принадлежит диапазону");
            }
            Console.ReadKey();
        }
    }
}
