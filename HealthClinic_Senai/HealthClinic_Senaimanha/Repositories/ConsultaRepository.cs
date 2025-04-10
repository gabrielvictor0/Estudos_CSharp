using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;

namespace HealthClinic_Senaimanha.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ConsultaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.Find(id)!;

            if(consultaBuscada != null)
            {
                consultaBuscada.DataConsulta = consulta.DataConsulta;

                consultaBuscada.HorarioConsulta = consulta.HorarioConsulta;
            }

            _healthClinicContext.Consulta.Update(consultaBuscada!);

            _healthClinicContext.SaveChanges();
        }

        public Consulta BuscarPorId(Guid id)
        {
            return _healthClinicContext.Consulta.Select(c => new Consulta
            {
                IdConsulta = c.IdConsulta,
                DataConsulta = c.DataConsulta,
                HorarioConsulta = c.HorarioConsulta,
                IdMedico = c.IdMedico,
                IdPaciente = c.IdPaciente,
                Medico = new Medico
                {
                    IdMedico = c.Medico.IdMedico,
                    CRM = c.Medico.CRM
                },
                Paciente = new Paciente
                {
                    IdPaciente = c.Paciente!.IdPaciente,
                    CPF = c.Paciente.CPF,
                    DataNascimento = c.Paciente.DataNascimento,
                    Telefone = c.Paciente.Telefone
                }
            }).FirstOrDefault(c => c.IdConsulta == id)!;
        }
                
        public void Cadastrar(Consulta consulta)
        {
            _healthClinicContext.Consulta.Add(consulta);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.Find(id)!;

            _healthClinicContext.Consulta.Remove(consultaBuscada);

            _healthClinicContext.SaveChanges();
        }

        public List<Consulta> ListarTodos()
        {
            return _healthClinicContext.Consulta.Select(c => new Consulta
            {
                IdConsulta = c.IdConsulta,
                DataConsulta = c.DataConsulta,
                HorarioConsulta = c.HorarioConsulta,
                IdMedico = c.IdMedico,
                IdPaciente = c.IdPaciente,
                Medico = new Medico
                {
                    IdMedico = c.Medico!.IdMedico,
                    CRM = c.Medico.CRM
                },
                Paciente = new Paciente
                {
                    IdPaciente = c.Paciente!.IdPaciente,
                    CPF = c.Paciente.CPF,
                    DataNascimento = c.Paciente.DataNascimento,
                    Telefone = c.Paciente.Telefone
                }
            }).ToList();
        }
    }
}
