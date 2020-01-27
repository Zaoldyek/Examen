using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{

    public class DesactivarState : Pedido
    {
        State context { get; set; }

        public void setContext(State context)
        {
            this.context = context;
        }

        public void PedidoEntregado()
        {
            ActivarState ActivarAlarma = new ActivarState();
            ActivarAlarma.setContext(context);
            context.changeState(ActivarAlarma);
        }

        public void PedidoNoEntregado()
        {
        }
    }

}
