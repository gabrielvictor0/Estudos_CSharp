using HealthClinic_Senaimanha.Domains;

namespace HealthClinic_Senaimanha.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        void Atualizar(Guid id, Medico medico);

        List<Medico> ListarTodos();

        Medico BuscarPorId(Guid id);

        void Deletar(Guid id);
    }
}
