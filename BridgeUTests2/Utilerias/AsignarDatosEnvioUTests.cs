using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bridge.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias.Tests
{
    [TestClass()]
    public class AsignarDatosEnvioUTests
    {
        [TestMethod()]
        public void AsignarEmpresa_EnviarListaDeEmpresasQueContengaEmpresaSolicitada_EmpresaSolicitadaAsignada()
        {
            //Arrange
            AsignarDatosEnvio asignarDatosEnvio = new AsignarDatosEnvio();
            lEnvios aereo = new Avion() { dVelocidadEntrega = 600, dCostoEnvio = 10, cNombre = "Avion" };
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1, cNombre = "Barco" };
            lEmpresas fedex = new FEDEXSerice(new List<lEnvios>() { barco }, 50, "Fedex");
            lEmpresas dhl = new DHL(new List<lEnvios>() { aereo, barco }, 40, "DHL");
            lEmpresas empresa = null;
            List<lEmpresas> lstEmpresas = new List<lEmpresas>() { fedex, dhl };
            //Act
            asignarDatosEnvio.AsignarEmpresa("Fedex", ref empresa, lstEmpresas);
            //Assert
            Assert.AreNotEqual(null,empresa);
        }

        [TestMethod()]
        public void AsignarEmpresa_EnviarListaDeEmpresasQueNoContengaEmpresaSolicitada_EmpresaSolicitadaNoAsignada()
        {
            //Arrange
            AsignarDatosEnvio asignarDatosEnvio = new AsignarDatosEnvio();
            lEnvios aereo = new Avion() { dVelocidadEntrega = 600, dCostoEnvio = 10, cNombre = "Avion" };
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1, cNombre = "Barco" };
            lEmpresas fedex = new FEDEXSerice(new List<lEnvios>() { barco }, 50, "Fedex");
            lEmpresas dhl = new DHL(new List<lEnvios>() { aereo, barco }, 40, "DHL");
            lEmpresas empresa = null;
            List<lEmpresas> lstEmpresas = new List<lEmpresas>() { fedex, dhl };
            //Act
            asignarDatosEnvio.AsignarEmpresa("Estafeta", ref empresa, lstEmpresas);
            //Assert
            Assert.AreEqual(null, empresa);
        }

        [TestMethod()]
        public void AsignarTransporte_EnviarListaDeTransporteQueContengaTransporteSolicitado_TransporteSolicitadoAsignado()
        {
            //Arrange
            AsignarDatosEnvio asignarDatosEnvio = new AsignarDatosEnvio();
            lEnvios aereo = new Avion() { dVelocidadEntrega = 600, dCostoEnvio = 10, cNombre = "Avion" };
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1, cNombre = "Barco" };
            List<lEnvios> lstEmpresas = new List<lEnvios>() { aereo, barco };
            lEnvios transporte = null;
            //Act
            asignarDatosEnvio.AsignarTransporte("Avion", ref transporte, lstEmpresas);
            //Assert
            Assert.AreNotEqual(null, transporte);
        }

    }
}