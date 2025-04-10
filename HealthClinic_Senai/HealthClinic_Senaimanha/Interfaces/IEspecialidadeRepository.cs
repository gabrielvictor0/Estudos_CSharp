using HealthClinic_Senaimanha.Domains;

namespace HealthClinic_Senaimanha.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);

        void Deletar(Guid id);

        void Atualizar(Guid id, Especialidade especialidade);

        List<Especialidade> ListarTodas();
    }
}
