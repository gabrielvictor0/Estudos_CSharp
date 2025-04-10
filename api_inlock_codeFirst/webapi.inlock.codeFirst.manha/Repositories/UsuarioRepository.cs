using webapi.inlock.codeFirst.manha.Context;
using webapi.inlock.codeFirst.manha.Domains;
using webapi.inlock.codeFirst.manha.Interfaces;
using webapi.inlock.codeFirst.manha.Utils;

namespace webapi.inlock.codeFirst.manha.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Varialvel privada e somente leitura para armazenar o dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositório
        /// Toda vez que o repositório foir instanciado,
        /// Ele terá acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public Usuario BuscarUsuario(string senha, string email)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {

                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);


                ctx.Usuario.Add(usuario);


                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
