using Domain;
using System.Collections.Generic;

namespace Domain.Prediction
{
    public class Prediction : IPrediction
    {
        public Prediction(int days, WeatherType type)
        {
            Days = days;
            Type = type;
        }
        public int Days { get; set; }
        public WeatherType Type { get; set; }

    }

    public class RainPrediction : Prediction, IPrediction
    {
        public RainPrediction(int days, WeatherType type, List<int> daysWithHeavyRain) : base(days,type)
        {
            DaysWithHeavyRain = daysWithHeavyRain;
        }

        public List<int> DaysWithHeavyRain { get; set; }
    }

    public interface IPrediction
    {
        int Days { get; set; }
        WeatherType Type { get; set; }
    }
}
