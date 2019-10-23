using Model;
using System.Collections.Generic;

namespace Domain
{
    public class Periodo
    {
        public int CantidadDias { get; set; }
        public TipoClima Tipo { get; set; }
        public List<int> DiasPicoMaximoLluvia { get; set; }
    }
}
