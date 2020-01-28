using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bridge.Tests
{
    [TestClass()]
    public class LeerArchivoTextoUTests
    {
        [TestMethod()]
        public void LeerArchivo_EnviarUrlExistente_ArregloConRegistros()
        {
            //Arrange
            LeerArchivoTexto Lector = new LeerArchivoTexto();
            List<string> lstRegistros= new List<string>();
            //Act
            lstRegistros = Lector.LeerArchivo("../../../Bridge/bin/Debug/Pedidos.txt");
            //Assert
            Assert.IsTrue(lstRegistros.Any());
        }
        
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LeerArchivo_EnviarUrlIncorrecto_ExceptioFileNotExist()
        {
            //Arrange
            LeerArchivoTexto Lector = new LeerArchivoTexto();
            List<string> lstRegistros = new List<string>();
            //Act
            Lector.lectorArchivo = e => throw new FileNotFoundException();
            //Assert
            lstRegistros = Lector.LeerArchivo("Pedidos.txt");
        }
    }
}