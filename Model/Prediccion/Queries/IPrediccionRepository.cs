using Model;
using System.Collections.Generic;

namespace Domain.Prediccion.Queries
{
    public interface IPrediccionRepository
    {
        Clima GetByDia(int dia);
        List<Periodo> GetPeriodos();
    }
}
