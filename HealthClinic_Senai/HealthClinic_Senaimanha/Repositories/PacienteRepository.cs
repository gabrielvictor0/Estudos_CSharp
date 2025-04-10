using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;

namespace HealthClinic_Senaimanha.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public PacienteRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = _healthClinicContext.Paciente.Find(id)!;

            if(pacienteBuscado != null)
            {
                pacienteBuscado.Telefone = paciente.Telefone;

                pacienteBuscado.Endereco = paciente.Endereco;
            }

            _healthClinicContext.Paciente.Update(pacienteBuscado!);

            _healthClinicContext.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            return  _healthClinicContext.Paciente.Select(p => new Paciente
            {
                IdPaciente = p.IdPaciente,
                DataNascimento = p.DataNascimento,
                Endereco = p.Endereco,
                CPF = p.CPF,
                Telefone = p.Telefone,
                IdUsuario = p.IdUsuario,
                Usuario = new Usuario
                {
                    IdUsuario = p.Usuario!.IdUsuario,
                    Email = p.Usuario.Email
                }
            }).FirstOrDefault(p => p.IdPaciente == id)!;
        }

        public void Cadastrar(Paciente paciente)
        {
            _healthClinicContext.Paciente.Add(paciente);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Paciente pacienteBuscado = _healthClinicContext.Paciente.Find(id)!;

            _healthClinicContext.Paciente.Remove(pacienteBuscado);

            _healthClinicContext.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return _healthClinicContext.Paciente.Select(p => new Paciente
            {
                IdPaciente = p.IdPaciente,
                DataNascimento = p.DataNascimento,
                Endereco = p.Endereco,
                CPF = p.CPF,
                Telefone = p.Telefone,
                IdUsuario = p.IdUsuario,
                Usuario = new Usuario
                {
                    IdUsuario = p.Usuario!.IdUsuario,
                    Email = p.Usuario.Email
                }
            }).ToList();
        }
    }
}
