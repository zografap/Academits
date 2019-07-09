
namespace Shape
{
    class Rectangle : Shape, IShape
    {
        public double WidthRectangle { get; set; }

        public double HeightRectangle { get; set; }

        public Rectangle(double widthRectangle, double heightRectangle)
        {
            this.WidthRectangle = widthRectangle;

            this.HeightRectangle = heightRectangle;
        }

        public override double GetWidth()
        {
            return WidthRectangle;
        }

        public override double GetHeight()
        {
            return HeightRectangle;
        }

        public override double GetArea()
        {
            return HeightRectangle * WidthRectangle;
        }

        public override double GetPerimeter()
        {
            return WidthRectangle * 2 + HeightRectangle * 2;
        }

        public override string ToString()
        {
            return "Имя фигуры: " + Name + "\n" +
                "Тип фигуры: Прямоугольник \n" +
                "Ширина = " + GetWidth() + "\n" +
                "Высота = " + GetHeight() + "\n" +
                "Площадь = " + GetArea() + "\n" +
                "Периметр = " + GetPerimeter();
        }
    }
}
