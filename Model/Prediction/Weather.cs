using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Weather
    {
        [Key]
        public int Day { get; set; }
        public WeatherType Type { get; set; }
        public double? Perimeter { get; set; }
    }

    public enum WeatherType
    { 
        SEQUIA = 0,
        LLUVIA = 1,
        OPTIMO = 2,
        DESCONOCIDO = 3
    }
}
