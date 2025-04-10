using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;

namespace HealthClinic_Senaimanha.Repositories
{
    public class TipoDeUsuarioRepository : ITipoDeUsuario
    {
        private readonly HealthClinicContext _healthClinicContext;

        public TipoDeUsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Cadastrar(TipoDeUsuario tipoDeUsuario)
        {
            _healthClinicContext.TipoDeUsuario.Add(tipoDeUsuario);

            _healthClinicContext.SaveChanges();
        }
    }
}
