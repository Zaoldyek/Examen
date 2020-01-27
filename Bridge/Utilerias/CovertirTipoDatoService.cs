using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Utilerias
{
    public class CovertirTipoDatoService : lConvertirTipoDato
    {
        public double ConvertirDecimalADouble(decimal _dNumero)
        {
            return (double)_dNumero;
        }

        public decimal ConvertirStringADecimal(string _cNumero)
        {
            return Convert.ToDecimal(_cNumero);
        }
    }
}
