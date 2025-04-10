using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produtos
{
    public class Login
    {
        public bool Logado { get; set; }

        //CONSTRUTOR
        public Login()
        {
            Usuario user = new Usuario();

            Logar(user);

            if (Logado == true)
            {
                GerarMenu();
            }

        }


        public void Logar(Usuario usuario)
        {

            do
            {
                Console.WriteLine($"Insira seu email: ");
                string email = Console.ReadLine();

                Console.WriteLine($"Insira sua senha: ");
                string senha = Console.ReadLine();

                if (email == usuario.Email && senha == usuario.Senha)
                {
                    this.Logado = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Login realizado!");
                    Console.ResetColor();
                }
                else
                {
                    this.Logado = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Falha ao logar!");
                    Console.ResetColor();
                }
            } while (Logado == false);
        }

        public void Deslogar()
        {
            Logado = false;
        }

        public void GerarMenu()
        {
            Produto produto = new Produto();
            Marca marca = new Marca();

            string opcao;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@$"
=======================
[1] - Cadastrar produto
[2] - Listar produtos
[3] - Deletar produto
=======================
[4] - Cadastrar marca
[5] - Listar marcas
[6] - Deletar marca
=======================
[0] - Sair
=======================");
                Console.ResetColor();
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        produto.Cadastrar();
                        break;
                    case "2":
                        produto.Listar();
                        break;
                    case "3":
                        Console.WriteLine($"Informe o código do produto que deseja deletar: ");
                        int CodProduto = int.Parse(Console.ReadLine());
                        produto.Deletar(CodProduto);
                        break;
                    case "4":
                        marca.Cadastrar();
                        break;
                    case "5":
                        marca.Listar();
                        break;
                    case "6":
                        Console.WriteLine($"Informe o código da marca que deseja deletar: ");
                        int CodMarca = int.Parse(Console.ReadLine());
                        marca.Deletar(CodMarca);
                        break;
                    case "0":
                        Console.WriteLine($"Sistema finalizado!");
                        break;
                    default:
                        Console.WriteLine($"Opção inválida!");
                        break;
                }


            } while (opcao != "0");
        }
    }
}