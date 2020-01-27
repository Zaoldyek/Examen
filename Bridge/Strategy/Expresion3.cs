using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Expresion3 : lStrategy
    {
        public string Ejecutar(DateTime _dtFechaEntrega, DateTime _dtHoy, State.State _entPedido)
        {
            int result = DateTime.Compare(_dtFechaEntrega, _dtHoy);
            string cConcepto = "";
            if (result < 0)
            {
                _entPedido.EntregarPedido();
                cConcepto = "hace";
            }
            else
                cConcepto = "dentro de";


            return cConcepto;
        }
    }
}
