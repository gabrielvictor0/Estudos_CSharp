using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;

namespace HealthClinic_Senaimanha.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ClinicaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }
        public void Atualizar(Guid id, Clinica clinicaAtual)
        {
            Clinica clinicaBuscada = _healthClinicContext.Clinica.Find(id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada.Telefone = clinicaAtual.Telefone;

                clinicaBuscada.HorarioAbertura = clinicaBuscada.HorarioAbertura;

                clinicaBuscada.HorarioFechamento = clinicaBuscada.HorarioFechamento;

                clinicaBuscada.Endereco = clinicaAtual.Endereco;

                clinicaBuscada.NomeFantasia = clinicaAtual.NomeFantasia;
            }

            _healthClinicContext.Clinica.Update(clinicaBuscada!);
            
            _healthClinicContext.SaveChanges();
        }

        public void Cadastrar(Clinica novaClinica)
        {
            _healthClinicContext.Clinica.Add(novaClinica);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Clinica clinicaBuscada = _healthClinicContext.Clinica.Find(id)!;

            _healthClinicContext.Clinica.Remove(clinicaBuscada);

            _healthClinicContext.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return _healthClinicContext.Clinica.ToList();
        }
    }
}
