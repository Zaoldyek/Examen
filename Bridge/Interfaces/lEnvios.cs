using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public interface lEnvios
    {
        decimal dCostoEnvio { get; set; }

        decimal dVelocidadEntrega { get; set; }

        string cNombre { get; set; }

    }
}
