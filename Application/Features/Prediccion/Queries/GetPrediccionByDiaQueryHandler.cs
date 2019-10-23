using Domain.Prediccion.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Prediccion.Queries
{
    public class GetPrediccionByDiaQueryHandler : IRequestHandler<GetPrediccionByDiaQuery, ClimaDTO>
    {
        private readonly IPrediccionRepository PrediccionRepository;
        public GetPrediccionByDiaQueryHandler(IPrediccionRepository prediccionRepository)
        {
            this.PrediccionRepository = prediccionRepository;
        }

        public async Task<ClimaDTO> Handle(GetPrediccionByDiaQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(ClimaDTO.FromDomain(PrediccionRepository.GetByDia(request.Dia)));
        }
    }

    public class ClimaDTO
    {
        public ClimaDTO(int dia, string clima)
        {
            this.Dia = dia;
            this.Clima = clima;
        }
        public int Dia { get; set; }
        public string Clima { get; set; }


        public static ClimaDTO FromDomain(Model.Clima clima)
        {
            return new ClimaDTO(clima.Dia, clima.Tipo.ToString());
        }
    }
}
