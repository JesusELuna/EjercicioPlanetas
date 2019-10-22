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

        public void PredecirClima(int dias)
        {
           
        }

        public bool PlanetasAlineados()
        {
            //https://stackoverflow.com/questions/3813681/checking-to-see-if-3-points-are-on-the-same-line
            //[Ax * (By - Cy) + Bx* (Cy - Ay) + Cx* (Ay - By) ] / 2
            Planet planeta1 = Planetas[0];
            Planet planeta2 = Planetas[1];
            Planet planeta3 = Planetas[2];

            return (planeta1.GetPosicionActual.Item1 * (planeta2.GetPosicionActual.Item2 - planeta3.GetPosicionActual.Item2) +
                planeta2.GetPosicionActual.Item1 * (planeta3.GetPosicionActual.Item2 - planeta1.GetPosicionActual.Item2)
                 + planeta3.GetPosicionActual.Item1 * (planeta1.GetPosicionActual.Item2 - planeta2.GetPosicionActual.Item2) ) / 2 == 0;
        }
    }
}
