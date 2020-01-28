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
    public class DHLUTests
    {
        [TestMethod()]
        public void TiempoTraslado_EnviarFechaDeEntregaMayorAHoy_ValorDiferenteDeCero()
        {
            //Arrange
            decimal iResultado = 0;
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas dhl = new DHL(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, dhl, barco, dtHoy);
            //Act
            iResultado = dhl.TiempoTraslado(entPedido);
            //Assert
            Assert.IsTrue(iResultado != 0);
        }
        [TestMethod()]
        public void TiempoTraslado_EnviarListaTransportesVacia_TiempoTrasladoCero()
        {
            //Arrange
            decimal iResultado = 0;
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas dhl = new DHL(new List<lEnvios>() { }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, dhl, barco, dtHoy);
            //Act
            iResultado = dhl.TiempoTraslado(entPedido);
            //Assert
            Assert.IsTrue(iResultado == 0);
        }

        [TestMethod()]
        public void FechaEntrega_EnviarTiempoTrasladoMayorACero_FechaDeEntregaMayorFechaHoy()
        {
            //Arrange
            DateTime dtResultado = new DateTime();
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas dhl = new DHL(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, dhl, barco, dtHoy);
            //Act
            dtResultado = dhl.FechaEntrega(54,entPedido);
            //Assert
            Assert.IsTrue(dtResultado > dtHoy);
        }
        [TestMethod()]
        public void FechaEntrega_EnviarTiempoTrasladoMayorACero_FechaDeEntregaMenorAFechaHoy()
        {
            //Arrange
            DateTime dtResultado = new DateTime();
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas dhl = new DHL(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, dhl, barco, dtHoy);
            //Act
            dtResultado = dhl.FechaEntrega(-10, entPedido);
            //Assert
            Assert.IsTrue(dtResultado < dtHoy);
        }

        [TestMethod()]
        public void CostoEnvio_EviarDistanciaMayorACincuenta_CostoEnvioMayorACero()
        {
            //Arrange
            decimal dResultado = 0;
            decimal dEsperado = 3750;
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas dhl = new DHL(new List<lEnvios>() { barco }, 50, "DHL");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, dhl, barco, dtHoy);
            //Act
            dResultado = dhl.CostoEnvio(entPedido);
            //Assert
            Assert.AreEqual(dEsperado, dResultado);
        }
    }
}