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

            if (range1.IsCheckCrossingIntervals(range2))
            {
                Console.WriteLine("Интервалы пересекаются");
                Console.WriteLine("Результат пересечения интервалов:");
                Range[] result = range1.IsCrossingIntervals(range2);

                foreach (Range interval in result)
                {
                    if (interval != null)
                    {
                        Console.WriteLine("от " + interval.From + " до " + interval.To);
                    }
                }
            }
            else
            {
                Console.WriteLine("Интервалы не пересекаются");
            }

            Range[] resultUnion = range1.UnionIntervals(range2);
            Console.WriteLine("Результат объединения интервалов:");

            foreach (Range interval in resultUnion)
            {
                if (interval != null)
                {
                    Console.WriteLine("от " + interval.From + " до " + interval.To);
                }
            }

            Console.WriteLine("Результат разности интервалов:");
            Range[] resultDifference = range1.DifferenceIntervals(range2);

            foreach (Range interval in resultDifference)
            {
                if (interval != null)
                {
                    Console.WriteLine("от " + interval.From + " до " + interval.To);
                }
                else
                {
                    Console.WriteLine("null");
                }
            }
            Console.ReadKey();
        }
    }
}
