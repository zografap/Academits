namespace Range
{
    public class Range
    {
        public double From { get; set;}

        public double To { get; set; }

        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
        }

        public double GetLength()
        {
            return (To - From);
        }

        public bool IsInside(double x)
        {
            return (x >= From && x <= To);
        }

        public static bool IntersectionIntervals(Range interval1, Range interval2)
        {
            return (interval1.From <= interval2.To && interval1.To >= interval2.From);
        }

        public static double[] DifferenceIntervals(Range interval1, Range interval2)
        {
            double[] rezult = new double[4];
            if (IntersectionIntervals(interval1, interval2))
            {
                if (interval1.From == interval2.From && interval1.To == interval2.To)
                {
                    return null;
                }
                else if (interval1.From == interval2.From && interval1.To > interval2.To)
                {
                    rezult[0] = interval2.To;
                    rezult[1] = interval1.To;
                    return rezult;
                }
                else if (interval1.From == interval2.From && interval1.To < interval2.To)
                {
                    return null;
                }
                else if (interval1.From > interval2.From && interval1.To == interval2.To)
                {
                    return null;
                }
                else if (interval1.From < interval2.From && interval1.To == interval2.To)
                {
                    rezult[0] = interval1.From;
                    rezult[1] = interval2.From;
                    return rezult;
                }
                else if (interval1.From > interval2.From && interval1.To < interval2.To)
                {
                    return null;
                }
                else if (interval1.From < interval2.From && interval1.To > interval2.To)
                {
                    rezult[0] = interval1.From;
                    rezult[1] = interval2.From;
                    rezult[2] = interval2.To;
                    rezult[3] = interval1.To;
                    return rezult;
                }
                else if (interval1.From < interval2.From && interval1.To < interval2.To)
                {
                    rezult[0] = interval1.From;
                    rezult[1] = interval2.From;
                    rezult[2] = 0;
                    rezult[3] = 0;
                    return rezult;
                }
                else if (interval1.From > interval2.From && interval1.To > interval2.To)
                {
                    rezult[0] = interval1.From;
                    rezult[1] = interval2.From;
                    rezult[2] = 0;
                    rezult[3] = 0;
                    return rezult;
                }
            }
            return null;
        }
    }
}
