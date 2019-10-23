using MediatR;

namespace Application.Features.Prediccion.Queries
{
    public class GetPrediccionByDiaQuery : IRequest<ClimaDTO>
    {
        public int Dia { get; private set; }

        public GetPrediccionByDiaQuery(int dia)
        {
            this.Dia = dia;
        }
    }
}
