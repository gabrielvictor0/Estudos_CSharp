using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produtos
{
    public class Marca
    {
        public int Codigo { get; set; }

        public string NomeMarca { get; set; }

        DateTime DataCadastro { get; set; }

        public static List<Marca> ListaDeMarcas = new List<Marca>();

        public Marca Cadastrar()
        {
            Marca _marcas = new Marca();

            Console.WriteLine($"Informe o código da marca: ");
            _marcas.Codigo = int.Parse(Console.ReadLine());

            Console.WriteLine($"Informe o nome da marca: ");
            _marcas.NomeMarca = Console.ReadLine();

            _marcas.DataCadastro = DateTime.Now;

            ListaDeMarcas.Add(_marcas);

            return _marcas;
        }

        public void Listar()
        {
            foreach (var item in ListaDeMarcas)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@$"
                Código da marca: {item.Codigo}
                Nome da marca: {item.NomeMarca}
                {item.DataCadastro}");
                Console.ResetColor();
            }
        }

        public void Deletar(int _cod)
        {

            Marca marcaEncontrada = ListaDeMarcas.Find(marca => marca.Codigo == _cod);
            ListaDeMarcas.Remove(marcaEncontrada);
            Console.WriteLine($"Marca deletada com sucesso!");

        }
    }
}