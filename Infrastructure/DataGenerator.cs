using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure

{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider services)
        {

            using (var context = new PredictionDBContext(services.GetRequiredService<DbContextOptions<PredictionDBContext>>()))
            {
                if (context.Weathers.Any())
                {
                    return;   
                }

                SolarSystem system = new SolarSystem(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordinate(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordinate(0,2000)),
                new Planet("Vulcano", -5, 1000, new Coordinate(0,1000)),
            });

                List<Weather> days = new List<Weather>();

                for (int i = 0; i < 365 * 10; i++)
                {
                    days.Add(system.GetWeatherByDay(i));
                }

                context.Weathers.AddRange(days);

                context.SaveChanges();
            }
        }
    }
}
