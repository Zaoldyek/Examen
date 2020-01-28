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
        public void setContextTest()
        {
            ActivarState activarState = new ActivarState();
            State entPedido = new State(initialState, cInformacion[0], cInformacion[1], convertirTipoDato.ConvertirStringADecimal(cInformacion[2]), empresa, transporte, Convert.ToDateTime(cInformacion[5]));

            activarState.setContext(State);
        }

        [TestMethod()]
        public void PedidoEntregadoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PedidoNoEntregadoTest()
        {
            Assert.Fail();
        }
    }
}