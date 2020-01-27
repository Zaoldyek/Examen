using State;
using System;
using System.Collections.Generic;

namespace Bridge
{
    public interface lEmpresas
    {
        List<lEnvios> lstEnvios { get; set; }
        string cNombre { get; set; }
        decimal MargenUtilidad{get;set;}
        decimal TiempoTraslado(State.State _entPedido);
        DateTime FechaEntrega(double _TiempoTraslado, State.State _entPedido);
        decimal CostoEnvio(State.State _entPedido);

    }
}
