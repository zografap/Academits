using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public abstract class Shape
    {
        private double Width { get; set; }

        private double Height { get; set; }

        double Area { get; set; }

        public abstract double GetWidth();

        public abstract double GetHeight();

        public abstract double GetArea();
    }
}
