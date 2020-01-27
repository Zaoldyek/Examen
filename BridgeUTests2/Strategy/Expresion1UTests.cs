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
    public class Expresion1Tests
    {
        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMayorAHoy_TextoNoEntregado()
        {
            //Arrange
            string cResultado = "";
            Expresion1 expresion1 = new Expresion1();
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new FEDEXSerice(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 5000, fedex, barco, dtHoy);
            //Act
            cResultado = expresion1.Ejecutar(dtEntrega, dtHoy, entPedido);
            //Assert
            Assert.AreEqual("ha salido", cResultado);
        }


        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMenorAHoy_TextoEntregado()
        {
            //Arrange
            string cResultado = "";
            Expresion1 expresion1 = new Expresion1();
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new FEDEXSerice(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("29-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 5000, fedex, barco, Convert.ToDateTime("27-01-2020 12:00:00"));
            //Act
            cResultado = expresion1.Ejecutar(dtEntrega, dtHoy, entPedido);
            //Assert
            Assert.AreEqual("salió", cResultado);
        }
    }
}