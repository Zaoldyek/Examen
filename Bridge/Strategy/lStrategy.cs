using System;

namespace Strategy
{
    public interface lStrategy
    {
        string Ejecutar(DateTime _dtFechaEntrega, DateTime _dtHoy,State.State entPedido);
    }
}
