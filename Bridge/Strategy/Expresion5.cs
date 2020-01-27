using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Expresion5 : lStrategy
    {
        public string Ejecutar(DateTime _dtFechaEntrega, DateTime _dtHoy,State.State _entPedido)
        {
            TimeSpan dtDiferencia = _dtFechaEntrega.Subtract(_dtHoy);
            int iTotalHoras = Math.Abs(Convert.ToInt32(dtDiferencia.TotalHours));
            int iCantidad = 0;
            string cDiferenciaTiempo = "";
            if (iTotalHoras < 1)
            {
                iCantidad = (iTotalHoras / 60);
                cDiferenciaTiempo = $"{iCantidad} Minutos";
            }
            if (iTotalHoras >= 1 && iTotalHoras <= 23)
            {
                iCantidad = iTotalHoras;
                cDiferenciaTiempo = $"{iCantidad} Horas";
            }
            if (iTotalHoras > 23)
            {
                iCantidad=(iTotalHoras / 23);
                cDiferenciaTiempo = $"{iCantidad} Días";
            }
            if (iTotalHoras >= 690)
            {
                iCantidad = (iCantidad / 30);
                cDiferenciaTiempo = $"{iCantidad} Meses";
            }

            return cDiferenciaTiempo;
        }
    }
}
