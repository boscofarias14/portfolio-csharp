using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso.dominio {
    class Acessorio {
        public string nomeAcessorio { get; set; }
        public double precoAcessorio { get; set; }

        public Carro carro { get; set; }

        public Acessorio(string nomeAcessorio, double precoAcessorio, Carro carro) {
            this.nomeAcessorio = nomeAcessorio;
            this.precoAcessorio = precoAcessorio;
            this.carro = carro;
        }

        public override string ToString() {
            return $"DESCRIÇÃO: {nomeAcessorio}\n" +
                    $"PREÇO: R${precoAcessorio.ToString("F2", CultureInfo.InvariantCulture)}\n";
        }

    }
}
