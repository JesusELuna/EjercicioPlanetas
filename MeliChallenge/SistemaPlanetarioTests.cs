using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class SistemaPlanetarioTests
    {
        [TestMethod]
        public void ValidarPlanetaDesplazamientoEnRadianes()
        {

            SistemaPlanetario sistema = new SistemaPlanetario(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordenadas(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordenadas(0,2000)),
                new Planet("Vulcano", 5, 1000, new Coordenadas(0,1000)),
            });

            Assert.AreEqual(true, sistema.PlanetasAlineados());
        }

        [TestMethod]
        public void ValidarPlanetaDesplazamientoEnRadianesd()
        {

            SistemaPlanetario sistema = new SistemaPlanetario(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordenadas(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordenadas(0,2000)),
                new Planet("Vulcano", 5, 1000, new Coordenadas(5,2))
            });

            Assert.AreEqual(false, sistema.PlanetasAlineados());
        }

        [TestMethod]
        public void ValidarMoverPlanetas()
        {
            SistemaPlanetario sistema = new SistemaPlanetario(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordenadas(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordenadas(0,2000)),
                new Planet("Vulcano", -5, 1000, new Coordenadas(0,1000)),
            });

            sistema.MoverADia(180);
        }



        [TestMethod]
        public void PruebaChallenge()
        {
            SistemaPlanetario sistema = new SistemaPlanetario(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordenadas(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordenadas(0,2000)),
                new Planet("Vulcano", -5, 1000, new Coordenadas(0,1000)),
            });

            var dias = 360;
            int cantidadSequias = 0;
            int cantidadOptimos = 0;
            int cantidadLluvia = 0;
            int unknown = 0;
            for (int i = 0; i < dias; i++)
            {
                sistema.MoverADia(i);
                if (sistema.PeriodoSequia())
                    cantidadSequias++;
                else if (sistema.PeriodoOptimos())
                    cantidadOptimos++;
                else if (sistema.Lluvia())
                    cantidadLluvia++;
                else
                    unknown++;
            }
        }
    }
}
