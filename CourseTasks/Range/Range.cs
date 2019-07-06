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
            return (To - From);
        }

        public bool IsInside(double x)
        {
            return (x >= From && x <= To);
        }

        public bool IsCheckCrossingIntervals(Range interval)
        {
            return (From <= interval.To && To >= interval.From);
        }

        public Range[] IsCrossingIntervals(Range interval)
        {
            Range[] result = new Range[2];
            double[] array = { From, To, interval.From, interval.To };
            Array.Sort(array);

            if (IsCheckCrossingIntervals(interval))
            {
                result[0] = new Range(array[1], array[2]);
                return result;
            }
            result[0] = new Range(array[0], array[1]);
            result[1] = new Range(array[2], array[3]);
            return result;
        }

        public Range[] UnionIntervals(Range interval)
        {
            Range[] result = new Range[2];
            double[] array = { From, To, interval.From, interval.To };
            Array.Sort(array);

            if (IsCheckCrossingIntervals(interval))
            {
                result[0] = new Range(array[0], array[3]);
                return result;
            }

            result[0] = new Range(array[0], array[1]);
            result[1] = new Range(array[2], array[3]);
            return result;
        }

        public Range[] DifferenceIntervals(Range interval)
        {
            Range[] result = new Range[2];

            if (IsCheckCrossingIntervals(interval))
            {
                if (From == interval.From && To == interval.To)
                {
                    return result;
                }
                if (From == interval.From && To > interval.To)
                {
                    result[0] = new Range(interval.To, To);
                    return result;
                }
                if (From == interval.From && To < interval.To)
                {
                    return result;
                }
                if (From > interval.From && To == interval.To)
                {
                    return result;
                }
                if (From < interval.From && To == interval.To)
                {
                    result[0] = new Range(From, interval.From);
                    return result;
                }
                if (From > interval.From && To < interval.To)
                {
                    return result;
                }
                if (From < interval.From && To > interval.To)
                {
                    result[0] = new Range(From, interval.From);
                    result[1] = new Range(interval.To, To);
                    return result;
                }
                if (From < interval.From && To < interval.To)
                {
                    result[0] = new Range(From, interval.From);
                    return result;
                }
                if (From > interval.From && To > interval.To)
                {
                    result[0] = new Range(From, interval.From);
                    return result;
                }
            }
            return result;
        }
    }
} 
