using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Context
    {
        lStrategy strategy { get; set; }

        public void setStrategy(lStrategy _strategy)
        {
            strategy = _strategy;
        }

        public string ValidarFechaEntrega(DateTime _dtFechaEntrega, DateTime _dtHoy,State.State _entPedido)
        {
           return strategy.Ejecutar(_dtFechaEntrega, _dtHoy, _entPedido);
        }
    }
}
