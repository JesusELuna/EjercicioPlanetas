using Domain.Prediccion.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Prediccion.Queries
{
    public class GetPrediccionesQueryHandler : IRequestHandler<GetPrediccionesQuery, IList<PeriodoDTO>>
    {
        private readonly IPrediccionRepository PrediccionRepository;
        public GetPrediccionesQueryHandler(IPrediccionRepository prediccionRepository)
        {
            this.PrediccionRepository = prediccionRepository;
        }

        public async Task<ClimaDTO> Handle(GetPrediccionByDiaQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(ClimaDTO.FromDomain(PrediccionRepository.GetByDia(request.Dia)));
        }

        public async Task<IList<PeriodoDTO>> Handle(GetPrediccionesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(PrediccionRepository.GetPeriodos().Select(x => PeriodoDTO.FromDomain(x)).ToList());
        }
    }

    public class PeriodoDTO 
    {
        public string Clima { get; set; }
        public int Cantidad { get; set; }
       public List<int> DiasPicoMaximoLluvia { get; set; }

        public PeriodoDTO(int Cantidad, string clima, List<int> diasPico)
        {
            this.Cantidad = Cantidad;
            this.Clima = clima;
            this.DiasPicoMaximoLluvia = diasPico;
        }

        public static PeriodoDTO FromDomain(Domain.Periodo periodo)
        {
            return new PeriodoDTO(periodo.CantidadDias, periodo.Tipo.ToString(), periodo.DiasPicoMaximoLluvia);
        }
    }
}
