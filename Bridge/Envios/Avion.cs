using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class Avion : lEnvios
    {
        public decimal dCostoEnvio { get; set; }

        public decimal dVelocidadEntrega { get; set; }

        public string cNombre { get; set; }
    }
}
