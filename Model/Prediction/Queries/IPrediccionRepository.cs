using Domain;
using System.Collections.Generic;

namespace Domain.Prediction.Queries
{
    public interface IPredictionRepository
    {
        Weather GetWeatherByDay(int day);
        List<IPrediction> GetPredictions();
    }
}
