namespace Shape
{
    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double CalculateArea() => Length * Width;
    }
}
