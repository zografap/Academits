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
    }
}
