using System;

namespace State
{
    public class ActivarState : Pedido
    {
        State context { get; set; }

        public void setContext(State context)
        {
            this.context = context;
        }

        public void PedidoEntregado()
        {

        }

        public void PedidoNoEntregado()
        {
            DesactivarState DesactivarPedido = new DesactivarState();
            DesactivarPedido.setContext(context);
            context.changeState(DesactivarPedido);
        }
    }
}
