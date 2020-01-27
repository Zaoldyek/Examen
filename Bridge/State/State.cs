using Bridge;
using System;

namespace State
{
    public class State
    {
        public Pedido state { get; set; }
        public string cOrigen { get; set; }
        public string cDestino { get; set; }
        public decimal dDistancia { get; set; }
        public lEmpresas cPaqueteria { get; set; }
        public lEnvios cMedioTransporte { get; set; }
        public DateTime dtFechaHora { get; set; }
        public static Pedido ActivarState { get; internal set; }

        public State(Pedido PedidoState, string _cOrigen, string _cDestino, decimal _dDistancia, lEmpresas _cPaqueteria, lEnvios _cMedioTransporte, DateTime _dtFechaHora)
        {
            this.state = PedidoState;
            cOrigen = _cOrigen;
            cDestino = _cDestino;
            dDistancia = _dDistancia;
            cPaqueteria = _cPaqueteria;
            cMedioTransporte = _cMedioTransporte;
            dtFechaHora = _dtFechaHora;
            state.setContext(this);

        }

        public void changeState(Pedido PedidoState)
        {
            this.state = PedidoState;
        }

        public void EntregarPedido()
        {
            state.PedidoEntregado();
        }

        public void NoEntregarPedido()
        {
            state.PedidoNoEntregado();
        }

    }
}
