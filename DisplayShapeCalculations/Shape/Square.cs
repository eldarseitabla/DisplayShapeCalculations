namespace Shape
{
    public class Square : IShape
    {
        public double SideLength { get; set; }
        public double CalculateArea() => SideLength * SideLength;
    }
}
