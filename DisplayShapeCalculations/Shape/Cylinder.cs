using System;

namespace Shape
{
    public class Cylinder : IShape, IShapeWithVolume
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        public double CalculateArea() => 2 * Math.PI * Radius * (Radius + Height);
        public double CalculateVolume() => Math.PI * Radius * Radius * Height;
    }
}
