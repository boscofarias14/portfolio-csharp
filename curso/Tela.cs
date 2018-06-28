using curso.dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso {
    class Tela {
        public static void ExibirMenu() {
            Console.WriteLine($"{"".PadRight(80, '=')}\n" +
                $"MENU PRINCIPAL - Escolha uma opção\n" +
                $"{"".PadRight(80, '.')}\n" +
                $"1 - Listar Marcas\n" +
                $"2 - Listar Carros de uma marca ordenadamente\n" +
                $"3 - Cadastrar Marca\n" +
                $"4 - Cadastrar Carro\n" +
                $"5 - Cadastrar Acessório\n" +
                $"6 - Mostrar Detalhes de um carro\n" +
                $"7 - Sair\n" +
                $"{"".PadRight(80, '=')}");
        }

        public static void ListarMarcas() {
            Console.Clear();
            Console.WriteLine($"{"".PadRight(80, '=')}\n" +
                $"LISTAGEM DE MARCAS\n" +
                $"{"".PadRight(80, '=')}\n");

            for(int i = 0; i < Program.listaMarcas.Count; i++) {
                Console.WriteLine(Program.listaMarcas[i]);
                Console.WriteLine("".PadRight(80, '.'));
            }
        }

        public static void ListagemPorMarca() {
            Console.Clear();
            Console.WriteLine($"{"".PadRight(80, '=')}\n" +
                $"LISTAGEM DE CARROS POR MARCA\n" +
                $"{"".PadRight(80, '=')}\n");

            Console.Write("Digite o código da Marca: ");
            int codigoMarca = int.Parse(Console.ReadLine());
            int pos = Program.listaMarcas.FindIndex(x => x.codigoMarca == codigoMarca);
            if(pos == -1) {
                throw new ModelException("Marca inexistente");
            }            

            Console.WriteLine($"{"".PadRight(60, '-')}\n" +
                $"Carros da {Program.listaMarcas[pos].nomeMarca}\n" +
                $"{"".PadRight(60, '-')}");

            List<Carro> carros = Program.listaMarcas[pos].carrosMarca;
            
            
            for(int i = 0; i < carros.Count; i++) {
                Console.WriteLine();
                Console.WriteLine(carros[i]);
                Console.WriteLine("".PadRight(60, '#'));
            }

        }
        public static void CadastrarMarca() {
            Console.Clear();
            Console.WriteLine($"{"".PadRight(80, '=')}\n" +
                $"CADASTRO DE MARCAS\n" +
                $"{"".PadRight(80, '=')}\n");
            
            Console.WriteLine($"{"".PadRight(60, '-')}\n" +
                $"Digite os dados da Marca\n" +
                $"{"".PadRight(60, '-')}");
            int UltimocodigoMarca = Program.listaMarcas[Program.listaMarcas.Count - 1].codigoMarca;

            int codMarca = UltimocodigoMarca + 1;
            Console.WriteLine($"CÓDIGO: {codMarca}");
            

            Console.Write("NOME: ");
            string nomeMarca = Console.ReadLine();

            Console.Write("PAÍS DE ORIGEM: ");
            string paisMarca = Console.ReadLine();

            Marca marca = new Marca(codMarca, nomeMarca, paisMarca);
            Program.listaMarcas.Add(marca);

            Console.WriteLine("Deseja adicionar outra marca ? (S/N)");
            char opt = char.Parse(Console.ReadLine());

            if(opt == 's' || opt == 'S') {
                CadastrarMarca();
            }
        }

        public static void CadastrarCarro() {
            Console.Clear();
            Console.WriteLine($"{"".PadRight(80, '=')}\n" +
                $"CADASTRO DE CARROS\n" +
                $"{"".PadRight(80, '=')}");

            Console.WriteLine($"{"".PadRight(60, '-')}\n" +
                $"Digite os dados do Carro\n" +
                $"{"".PadRight(60, '-')}");

            Console.Write("CÓDIGO DA MARCA: ");
            int codMarca = int.Parse(Console.ReadLine());
            int pos = Program.listaMarcas.FindIndex(x => x.codigoMarca == codMarca);

            List<Carro> carros = Program.listaMarcas[pos].carrosMarca;
            
            if (pos == -1) {
                throw new ModelException("Marca inexistente");
            }

            Console.WriteLine($"{"".PadRight(60, '-')}\n" +
                $"Marca selecionada: {Program.listaMarcas[pos].nomeMarca}\n" +
                $"{"".PadRight(60, '-')}");

            //Gera o código do carro com referência nos dois últimos digitos do Código da Marca
            int codCarro = Operacoes.getCodigo(codMarca) + carros.Count;

            Console.Write($"CÓDIGO DO CARRO: {codCarro}");
            Console.WriteLine();

            Console.Write("MODELO: ");
            string modeloCarro = Console.ReadLine();

            Console.Write("ANO: ");
            int anoCarro = int.Parse(Console.ReadLine());

            Console.Write("PREÇO BÁSICO: ");
            double precoBasicoCarro = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Marca M = Program.listaMarcas[pos];
            Carro carro = new Carro(codCarro, modeloCarro, anoCarro, precoBasicoCarro, M);

            M.addCarro(carro);
            Program.listaCarros.Add(carro);
            Console.WriteLine("Deseja adicionar outro carro ? (S/N)");
            char opt = char.Parse(Console.ReadLine());
            if (opt == 's' || opt == 'S') {
                CadastrarCarro();
            }
            
        }

        public static void CadastrarAcessorio() {
            Console.Clear();
            Console.WriteLine($"{"".PadRight(80, '=')}\n" +
                $"CADASTRO DE ACESSÓRIOS\n" +
                $"{"".PadRight(80, '=')}\n");

            Console.WriteLine($"{"".PadRight(60, '-')}\n" +
                $"Digite os dados do Acessório\n" +
                $"{"".PadRight(60, '-')}");

            Console.Write("CÓDIGO DO CARRO: ");
            int codCarro = int.Parse(Console.ReadLine());
            int pos = Program.listaCarros.FindIndex(x => x.codigoCarro == codCarro);
            if(pos == -1) {
                throw new ModelException("Carro não encontrado");
            }
            Console.WriteLine($"{"".PadRight(60, '-')}\n" +
               $"Carro selecionado: {Program.listaCarros[pos].modeloCarro}\n" +
               $"{"".PadRight(60, '-')}");

            Console.Write($"DESCRIÇÃO: ");
            string nomeAcessorio = Console.ReadLine();

            Console.Write("PREÇO: ");
            double precoAcessorio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Carro c = Program.listaCarros[pos];
            Acessorio ac = new Acessorio(nomeAcessorio, precoAcessorio, c);
            c.listaAcessorios.Add(ac);
            Console.WriteLine("Deseja adicionar outro Acessório ? (S/N)");
            char opt = char.Parse(Console.ReadLine());

            if (opt == 's' || opt == 'S') {
                CadastrarAcessorio();
            }
        }
        public static void MostrarCarro() {
            Console.Clear();
            Console.WriteLine($"{"".PadRight(80, '=')}\n" +
                $"LISTAGEM DE CARROS\n" +
                $"{"".PadRight(80, '=')}\n");
            
            Console.Write("CÓDIGO DO CARRO: ");
            int codCarro = int.Parse(Console.ReadLine());

            int pos = Program.listaCarros.FindIndex(x => x.codigoCarro == codCarro);
            if(pos == -1) {
                throw new ModelException("Carro não encontrado");
            }
            List<Carro> carros = Program.listaCarros;
            Console.WriteLine($"{"".PadRight(60, '-')}\n" +
                $"CARRO SELECIONADO: {carros[pos].modeloCarro}\n" +
                $"{"".PadRight(60, '-')}");

            Console.WriteLine(carros[pos]);
        }
    }
}
