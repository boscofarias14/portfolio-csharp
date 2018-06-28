using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso.dominio {
    class Marca {
        public int codigoMarca { get; set; }
        public string nomeMarca { get; set; }
        public string paisMarca { get; set; }
        public List<Carro> carrosMarca { get; set; }

        public Marca(int codigoMarca, string nomeMarca, string paisMarca) {
            this.codigoMarca = codigoMarca;
            this.nomeMarca = nomeMarca;
            this.paisMarca = paisMarca;
            carrosMarca = new List<Carro>();
        }

        public void addCarro(Carro carro) {
            carrosMarca.Add(carro);
            carrosMarca.Sort();
        }


        public override string ToString() {
            return $"CÓDIGO: {codigoMarca}\n" +
                $"NOME: {nomeMarca}\n" +
                $"PAÍS: {paisMarca}\n" +
                $"QUANTIDADE DE CARROS: {carrosMarca.Count}";
        }


    }
}
