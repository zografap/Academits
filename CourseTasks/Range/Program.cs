using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    public class Range
    {
        private double from;
        private double to;

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public double getFrom()
        {
            return from;
        }

        public double getTo()
        {
            return to;
        }

        public void setFrom(double from)
        {
            this.from = from;
        }

        public void setTo(double to)
        {
            this.to = to;
        }

        public double getLength()
        {

            return (to - from);
        }

        public bool isInside(double x)
        {
            return (x >= from && x <= to);
        }
    }
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

            Console.WriteLine("Длинна диапазона = " + range1.getLength());

            if (range1.isInside(x))
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
