using System;

namespace Model
{
    public class Planet
    {
        public Planet(string nombre,
                      Double velocidadAngular,
                      Double distanciaAEstrella,
                      Tuple<double, double> coordenadasIniciales,
                      bool sentidoHorarioTraslacion)
        {
            //TODO validar parametros
            this.Nombre = nombre;
            this.VelocidadAngular = velocidadAngular;
            this.DistanciaAEstrella = distanciaAEstrella;
            this.SentidoHorarioTraslacion = sentidoHorarioTraslacion;
            this.CoordenadasIniciales = coordenadasIniciales;
            this.GetPosicionActual = coordenadasIniciales;
        }

        /// <summary>
        /// Velocidad angular en grados/dias 
        /// </summary>
        public Double VelocidadAngular { get; private set; }
        public Double DistanciaAEstrella { get; private set; }
        public string Nombre { get; private set; }
        public bool SentidoHorarioTraslacion { get; private set; }
        public Tuple<double, double> CoordenadasIniciales { get; private set; }

        private Double VelocidadAngularEnRadianes 
        {
            get { return VelocidadAngular * (Math.PI / 180); }
        }

        private Double PosicionInicialEnRadianes
        {
            //https://gist.github.com/joeyklee/e9f328e4c0c13a19eb1800caa97df9fb
            //TODO PosicionEstrella
            get { return Math.Atan2(CoordenadasIniciales.Item2 - 0, CoordenadasIniciales.Item1 - 0); }
        }


        public int CantidadDiasPeriodo()
        {
            return Convert.ToInt32(360 / VelocidadAngular);
        }

        public double DesplazamientoEnRadianes(int dias) 
        {
            double x, y;
            x = this.CoordenadasIniciales.Item1;
            y = this.CoordenadasIniciales.Item2;

            //Segun libro de física q(t) = q0 + w(t - t0)
            return PosicionInicialEnRadianes + (VelocidadAngularEnRadianes * dias);
        }

        public Tuple<double, double> GetPosicionActual { get; private set; }

        public Tuple<double, double> GetPosicionEnDias(int dias)
        {
            //(x = 0 + rcosθ, y = 0 + rsinθ) = (x = rcosθ, y = rsinθ)
            double posicionEnRadianes = DesplazamientoEnRadianes(dias);
            double posicionX = this.DistanciaAEstrella * Math.Cos(posicionEnRadianes);
            double posicionY = this.DistanciaAEstrella * Math.Sin(posicionEnRadianes);
            return new Tuple<double, double>(posicionX, posicionY);
        }

    }
}
