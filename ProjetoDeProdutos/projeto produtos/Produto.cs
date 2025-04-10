using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produtos
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string NomeProduto { get; set; }

        public float Preco { get; set; }

        DateTime DataCadastro { get; set; }

        public Usuario CadastradoPor { get; set; }

        List<Produto> ListaDeProdutos = new List<Produto>();

        public Marca Marca = new Marca();

        Usuario user = new Usuario();
        public Produto Cadastrar()
        {
            Produto _produtos = new Produto();

            Console.WriteLine($"Informe o código do produto: ");
            _produtos.Codigo = int.Parse(Console.ReadLine());

            Console.WriteLine($"Informe o nome do produto: ");
            _produtos.NomeProduto = Console.ReadLine();

            Console.WriteLine($"Informe o preço do produto: ");
            _produtos.Preco = float.Parse(Console.ReadLine());


            _produtos.Marca = Marca.Cadastrar();

            _produtos.DataCadastro = DateTime.Now;

            ListaDeProdutos.Add(_produtos);

            return _produtos;
        }

        public void Listar()
        {
            foreach (var item in ListaDeProdutos)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@$"
Código do produto: {item.Codigo}
Nome do produto: {item.NomeProduto}
Preço do produto: {item.Preco}
--------------------------------
Código da marca: {item.Marca.Codigo}
Nome da marca: {item.Marca.NomeMarca}
{item.DataCadastro}
");
                Console.ResetColor();
            }
        }

        public void Deletar(int _cod)
        {
            Produto produtoEncontrado = ListaDeProdutos.Find(produto => produto.Codigo == _cod);
            ListaDeProdutos.Remove(produtoEncontrado);
        }
    }
}