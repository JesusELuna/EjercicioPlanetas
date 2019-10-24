using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class SolarSystemTests
    {
        [TestMethod]
        public void ValidateAlignedPlanetsTrue()
        {
            SolarSystem sistema = new SolarSystem(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordinate(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordinate(0,2000)),
                new Planet("Vulcano", 5, 1000, new Coordinate(0,1000)),
            });

            Assert.AreEqual(true, sistema.AlignedPlanets());
        }

        [TestMethod]
        public void ValidateAlignedPlanetsFalse()
        {

            SolarSystem sistema = new SolarSystem(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordinate(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordinate(0,2000)),
                new Planet("Vulcano", 5, 1000, new Coordinate(5,2))
            });

            Assert.AreEqual(false, sistema.AlignedPlanets());
        }

        [TestMethod]
        public void ValidateMovementPlanets()
        {
            SolarSystem system = new SolarSystem(new List<Planet>() {
                new Planet("Ferengi", 1, 500, new Coordinate(0,500)),
                new Planet("Betasoide", 3, 2000, new Coordinate(0,2000)),
                new Planet("Vulcano", -5, 1000, new Coordinate(0,1000)),
            });

            var position = system.Planets[0].GetCurrentPosition;

            system.Move(180);

            Assert.AreNotEqual(position, system.Planets[0].GetCurrentPosition);
        }
    }
}
