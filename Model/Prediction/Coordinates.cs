using System;

namespace Domain
{
    public class Coordinate
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Coordinate(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double DistanceTo(Coordinate coordinate)
        {
            return Math.Sqrt(Math.Pow(coordinate.X - this.X, 2) + Math.Pow(coordinate.Y - this.Y, 2));
        }
    }
}
