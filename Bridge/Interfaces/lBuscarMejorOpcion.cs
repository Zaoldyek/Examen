using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Interfaces
{
    public interface lBuscarMejorOpcion
    {
        string ObtenerMejorOpcion(List<lEmpresas> lstEmpresas , lEmpresas empresa , State.State entPedido, decimal dCostoEnvio);
    }
}
