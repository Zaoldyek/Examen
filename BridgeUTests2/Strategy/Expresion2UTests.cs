﻿using Bridge;
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
    public class Expresion2Tests
    {
        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMayorAHoy_TextoNoEntregado()
        {
            //Arrange
            string cResultado = "";
            Expresion2 expresion2 = new Expresion2();
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new FEDEXSerice(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("27-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 5000, fedex, barco, dtHoy);
            //Act
            cResultado = expresion2.Ejecutar(dtEntrega, dtHoy, entPedido);
            //Assert
            Assert.AreEqual("llegará", cResultado);
        }


        [TestMethod()]
        public void Ejecutar_EnviarFechaEntregaMenorAHoy_TextoEntregado()
        {
            //Arrange
            string cResultado = "";
            Expresion2 expresion2 = new Expresion2();
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1 };
            lEmpresas fedex = new FEDEXSerice(new List<lEnvios>() { barco }, 50, "Fedex");
            DateTime dtHoy = Convert.ToDateTime("29-01-2020 12:00:00");
            DateTime dtEntrega = Convert.ToDateTime("28-01-2020 12:00:00");
            State.State entPedido = new State.State(new DesactivarState(), "México", "USA", 5000, fedex, barco, Convert.ToDateTime("27-01-2020 12:00:00"));
            //Act
            cResultado = expresion2.Ejecutar(dtEntrega, dtHoy, entPedido);
            //Assert
            Assert.AreEqual("llegó", cResultado);
        }
    }
}