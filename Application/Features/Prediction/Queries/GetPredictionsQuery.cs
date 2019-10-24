using MediatR;
using System.Collections.Generic;

namespace Application.Features.Prediction.Queries
{
    public class GetPredictionsQuery : IRequest<IList<PredictionDTO>>
    {

    }
}
