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
    public class BuscarMejorOpcionUTests
    {
        [TestMethod()]
        public void ObtenerMejorOpcion_EnviarCostoDeEnvioAlto_MensajeConDiferenciaDePrecio()
        {
            //Arrange
            string cResultado = "";
            lEnvios aereo = new Avion() { dVelocidadEntrega = 600, dCostoEnvio = 10, cNombre = "Avion" };
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1, cNombre = "Barco" };
            lEmpresas fedex = new Estafeta(new List<lEnvios>() { barco }, 50, "Fedex");
            lEmpresas dhl = new DHL(new List<lEnvios>() { aereo, barco }, 40, "DHL");
            List<lEmpresas> lstEmpresas = new List<lEmpresas>() { fedex, dhl };
            BuscarMejorOpcion buscarMejorOpcion = new BuscarMejorOpcion();
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 2500, fedex, barco, dtHoy);
            //Act
            cResultado = buscarMejorOpcion.ObtenerMejorOpcion(lstEmpresas, dhl, entPedido,5000);
            //Assert
            Assert.AreEqual("Si hubieras pedido en Fedex te hubiera costado 1250.0 mas barato",cResultado);
        }
    }
}