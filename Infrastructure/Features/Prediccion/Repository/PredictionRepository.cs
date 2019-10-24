using Domain.Prediction;
using Domain.Prediction.Queries;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Features.Prediccion.Repository
{
    public class PredictionRepository : IPredictionRepository
    {
        private readonly PredictionDBContext DbContext;
        public PredictionRepository(PredictionDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public Weather GetWeatherByDay(int dia)
        {
            return DbContext.Weathers.FirstOrDefault(x => x.Day == dia);
        }

        public List<IPrediction> GetPredictions() 
        {
            List<IPrediction> predictions = new List<IPrediction>();
            foreach (WeatherType type in (WeatherType[])Enum.GetValues(typeof(WeatherType)))
            {
                IQueryable<Weather> daysWithSameWeather = DbContext.Weathers.Where(x => x.Type == type);
                var days = daysWithSameWeather.Count(x => x.Type == type);
                
                if (type == WeatherType.LLUVIA)
                {
                    double? greaterPerimeter = daysWithSameWeather.Max(x => x.Perimeter);
                    var daysWithHeavyRain = daysWithSameWeather.Where(x => x.Perimeter == greaterPerimeter.Value).Select(x => x.Day).ToList();
                    predictions.Add(new RainPrediction(days,type, daysWithHeavyRain));
                }
                else
                {
                    predictions.Add(new Prediction(days, type));
                }
            }
            return predictions;
        }
    }
}
