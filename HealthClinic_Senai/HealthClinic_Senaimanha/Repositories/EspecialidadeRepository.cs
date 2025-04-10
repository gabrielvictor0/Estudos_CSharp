using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;

namespace HealthClinic_Senaimanha.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public EspecialidadeRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Especialidade especialidade)
        {
            Especialidade especialidadeBuscada = _healthClinicContext.Especialidade.Find(id)!;

            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.Nome = especialidade.Nome;
            }

            _healthClinicContext.Especialidade.Update(especialidadeBuscada!);

            _healthClinicContext.SaveChanges();
        }

        public void Cadastrar(Especialidade especialidade)
        {
            _healthClinicContext.Especialidade.Add(especialidade);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Especialidade especialidadeBuscada = _healthClinicContext.Especialidade.Find(id)!;

            _healthClinicContext.Especialidade.Remove(especialidadeBuscada);

            _healthClinicContext.SaveChanges();
        }

        public List<Especialidade> ListarTodas()
        {
            return _healthClinicContext.Especialidade.ToList();
        }
    }
}
