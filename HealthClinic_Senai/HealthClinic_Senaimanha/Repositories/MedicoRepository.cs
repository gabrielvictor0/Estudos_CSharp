using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;

namespace HealthClinic_Senaimanha.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public MedicoRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscado = _healthClinicContext.Medico.Find(id)!;

            if (medicoBuscado != null)
            {
                medicoBuscado.Endereco = medico.Endereco;

                medicoBuscado.Telefone = medico.Telefone;
            }

            _healthClinicContext.Medico.Update(medicoBuscado!);

            _healthClinicContext.SaveChanges();
        }

        public Medico BuscarPorId(Guid id)
        {
            return _healthClinicContext.Medico.Select(m => new Medico
            {
                IdMedico = m.IdMedico,
                CRM = m.CRM,
                Endereco = m.Endereco,
                CPF = m.CPF,
                Telefone = m.Telefone,
                IdEspecialidade = m.IdEspecialidade,
                IdUsuario = m.IdUsuario,
                Usuario = new Usuario
                {
                    IdUsuario = m.Usuario!.IdUsuario,
                    Email = m.Usuario!.Email
                },
                Especialidade = new Especialidade
                {
                    IdEspecialidade = m.Especialidade!.IdEspecialidade,
                    Nome = m.Especialidade.Nome
                }
            }).FirstOrDefault(m => m.IdMedico == id)!;
        }

        public void Cadastrar(Medico medico)
        {
            _healthClinicContext.Medico.Add(medico);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Medico medicoBuscado = _healthClinicContext.Medico.Find(id)!;

            _healthClinicContext.Medico.Remove(medicoBuscado);

            _healthClinicContext.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return _healthClinicContext.Medico.Select(m => new Medico 
            {
                IdMedico = m.IdMedico,
                CRM = m.CRM,
                Endereco = m.Endereco,
                CPF = m.CPF,
                Telefone = m.Telefone,
                IdEspecialidade = m.IdEspecialidade,
                IdUsuario = m.IdUsuario,
                Usuario = new Usuario
                {
                    IdUsuario = m.Usuario!.IdUsuario,
                    Email = m.Usuario!.Email
                },
                Especialidade = new Especialidade
                {
                    IdEspecialidade = m.Especialidade!.IdEspecialidade,
                    Nome = m.Especialidade.Nome
                }
            }).ToList();
        }
    }
}
