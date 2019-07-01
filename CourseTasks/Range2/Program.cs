using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range2
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
            double to2= Convert.ToDouble(Console.ReadLine());

            Range range2 = new Range(from2, to2);

            Console.WriteLine("Длинна диапазона 1 = " + range1.GetLength());
            Console.WriteLine("Длинна диапазона 2 = " + range2.GetLength());

            double[] array = { from, to, from2, to2 };
            Array.Sort(array);

            if (Range.IntersectionIntervals(range1, range2))
            {
                Console.WriteLine("Интервалы пересекаются");
                if (from == from2 && to == to2)
                {
                    Console.WriteLine("Результат пересечения интервалов:");
                    Console.WriteLine("от " + from + " до " + to);
                }
                else
                {
                    Console.WriteLine("Результат пересечения интервалов:");
                    Console.WriteLine("от " + array[1] + " до " + array[2]);
                    Console.WriteLine("Результат объединения интервалов:");
                    Console.WriteLine("от " + array[0] + " до " + array[4]);
                }
            } 
            else
            {
                Console.WriteLine("Интервалы не пересекаются");
                Console.WriteLine("Результат объединения интервалов:");
                Console.WriteLine("от " + array[0] + " до " + array[1] + 
                    " и " + "от " + array[2] + " до " + array[3]);
            }
            Console.ReadKey();
        }
    }
}
