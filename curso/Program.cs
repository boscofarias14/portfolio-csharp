using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curso.dominio;

namespace curso {
    class Program {
        public static List<Carro> listaCarros = new List<Carro>();
        public static List<Marca> listaMarcas = new List<Marca>();
        public static List<Acessorio> listaAcessorios = new List<Acessorio>();
        static void Main(string[] args) {

            Marca m1 = new Marca(1001, "Volkswagen", "Alemanha");
            Marca m2 = new Marca(1002, "General Motors", "Estados Unidos");
            listaMarcas.Add(m1);
            listaMarcas.Add(m2);

            Carro c1 = new Carro(100, "Gol", 2017, 35000.00, m1);
            m1.addCarro(c1);
            Carro c2 = new Carro(101, "Voyage", 2016, 42000.00, m1);
            m1.addCarro(c2);
            Carro c3 = new Carro(102, "Fox", 2017, 49000.00, m1);
            m1.addCarro(c3);
            Carro c4 = new Carro(200, "Onix", 2017, 55000.00, m2);
            m2.addCarro(c4);
            Carro c5 = new Carro(201, "Cruze", 2018, 60000.00, m2);
            m2.addCarro(c5);
            Carro c6 = new Carro(202, "Celta", 2012, 24000.00, m2);
            m2.addCarro(c6);

            listaCarros.Add(c1);
            listaCarros.Add(c2);
            listaCarros.Add(c3);
            listaCarros.Add(c4);
            listaCarros.Add(c5);
            listaCarros.Add(c6);

            int opcao = 0;
            while(opcao != 7) {
                Console.Clear();
                Tela.ExibirMenu();
                Console.Write("Digite a sua opção desejada: ");
                try { 
                opcao = int.Parse(Console.ReadLine());
                }
                catch(Exception e) {
                    Console.WriteLine($"Ocorreu um problema: {e.Message}");
                }
                switch (opcao) {
                    case 1:
                        Tela.ListarMarcas();
                        break;
                    case 2:
                        try { 
                            Tela.ListagemPorMarca();
                        }
                        catch(ModelException e) {
                            Console.WriteLine($"Ocorreu um problema de negócio: {e.Message}");
                        }
                        catch(Exception e) {
                            Console.WriteLine($"Ocorreu um problema: {e.Message}");
                        }
                        break;
                    case 3:
                        try { 
                            Tela.CadastrarMarca();
                        }
                        catch (Exception e) {
                            Console.WriteLine($"Ocorreu um problema: {e.Message}");
                        }
                        break;
                    case 4:
                        try {
                            Tela.CadastrarCarro();
                        }
                        catch(Exception e) {
                            Console.WriteLine($"Ocorreu um problema:{e.Message}");
                        }
                        break;
                    case 5:
                        try {
                            Tela.CadastrarAcessorio();
                        }
                        catch(ModelException e) {
                            Console.WriteLine($"Ocorreu um problema de negócio: {e.Message}");
                        }
                        break;
                    case 6:
                        try {
                            Tela.MostrarCarro();
                        }
                        catch(ModelException e) {
                            Console.WriteLine($"Ocorreu um problema de negócio: {e.Message}");
                        }
                        catch(Exception e) {
                            Console.WriteLine($"Ocorreu um problema de negócio: {e.Message}");
                        }
                        break;
                    case 7:
                        Console.Write("Fim da execução do programa!");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
