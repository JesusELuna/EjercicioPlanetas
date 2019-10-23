using Domain;
using Domain.Prediccion.Queries;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Features.Prediccion.Repository
{
    public class PrediccionRepository : IPrediccionRepository
    {
        private readonly PrediccionDBContext DbContext;
        public PrediccionRepository(PrediccionDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public Clima GetByDia(int dia)
        {
            return DbContext.Climas.FirstOrDefault(x => x.Dia == dia);
        }

        public List<Periodo> GetPeriodos()
        {
            List<Periodo> periodos = new List<Periodo>();
            foreach (TipoClima tipo in (TipoClima[])Enum.GetValues(typeof(TipoClima)))
            {
                Periodo periodo = new Periodo();
                IQueryable<Clima> mismoClima = DbContext.Climas.Where(x => x.Tipo == tipo);
                periodo.CantidadDias = mismoClima.Count(x => x.Tipo == tipo);
                periodo.Tipo = tipo;
                if (tipo == TipoClima.LLUVIA)
                {
                    double? maximoPerimetro = mismoClima.Max(x => x.Perimetro);
                    periodo.DiasPicoMaximoLluvia = mismoClima.Where(x => x.Perimetro == maximoPerimetro.Value).Select(x => x.Dia).ToList();
                }
                periodos.Add(periodo);
            }
            return periodos;
        }
    }
}
