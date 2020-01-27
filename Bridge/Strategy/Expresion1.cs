using System;

namespace Strategy
{
    public class Expresion1 : lStrategy
    {
        public string Ejecutar(DateTime _dtFechaEntrega, DateTime _dtHoy,State.State _entPedido)
        {
            int result = DateTime.Compare(_dtFechaEntrega, _dtHoy);
            string cConcepto = "";
            if (result < 0)
            {
                _entPedido.EntregarPedido();
                cConcepto = "salió";
            }
            else
                cConcepto = "ha salido";

            return cConcepto;
        }
    }
}
