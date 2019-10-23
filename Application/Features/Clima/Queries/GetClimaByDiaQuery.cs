using MediatR;

namespace Application.Features.Clima.Queries
{
    public class GetClimaByDiaQuery : IRequest<ClimaDTO>
    {
        public int Dia { get; private set; }

        public GetClimaByDiaQuery(int dia)
        {
            this.Dia = dia;
        }
    }
}
