using System;
using System.Collections.Generic;

namespace Model
{
    public class SistemaPlanetario
    {
        public List<Planet> Planetas { get; private set; }

        public SistemaPlanetario(List<Planet> planetas)
        {
            this.Planetas = planetas;
        }

        public Clima ConsultarClimaPorDia(int dias)
        {
            MoverADia(dias);
            Clima clima = new Clima();
            if (PeriodoSequia())
                clima.Tipo = TipoClima.SEQUIA;
            else if (PeriodoOptimos())
                clima.Tipo = TipoClima.OPTIMO;
            else if (Lluvia())
            {
                clima.Tipo = TipoClima.LLUVIA;
                clima.Perimetro = PerimetroTriangulo();
            }
            else
                clima.Tipo = TipoClima.DESCONOCIDO;

            return clima;
        }

        public void MoverADia(int dias)
        {
            this.Planetas.ForEach(x => x.Mover(dias));
        }

        public bool PeriodoSequia()
        {
            return PlanetasAlineadosConSol();
        }

        public bool PeriodoOptimos()
        {
            return PlanetasAlineados();
        }

        public bool Lluvia()
        {
            Planet planeta1 = Planetas[0];
            Planet planeta2 = Planetas[1];
            Planet planeta3 = Planetas[2];
            return PointInTriangle(new Coordenadas(0, 0), planeta1.GetPosicionActual,
                            planeta2.GetPosicionActual,
                            planeta3.GetPosicionActual);
        }

        public bool PlanetasAlineados()
        {
            //https://stackoverflow.com/questions/3813681/checking-to-see-if-3-points-are-on-the-same-line
            //[Ax * (By - Cy) + Bx* (Cy - Ay) + Cx* (Ay - By) ] / 2
            Planet planeta1 = Planetas[0];
            Planet planeta2 = Planetas[1];
            Planet planeta3 = Planetas[2];

            var alineacion = (planeta1.GetPosicionActual.X * (planeta2.GetPosicionActual.Y - planeta3.GetPosicionActual.Y) +
                planeta2.GetPosicionActual.X * (planeta3.GetPosicionActual.Y - planeta1.GetPosicionActual.Y)
                 + planeta3.GetPosicionActual.X * (planeta1.GetPosicionActual.Y - planeta2.GetPosicionActual.Y));

            return alineacion < 50 && alineacion > -50;
        }

        public bool PlanetasAlineadosConSol()
        {
            Planet planeta1 = Planetas[0];
            Planet planeta2 = Planetas[1];
            Coordenadas estrella = new Coordenadas(0, 0);

            if (!PlanetasAlineados())
                return false;

            var alineacion = (planeta1.GetPosicionActual.X * (planeta2.GetPosicionActual.Y - estrella.Y) +
                planeta2.GetPosicionActual.X * (estrella.Y - planeta1.GetPosicionActual.Y)
                 + estrella.X * (planeta1.GetPosicionActual.Y - planeta2.GetPosicionActual.Y));

            return alineacion < 200 && alineacion > -200;
        }


        //Primer intento
        //https://www.geeksforgeeks.org/check-whether-a-given-point-lies-inside-a-triangle-or-not/
        //Segundo intento

        private double Sign(Coordenadas p1, Coordenadas p2, Coordenadas p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private bool PointInTriangle(Coordenadas pt, Coordenadas v1, Coordenadas v2, Coordenadas v3)
        {
            double d1, d2, d3;
            bool has_neg, has_pos;

            d1 = Sign(pt, v1, v2);
            d2 = Sign(pt, v2, v3);
            d3 = Sign(pt, v3, v1);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        public Double PerimetroTriangulo()
        {
            Planet planeta1 = Planetas[0];
            Planet planeta2 = Planetas[1];
            Planet planeta3 = Planetas[2];

            Coordenadas v1 = planeta1.GetPosicionActual;
            Coordenadas v2 = planeta2.GetPosicionActual;
            Coordenadas v3 = planeta3.GetPosicionActual;

            return Distance(v1, v2) + Distance(v2, v3) + Distance(v3, v1);
        }


        public double Distance(Coordenadas coordenadas1, Coordenadas coordenadas2)
        {
            return Math.Sqrt(Math.Pow(coordenadas2.X - coordenadas1.X, 2) + Math.Pow(coordenadas2.Y - coordenadas1.Y, 2));
        }
    }
}
