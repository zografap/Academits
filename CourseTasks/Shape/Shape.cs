using System;

namespace Shape
{
    public abstract class Shape
    {
        public string Name { get; set; }

        private double Width { get; set; }

        private double Height { get; set; }

        private double Area { get; set; }

        private double Perimeter { get; set; }

        public abstract double GetWidth();

        public abstract double GetHeight();

        public abstract double GetArea();        public abstract double GetPerimeter();        public static Shape FindMaximumArea(Shape[] shapes)
        {
            Array.Sort(shapes, new ShapeComparer());
            return shapes[shapes.Length - 1];
        }        public static Shape FindMaximumPerimeter(Shape[] shapes)
        {
            Array.Sort(shapes, new ComparePerimetr());
            return shapes[shapes.Length - 1];
        }        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this)) return true;

            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
                return false;

            Shape p = (Shape)o;

            return Width == p.Width && Height == p.Height && Area == p.Area &&
               Perimeter == p.Perimeter;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Height.GetHashCode();
            hash = prime * hash + Area.GetHashCode();
            hash = prime * hash + Perimeter.GetHashCode();
            return hash;
        }
    }
}
