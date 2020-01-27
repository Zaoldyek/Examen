using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    public class AsignarDatosEnvio : lAsignarDatosEnvio
    {
        public void AsignarEmpresa(string _cEmpresaSolicitada, ref lEmpresas _Empresa, List<lEmpresas> _lstEmpresas)
        {
            lEmpresas Empresa= _lstEmpresas.Where(s => s.cNombre == _cEmpresaSolicitada).FirstOrDefault();
            if (Empresa != null)
                _Empresa = Empresa;
            else
            {
                _Empresa = null;
                System.Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"La Paquetería: {_cEmpresaSolicitada} no se encuentra registrada en nuestra red de distribución.");
            }
        }

        public void AsignarTransporte(string _cTransporteSolicitada, ref lEnvios _Transporte, List<lEnvios> _lstTransportes)
        {
            _Transporte = _lstTransportes.Where(s => s.cNombre == _cTransporteSolicitada).FirstOrDefault();
        }
    }
}
