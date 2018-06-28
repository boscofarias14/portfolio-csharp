using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso.dominio {
    class Carro : IComparable {
        public int codigoCarro { get; set; }
        public string modeloCarro { get; set; }
        public int anoCarro { get; set; }
        public double precoBasicoCarro { get; set; }
        public Marca marcaCarro { get; set; }
        public List<Acessorio> listaAcessorios;

        public Carro(int codigoCarro, string modeloCarro, int anoCarro, double precoBasicoCarro, Marca marcaCarro) {
            this.codigoCarro = codigoCarro;
            this.modeloCarro = modeloCarro;
            this.anoCarro = anoCarro;
            this.precoBasicoCarro = precoBasicoCarro;
            this.marcaCarro = marcaCarro;
            listaAcessorios = new List<Acessorio>();
        }

        public double precoTotal() {
            double precoTotalCarro = precoBasicoCarro;
            for(int i = 0; i < listaAcessorios.Count; i++) {
                precoTotalCarro += listaAcessorios[i].precoAcessorio;
            }
            return precoTotalCarro;
        }

        
        public override string ToString() {
            string carroString = $"CÓDIGO: {codigoCarro}\n" +
                $"MODELO: {modeloCarro}\n" +
                $"ANO: {anoCarro}\n" +
                $"PREÇO BÁSICO: R${precoBasicoCarro.ToString("F2", CultureInfo.InvariantCulture)}\n";
                
            if(listaAcessorios.Count > 0) {
                carroString += $"ACESSÓRIOS:\n";
            }
            for(int i = 0; i < listaAcessorios.Count; i++) {
                carroString += $"{"".PadRight(60, '.')}\n" +
                    $"Acessório {i + 1}:\n" +
                    $"{listaAcessorios[i]}";
            }
            
            carroString += $"{"".PadRight(60, '=')}\n" +
                $"PREÇO TOTAL: R${precoTotal().ToString("F2", CultureInfo.InvariantCulture)}";
            return carroString;
        }

        public int CompareTo(object obj) {
            Carro car = (Carro)obj;
            int result = codigoCarro.CompareTo(car.codigoCarro);
            if(result != 0) {
                return result;
            }
            else {
                return -modeloCarro.CompareTo(car.modeloCarro);
            }
        }
    }
}
