using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;

namespace HealthClinic_Senaimanha.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica novaClinica);

        void Atualizar(Guid id, Clinica clinicaAtual);

        void Deletar(Guid id);

        List<Clinica> ListarTodos();
    }
}
