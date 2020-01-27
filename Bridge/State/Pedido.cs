using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public interface Pedido
    {
        void PedidoEntregado();

        void PedidoNoEntregado();

        void setContext(State context);
    }
}
