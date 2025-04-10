using HealthClinic_Senaimanha.Domains;
using System.Globalization;

namespace HealthClinic_Senaimanha.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario LoginEmailSenha(string email, string senha);

        void Cadastrar(Usuario usuario);

        void Atualizar(Guid id, Usuario usuario);

        void Deletar(Guid id);

        Usuario BuscarPorId(Guid id);

        List<Usuario> ListarTodos();
    }
}
