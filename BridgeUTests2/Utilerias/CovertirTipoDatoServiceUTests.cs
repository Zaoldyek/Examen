using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bridge.Utilerias.Tests
{
    [TestClass()]
    public class CovertirTipoDatoServiceTests
    {
        [TestMethod()]
        public void ConvertirDecimalADoubleTest_EnviarDatoDecimal_DevuelveValorDouble()
        {
            //Arrange
            decimal dValorDecimal = 11;
            var dValorDouble = 0.0;
            CovertirTipoDatoService convertirTipoDatoService = new CovertirTipoDatoService();
            //Act
            dValorDouble = convertirTipoDatoService.ConvertirDecimalADouble(dValorDecimal);
            //Assert
            Assert.IsTrue(dValorDouble.GetType() == typeof(double));
        }

        [TestMethod()]
        public void ConvertirStringADecimal_EnviarDatoString_DevuelveValorDecimal()
        {
            //Arrange
            string dValorString = "11";
            decimal dValorDecimal = 0;
            CovertirTipoDatoService convertirTipoDatoService = new CovertirTipoDatoService();
            //Act
            dValorDecimal = convertirTipoDatoService.ConvertirStringADecimal(dValorString);
            //Assert
            Assert.IsTrue(dValorDecimal.GetType() == typeof(decimal));
        }
    }
}