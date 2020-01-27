using Bridge.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class LeerArchivoTexto : lLeerArchivoTexto
    {
        public Func<string, string[]> lectorArchivo { get; set; }

        public LeerArchivoTexto()
        {
            lectorArchivo = e => File.ReadAllLines(e);
        }

        public List<string> LeerArchivo(string _cUrl)
        {
            return lectorArchivo(_cUrl).ToList();
        }
    }
}
