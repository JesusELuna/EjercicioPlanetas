using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure

{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider services)
        {

            using (var context = new PrediccionDBContext(services.GetRequiredService<DbContextOptions<PrediccionDBContext>>()))
            {
                if (context.Climas.Any())
                {
                    return;   
                }

                SistemaPlanetario sistema = new SistemaPlanetario(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordenadas(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordenadas(0,2000)),
                new Planet("Vulcano", -5, 1000, new Coordenadas(0,1000)),
            });

                List<Clima> climas = new List<Clima>();

                for (int i = 0; i < 360 * 10; i++)
                {
                    climas.Add(sistema.ConsultarClimaPorDia(i));
                }

                context.Climas.AddRange(climas);

                context.SaveChanges();
            }
        }
    }
}
