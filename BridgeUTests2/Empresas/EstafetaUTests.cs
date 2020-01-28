using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using State;

namespace Bridge.Tests
{
    [TestClass()]
    public class EstafetaUTests
    {
        [TestMethod()]
        public void TiempoTraslado_EnviarFechaDeEntregaMayorAHoy_ValorDiferenteDeCero()
        {
            //Arrange
            decimal iResultado = 0;
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas estafeta = new Estafeta(new List<lEnvios>() { barco }, 50, "Estafeta");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, estafeta, barco, dtHoy);
            //Act
            iResultado = estafeta.TiempoTraslado(entPedido);
            //Assert
            Assert.IsTrue(iResultado != 0);
        }

        [TestMethod()]
        public void FechaEntrega_EnviarTiempoTrasladoMayorACero_FechaDeEntregaDiferenteAFechaHoy()
        {
            //Arrange
            DateTime dtResultado = new DateTime();
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas estafeta = new Estafeta(new List<lEnvios>() { barco }, 50, "Estafeta");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, estafeta, barco, dtHoy);
            //Act
            dtResultado = estafeta.FechaEntrega(54, entPedido);
            //Assert
            Assert.AreNotEqual(dtResultado, dtHoy);
        }

        [TestMethod()]
        public void CostoEnvio_EviarDistanciaMayorACincuenta_CostoEnvioMayorACero()
        {
            //Arrange
            decimal dResultado = 0;
            decimal dEsperado = 3750;
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas estafeta = new Estafeta(new List<lEnvios>() { barco }, 50, "Estafeta");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, estafeta, barco, dtHoy);
            //Act
            dResultado = estafeta.CostoEnvio(entPedido);
            //Assert
            Assert.AreEqual(dEsperado, dResultado);
        }
    }
}