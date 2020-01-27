using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Interfaces
{
    public interface lAsignarDatosEnvio
    {
        void AsignarEmpresa(string _cTransporteSolicitada, ref lEmpresas _Empresa, List<lEmpresas> lstEmpresas);

        void AsignarTransporte(string _cEmpresaSolicitada, ref lEnvios _Transporte, List<lEnvios> lstTransportes);
    }
}
