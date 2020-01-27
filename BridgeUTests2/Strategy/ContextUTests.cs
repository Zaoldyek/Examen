using Bridge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State;
using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Tests
{
    [TestClass()]
    public class ContextTests
    {
        [TestMethod()]
        public void setStrategy_EnviarEstrategia_ContextoDiferenteDeNull()
        {
            //Arrange
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new FEDEXSerice(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            //Act
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 5000, fedex, barco, dtHoy);
            //Assert
            Assert.IsNotNull(entPedido);
        }
    }
}