using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Interfaces
{
    interface lConvertirTipoDato
    {
        double ConvertirDecimalADouble(decimal _dNumero);

        decimal ConvertirStringADecimal(string _cNumero);
    }
}
