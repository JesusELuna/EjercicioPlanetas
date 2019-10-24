using System.Collections.Generic;

namespace Domain
{
    public class SolarSystem
    {
        public List<Planet> Planets { get; private set; }

        public SolarSystem(List<Planet> planets)
        {
            this.Planets = planets;
        }

        public Weather GetWeatherByDay(int day)
        {
            Move(day);
            Weather weather = new Weather();
            if (Drought())
                weather.Type = WeatherType.SEQUIA;
            else if (Optimum())
                weather.Type = WeatherType.OPTIMO;
            else if (Rain())
            {
                weather.Type = WeatherType.LLUVIA;
                weather.Perimeter = MathUtils.GetPerimeter(Planets[0].GetCurrentPosition, Planets[1].GetCurrentPosition, Planets[2].GetCurrentPosition);
            }
            else
                weather.Type = WeatherType.DESCONOCIDO;

            return weather;
        }

        public void Move(int days)
        {
            this.Planets.ForEach(x => x.Move(days));
        }

        public bool Drought()
        {
            return AlignedPlanetsWithStar();
        }

        public bool Optimum()
        {
            return AlignedPlanets();
        }

        public bool Rain()
        {
            return MathUtils.PointInTriangle(new Coordinate(0, 0), Planets[0].GetCurrentPosition,
                                                                    Planets[1].GetCurrentPosition,
                                                                    Planets[2].GetCurrentPosition);
        }

        public bool AlignedPlanets()
        {
            return MathUtils.CoordinatesAligned(Planets[0].GetCurrentPosition, Planets[1].GetCurrentPosition, Planets[2].GetCurrentPosition);
        }

        public bool AlignedPlanetsWithStar()
        {
            Coordinate star = new Coordinate(0, 0);

            if (!AlignedPlanets())
                return false;

            return MathUtils.CoordinatesAligned(Planets[0].GetCurrentPosition, Planets[1].GetCurrentPosition, star);
        }
    }
}
