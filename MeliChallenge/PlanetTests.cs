using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System;

namespace MeliChallenge
{
    [TestClass]
    public class PlanetTests
    {
        [TestMethod]
        public void ValidateDaysInYearPlanet()
        {
            Planet planeta = new Planet("Ferengi", 1, 500, new Coordinate(0,500));

            Assert.AreEqual(360, planeta.DaysTotalTranslation());
        }

        [TestMethod]
        public void ValidateMovement()
        {
            Planet planeta = new Planet("Ferengi", 1, 500, new Coordinate(0, 500));

            Assert.AreEqual(3*Math.PI/2, planeta.Movement(180));
        }

        [TestMethod]
        public void ValidatePositionInDays()
        {
            Planet planeta = new Planet("Ferengi", 1, 500, new Coordinate(0, 500));
            var coordenadas = planeta.GetPosition(180);
            Assert.AreEqual(0, Convert.ToInt32(coordenadas.X));
            Assert.AreEqual(-500, coordenadas.Y);
        }
    }
}
