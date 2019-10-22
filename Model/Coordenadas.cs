namespace Model
{
    public class Coordenadas
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Coordenadas(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
