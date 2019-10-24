using Domain.Prediction.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Prediction.Queries
{
    public class GetPredictionByDayQueryHandler : IRequestHandler<GetPredictionByDayQuery, WeatherDTO>
    {
        private readonly IPredictionRepository PredictionRepository;
        public GetPredictionByDayQueryHandler(IPredictionRepository predictionRepository)
        {
            this.PredictionRepository = predictionRepository;
        }

        public async Task<WeatherDTO> Handle(GetPredictionByDayQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(WeatherDTO.FromDomain(PredictionRepository.GetWeatherByDay(request.Day)));
        }
    }

    public class WeatherDTO
    {
        public WeatherDTO(int day, string weather)
        {
            this.Day = day;
            this.Weather = weather;
        }
        public int Day { get; set; }
        public string Weather { get; set; }


        public static WeatherDTO FromDomain(Domain.Weather clima)
        {
            return new WeatherDTO(clima.Day, clima.Type.ToString());
        }
    }
}
