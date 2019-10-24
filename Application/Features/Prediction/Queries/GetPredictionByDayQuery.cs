using MediatR;

namespace Application.Features.Prediction.Queries
{
    public class GetPredictionByDayQuery : IRequest<WeatherDTO>
    {
        public int Day { get; private set; }

        public GetPredictionByDayQuery(int day)
        {
            this.Day = day;
        }
    }
}
