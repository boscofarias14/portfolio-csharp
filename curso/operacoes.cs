using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso {
    class Operacoes {
        public static int getCodigo(int codigo) {
            string aux = codigo.ToString();
            aux = aux.Substring(2, 2);
            int codigoFinal = int.Parse(aux);
            return codigoFinal * 100;
        }
        
    }
}
