using HealthClinic_Senaimanha.Domains;

namespace HealthClinic_Senaimanha.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Atualizar(Guid id, Consulta consulta);

        void Deletar(Guid id);

        List<Consulta> ListarTodos();

        Consulta BuscarPorId(Guid id);
    }
}
