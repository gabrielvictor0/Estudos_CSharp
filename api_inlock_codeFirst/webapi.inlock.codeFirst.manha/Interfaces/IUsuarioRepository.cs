using webapi.inlock.codeFirst.manha.Domains;

namespace webapi.inlock.codeFirst.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string senha, string email);

        void Cadastrar(Usuario usuario);
    }
}
