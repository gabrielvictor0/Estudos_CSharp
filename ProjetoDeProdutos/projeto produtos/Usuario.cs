using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produtos
{
    public class Usuario
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        DateTime DataCadastro { get; set; }

        public Usuario()
        {
            Cadastrar();
        }

        //cadastrando usuário
        public void Cadastrar()
        {
            this.Nome = "Gabriel";
            this.Email = "gabriel@gmail.com";
            this.Senha = "134";
            this.DataCadastro = DateTime.Now;

        }

        public void DeletUsuario()
        {
            this.Nome = "";
            this.Email = "";
            this.Senha = "";
            this.DataCadastro = DateTime.Parse("0000-00-00T00:00:00");

        }

    }
}