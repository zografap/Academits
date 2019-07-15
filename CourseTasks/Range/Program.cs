using System;

namespace Range
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начало диапазона 1");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец диапазона 1");
            double to = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(from, to);

            Console.WriteLine("Введите начало диапазона 2");
            double from2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец диапазона 2");
            double to2 = Convert.ToDouble(Console.ReadLine());

            Range range2 = new Range(from2, to2);

            Console.WriteLine("Длинна диапазона 1 = " + range1.GetLength());
            Console.WriteLine("Длинна диапазона 2 = " + range2.GetLength());

            if (range1.IsCrossing(range2))
            {
                Console.WriteLine("Интервалы пересекаются");
                Console.WriteLine("Результат пересечения интервалов:");
                Range result = range1.GetIntersection(range2);
                Console.WriteLine("от " + result.From + " до " + result.To);
            }
            else
            {
                Console.WriteLine("Интервалы не пересекаются");
            }

            Range[] resultUnion = range1.GetUnion(range2);
            Console.WriteLine("Результат объединения интервалов:");

            foreach (Range interval in resultUnion)
            {
                Console.WriteLine("от " + interval.From + " до " + interval.To);
            }

            Console.WriteLine("Результат разности интервалов:");
            Range[] resultDifference = range1.GetDifference(range2);

            if (resultDifference.Length == 0)
            {
                Console.WriteLine("null");
            }
            else
            {
                foreach (Range interval in resultDifference)
                {
                    Console.WriteLine("от " + interval.From + " до " + interval.To);
                }
            }
            Console.ReadKey();
        }
    }
}
