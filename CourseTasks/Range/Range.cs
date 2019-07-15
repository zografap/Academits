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

        public bool IsCrossing(Range interval)
        {
            return From <= interval.To && To >= interval.From;
        }

        public Range GetIntersection(Range range)
        {
            if (From >= range.To || range.From >= To)
            {
                return null;
            }

            if (From <= range.From && To >= range.To)
            {
                return new Range(range.From, range.To);
            }

            if (From > range.From && To < range.To)
            {
                return new Range(From, To);
            }

            if (From <= range.From && To <= range.To)
            {
                return new Range(range.From, To);
            }

            return new Range(From, range.To);
        }

        public Range[] GetUnion(Range range)
        {
            if (From > range.To || range.From > To)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            if (From <= range.From && To >= range.To)
            {
                return new Range[] { new Range(From, To) };
            }

            if (From > range.From && To < range.To)
            {
                return new Range[] { new Range(range.From, range.To) };
            }

            if (From <= range.From && To <= range.To)
            {
                return new Range[] { new Range(From, range.To) };
            }

            return new Range[] { new Range(range.From, To) };
        }

        public Range[] GetDifference(Range range)
        {
            if (From > range.To || range.From > To)
            {
                return new Range[] { new Range(From, To) };
            }

            if (From < range.From && To > range.To)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (From >= range.From && To <= range.To)
            {
                return new Range[0];
            }

            if (From <= range.From && To <= range.To)
            {
                return new Range[] { new Range(From, range.From) };
            }

            return new Range[] { new Range(range.To, To) };
        }
    }
}
