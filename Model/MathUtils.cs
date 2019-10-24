namespace Domain
{
    public static class MathUtils
    {
        public static bool CoordinatesAligned(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            //https://stackoverflow.com/questions/3813681/checking-to-see-if-3-points-are-on-the-same-line
            //[Ax * (By - Cy) + Bx* (Cy - Ay) + Cx* (Ay - By) ] / 2

            var value = (coordinate1.X * (coordinate2.Y - coordinate3.Y) +
                    coordinate2.X * (coordinate3.Y - coordinate1.Y)
                     + coordinate3.X * (coordinate1.Y - coordinate2.Y));

            var tolerance = 200;

            return value < tolerance && value > -tolerance;
        }


        //Primer intento
        //https://www.geeksforgeeks.org/check-whether-a-given-point-lies-inside-a-triangle-or-not/
        //Segundo intento

        private static double Sign(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            return (coordinate1.X - coordinate3.X) * (coordinate2.Y - coordinate3.Y) - 
                (coordinate2.X - coordinate3.X) * (coordinate1.Y - coordinate3.Y);
        }

        public static bool PointInTriangle(Coordinate point, Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            double d1, d2, d3;
            bool has_neg, has_pos;

            d1 = Sign(point, coordinate1, coordinate2);
            d2 = Sign(point, coordinate2, coordinate3);
            d3 = Sign(point, coordinate3, coordinate1);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        public static double GetPerimeter(Coordinate coordinate1, Coordinate coordinate2, Coordinate coordinate3)
        {
            return coordinate1.DistanceTo(coordinate2) + coordinate2.DistanceTo(coordinate3) + coordinate3.DistanceTo(coordinate1);
        }
    }
}
