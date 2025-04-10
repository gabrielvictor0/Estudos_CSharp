using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Método para cadastrar novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto(jogo) que será cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);
        
        /// <summary>
        /// Método para listar todos os jogos
        /// </summary>
        /// <returns>Lista com todos objetos(jogos)</returns>
        List<JogoDomain> ListarTodos();


        /// <summary>
        /// Método para deletar objeto(jogo) pelo id
        /// </summary>
        /// <param name="id">Id do objeto(jogo) que será deletado</param>
        void Deletar(int id);
    }
}
