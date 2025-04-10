using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método para cadastrar novo usuario
        /// </summary>
        /// <param name="novoUsuario">usuario a ser cadastrado</param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Método que lista todos os usuarios
        /// </summary>
        /// <returns>retorna uma lista de usuarios</returns>
        List<UsuarioDomain> ListarTodos();

        UsuarioDomain Login(string Email, string Senha);
    }
}
