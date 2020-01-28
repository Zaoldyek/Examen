using Bridge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Tests
{
    [TestClass()]
    public class ActivarStateTests
    {
        [TestMethod()]
        public void PedidoNoEntregado_EnviarStateDesactivado_EntPedidoAcrualizado()
        {
            //Arrange
            ActivarState activarState = new ActivarState();
            DesactivarState DesactivarPedido = new DesactivarState();
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new Estafeta(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State entPedido = new State(activarState, "México", "USA", 5000, fedex, barco, dtHoy);
            DesactivarPedido.setContext(entPedido);
            //Act
            DesactivarPedido.PedidoNoEntregado();
            //Assert
            Assert.AreNotEqual(entPedido.state, DesactivarPedido);
        }
    }
}