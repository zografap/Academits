namespace Range
{
    public class Range
    {
        public double from
        {
            get; set;
        }
        public double to
        {
            get; set;
        }

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public double GetLength()
        {
            return (to - from);
        }

        public bool IsInside(double x)
        {
            return (x >= from && x <= to);
        }
    }
}
