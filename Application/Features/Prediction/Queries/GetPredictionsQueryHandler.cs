using Domain.Prediction;
using Domain.Prediction.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Prediction.Queries
{
    public class GetPredictionsQueryHandler : IRequestHandler<GetPredictionsQuery, IList<PredictionDTO>>
    {
        private readonly IPredictionRepository PredictionRepository;
        public GetPredictionsQueryHandler(IPredictionRepository predictionRepository)
        {
            this.PredictionRepository = predictionRepository;
        }

        public async Task<IList<PredictionDTO>> Handle(GetPredictionsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(PredictionRepository.GetPredictions().Select(x => PredictionDTO.FromDomain(x)).ToList());
        }
    }

    public class PredictionDTO 
    {
        public int Days { get; set; }
        public string Weather { get; set; }
        

        public PredictionDTO(int days, string weather)
        {
            this.Days = days;
            this.Weather = weather;
        }

        public class RainPredictionDTO : PredictionDTO
        {
            public RainPredictionDTO(int days, string weather,List<int> daysWithHeavyRain) : base(days,weather)
            {
                DaysWithHeavyRain = daysWithHeavyRain;
            }

            public List<int> DaysWithHeavyRain { get; set; }
        }


        public static PredictionDTO FromDomain(IPrediction prediction)
        {
            if (prediction is Domain.Prediction.RainPrediction)
            {
                var rainPrediction = (RainPrediction)prediction;
                return new RainPredictionDTO(prediction.Days, prediction.Type.ToString(), rainPrediction.DaysWithHeavyRain);
            }
            else
                return new PredictionDTO(prediction.Days, prediction.Type.ToString());
        }
    }
}
