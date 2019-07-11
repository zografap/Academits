using System;

namespace Range
{
    public class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double x)
        {
            return x >= From && x <= To;
        }

        public bool IsCrossingIntervals(Range interval)
        {
            return From <= interval.To && To >= interval.From;
        }

        public Range GetIntervalsCrossing(Range interval)
        {
            double[] array = { From, To, interval.From, interval.To };
            Array.Sort(array);

            if (IsCrossingIntervals(interval))
            {
                Range result = new Range(array[1], array[2]);
                return result;
            }
            return null;
        }

        public Range[] UnionIntervals(Range interval)
        {
            double[] array = { From, To, interval.From, interval.To };
            Array.Sort(array);

            if (IsCrossingIntervals(interval))
            {
                Range result = new Range(array[0], array[3]);
                Range[] resultArray1 = new[] { result };
                return resultArray1;
            }
            Range result1 = new Range(array[0], array[1]);
            Range result2 = new Range(array[2], array[3]);
            Range[] resultArray2 = { result1, result2 };
            return resultArray2;
        }

        public Range[] DifferenceIntervals(Range interval)
        {
            if (IsCrossingIntervals(interval))
            {
                if (From >= interval.From && To <= interval.To)
                {
                    return null;
                }
                if (From <= interval.From && To >= interval.To)
                {
                    Range[] result = { new Range(From, interval.From), new Range(interval.To, To) };
                    return result;
                }
                if (From <= interval.From && To <= interval.To)
                {
                    Range[] result = { new Range(From, interval.From) };
                    return result;
                }
                if (From >= interval.From && To >= interval.To)
                {
                    Range[] result = { new Range(interval.To, To) };
                    return result;
                }
            }
            return null;
        }
    }
}
