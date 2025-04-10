using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Método que cadastra novo objeto(Estudio)
        /// </summary>
        /// <param name="novoEstudio">Objeto(estudio) que será cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Método que lista todos objetos(Estudio)
        /// </summary>
        /// <returns>Lista de objetos(estudios)</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Método que deleta objeto(estudio) pelo ID
        /// </summary>
        /// <param name="id">Id do objeto(estudio) que será deletado</param>
        void Deletar(int id);
    }
}
