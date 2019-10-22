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
            return PointInTriangle(new Coordenadas(0,0), planeta1.GetPosicionActual,
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
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X- p3.X) * (p1.Y - p3.Y);
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

        static double area(double x1, double y1, double x2,
                      double y2, double x3, double y3)
        {
            return Math.Abs((x1 * (y2 - y3) +
                             x2 * (y3 - y1) +
                             x3 * (y1 - y2)) / 2.0);
        }

        /* A function to check whether point P(x, y) lies 
        inside the triangle formed by A(x1, y1), 
        B(x2, y2) and C(x3, y3) */
        static bool isInside(double x1, double y1, double x2,
                             double y2, double x3, double y3,
                             int x, int y)
        {
            /* Calculate area of triangle ABC */
            double A = area(x1, y1, x2, y2, x3, y3);

            /* Calculate area of triangle PBC */
            double A1 = area(x, y, x2, y2, x3, y3);

            /* Calculate area of triangle PAC */
            double A2 = area(x1, y1, x, y, x3, y3);

            /* Calculate area of triangle PAB */
            double A3 = area(x1, y1, x2, y2, x, y);

            /* Check if sum of A1, A2 and A3 is same as A */
            return (A == A1 + A2 + A3);
        }
    }
}
