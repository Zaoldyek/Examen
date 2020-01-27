using Bridge.Empresas;
using Bridge.Envios;
using Bridge.Interfaces;
using Bridge.Utilerias;
using State;
using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            lBuscarMejorOpcion buscarMejorOpcion = new BuscarMejorOpcion();
            lAsignarDatosEnvio lasignarDatosEnvio = new AsignarDatosEnvio();
            Context context = new Context();
            lConvertirTipoDato convertirTipoDato = new CovertirTipoDatoService();
            double dTiempoTraslado = 0;
            decimal TiempoTraslado = 0;
            decimal dCostoEnvio = 0;
            string cExpresion1 = "";
            string cExpresion2 = "";
            string cExpresion3 = "";
            string cExpresion4 = "";
            string cExpresion5 = "";
            DateTime dtFechaEntrega = new DateTime();
            DateTime dtHoy = DateTime.Now;
            lLeerArchivoTexto Lector = new LeerArchivoTexto();
            lEmpresas empresa = null;
            lEnvios transporte = null;
            lEnvios aereo = new Avion() { dVelocidadEntrega = 600, dCostoEnvio = 10,cNombre="Avion" };
            lEnvios tren = new Tren() { dVelocidadEntrega = 80, dCostoEnvio = 5, cNombre = "Tren" };
            lEnvios barco = new Barco() { dVelocidadEntrega = 46, dCostoEnvio = 1, cNombre = "Barco" };
            lEnvios bici = new Bici() { dVelocidadEntrega = 1, dCostoEnvio = 3, cNombre = "Bici" };
            lEmpresas fedex = new FEDEXSerice(new List<lEnvios>() { barco }, 50, "Fedex");
            lEmpresas dhl = new DHL(new List<lEnvios>() { aereo, barco }, 40, "DHL");
            lEmpresas estafeta = new Estafeta(new List<lEnvios>() { tren }, 20, "Estafeta");
            lEmpresas upc = new UPC(new List<lEnvios>() { bici }, 50, "UPC");
            List<lEmpresas> lstEmpresas = new List<lEmpresas>() { fedex, dhl, estafeta,upc };
            List<lEnvios> lstTransportes = new List<lEnvios>() { aereo, tren, barco,bici };

            List<string> lines = Lector.LeerArchivo("Pedidos.txt");

            foreach (string line in lines)
            {
                string[] cInformacion = line.Split(',');

                lasignarDatosEnvio.AsignarEmpresa(cInformacion[3], ref empresa, lstEmpresas);

                lasignarDatosEnvio.AsignarTransporte(cInformacion[4], ref transporte, lstTransportes);

                if (empresa != null)
                {
                    Pedido initialState = new DesactivarState();
                    State.State entPedido = new State.State(initialState, cInformacion[0], cInformacion[1], convertirTipoDato.ConvertirStringADecimal(cInformacion[2]), empresa, transporte, Convert.ToDateTime(cInformacion[5]));
                    initialState.setContext(entPedido);

                    TiempoTraslado = empresa.TiempoTraslado(entPedido);

                    if (TiempoTraslado > 0)
                    {
                        dTiempoTraslado = convertirTipoDato.ConvertirDecimalADouble(TiempoTraslado);
                        dtFechaEntrega = empresa.FechaEntrega(dTiempoTraslado, entPedido);
                        dCostoEnvio = empresa.CostoEnvio(entPedido);

                        Console.WriteLine(buscarMejorOpcion.ObtenerMejorOpcion(lstEmpresas, empresa, entPedido, dCostoEnvio));

                        Expresion1 expresion1 = new Expresion1();
                        context.setStrategy(expresion1);
                        cExpresion1 = context.ValidarFechaEntrega(dtFechaEntrega, dtHoy, entPedido);

                        Expresion2 expresion2 = new Expresion2();
                        context.setStrategy(expresion2);
                        cExpresion2 = context.ValidarFechaEntrega(dtFechaEntrega, dtHoy, entPedido);

                        Expresion3 expresion3 = new Expresion3();
                        context.setStrategy(expresion3);
                        cExpresion3 = context.ValidarFechaEntrega(dtFechaEntrega, dtHoy, entPedido);

                        Expresion4 expresion4 = new Expresion4();
                        context.setStrategy(expresion4);
                        cExpresion4 = context.ValidarFechaEntrega(dtFechaEntrega, dtHoy, entPedido);

                        Expresion5 expresion5 = new Expresion5();
                        context.setStrategy(expresion5);
                        cExpresion5 = context.ValidarFechaEntrega(dtFechaEntrega, dtHoy, entPedido);


                        if (entPedido.state.ToString() == "State.ActivarState")
                        {
                            System.Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            System.Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.WriteLine($"Tu paquete {cExpresion1} de {entPedido.cOrigen} y {cExpresion2} a {entPedido.cDestino} {cExpresion3} {cExpresion5} y {cExpresion4} un costo de {dCostoEnvio} (Cualquier reclamación con {cInformacion[3]}).");

                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

}

//Agregar nueva empresa de paqueteria
//1.- Agregar clase en la carpeta empresa con el nombre de la empresa y que implemente la interfaz lEmpresas 
//2.- Agregar la lógica parecida a las empresas ya existentes y cambiar los datos necesarios
//Archivo Main
//1.- Declarar la variable de la nueva paqueteria lEmpresas [paqueteria] = new [paqueteriaService](new List<lEnvios>() { [ARREGLO DE TIPOS DE ENVIO] }, [MARGEN DE GANANCIA EN %], "[NOMBRE DE LA PAQUETERIA]");
//2.- Agregar la nueva paqueteria a la lista de empresas lstEmpresas


//Agregar nueva medio de transporte
//1.- Agregar clase en la carpeta envios con el nombre del transporte y que implemente la interfaz lEnvios 
//2.- Agregar la lógica parecida a las empresas ya existentes
//Archivo Main
//1.- Declarar la variable del nuevo medio de transporte lEnvios [NOMBRE_VARIABLE] = new Avion() { dVelocidadEntrega = [VALOR_VELOCIDAD], dCostoEnvio = [COSTO],cNombre="[NOMBRE_TRANSPORTE]" };
//2.- Agregar el nuevo medio de transporte a la lista de transportes lstTransportes
