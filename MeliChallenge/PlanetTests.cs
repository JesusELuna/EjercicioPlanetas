using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;

namespace MeliChallenge
{
    [TestClass]
    public class PlanetTests
    {
        [TestMethod]
        public void ValidarPlanetaCantidadDiasPeriodo()
        {
            Planet planeta = new Planet("Ferengi", 1, 500, new System.Tuple<double, double>(0,500), true);

            Assert.AreEqual(360, planeta.CantidadDiasPeriodo());
        }

        [TestMethod]
        public void ValidarPlanetaDesplazamientoEnRadianes()
        {
            Planet planeta = new Planet("Ferengi", 1, 500, new System.Tuple<double, double>(0, 500), true);

            Assert.AreEqual(3*Math.PI/2, planeta.DesplazamientoEnRadianes(180));
        }

        [TestMethod]
        public void ValidarPlanetaDesplazamientoEnCoordenadas()
        {
            Planet planeta = new Planet("Ferengi", 1, 500, new System.Tuple<double, double>(0, 500), true);
            var coordenadas = planeta.GetPosicionEnDias(180);
            Assert.AreEqual(0, Convert.ToInt32(coordenadas.Item1));
            Assert.AreEqual(-500, coordenadas.Item2);
        }
    }
}
