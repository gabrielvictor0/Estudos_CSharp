using HealthClinic_Senaimanha.Domains;

namespace HealthClinic_Senaimanha.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);
        
        void Atualizar(Guid id, Paciente paciente);

        List<Paciente> ListarTodos();

        Paciente BuscarPorId(Guid id);

        void Deletar(Guid id);
    }
}
