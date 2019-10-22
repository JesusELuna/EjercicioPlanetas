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
                new Planet("Ferengi", 1, 500, new System.Tuple<double, double>(0,500), true),
                new Planet("Betasoide", 3, 2000, new System.Tuple<double, double>(0,2000), true),
                new Planet("Vulcano", 5, 1000, new System.Tuple<double, double>(0,1000), true),
            });

            Assert.AreEqual(true, sistema.PlanetasAlineados());
        }

        [TestMethod]
        public void ValidarPlanetaDesplazamientoEnRadianesd()
        {

            SistemaPlanetario sistema = new SistemaPlanetario(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new System.Tuple<double, double>(0,500), true),
                new Planet("Betasoide", 3, 2000, new System.Tuple<double, double>(0,2000), true),
                new Planet("Vulcano", 5, 1000, new System.Tuple<double, double>(5,2), true),
            });

            Assert.AreEqual(false, sistema.PlanetasAlineados());
        }
    }
}
