using MediatR;
using System.Collections.Generic;

namespace Application.Features.Prediccion.Queries
{
    public class GetPrediccionesQuery : IRequest<IList<PeriodoDTO>>
    {

    }
}
