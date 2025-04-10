using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;
using HealthClinic_Senaimanha.Utils;

namespace HealthClinic_Senaimanha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public UsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Usuario usuario)
        {
             Usuario usuarioBuscado = _healthClinicContext.Usuario.Find(id)!;

            if(usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
            }

            _healthClinicContext.Usuario.Update(usuarioBuscado!);

            _healthClinicContext.SaveChanges();
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthClinicContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Email = u.Email,
                    Senha = u.Senha,
                    IdTipoDeUsuario = u.IdTipoDeUsuario,
                    TipoDeUsuario = new TipoDeUsuario
                    {
                        IdTipoDeUsuario = u.TipoDeUsuario!.IdTipoDeUsuario,
                        Nome = u.TipoDeUsuario.Nome
                    }
                }).FirstOrDefault(i => i.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

            _healthClinicContext.Usuario.Add(usuario);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Usuario usuarioBuscado = _healthClinicContext.Usuario.Find(id)!;

            _healthClinicContext.Usuario.Remove(usuarioBuscado);

            _healthClinicContext.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return _healthClinicContext.Usuario.Select(u => new Usuario
            {
                IdUsuario = u.IdUsuario,
                Email = u.Email,
                Senha = u.Senha,
                IdTipoDeUsuario = u.IdTipoDeUsuario,
                TipoDeUsuario = new TipoDeUsuario
                {
                    IdTipoDeUsuario = u.TipoDeUsuario!.IdTipoDeUsuario,
                    Nome = u.TipoDeUsuario.Nome
                }
            }).ToList();
        }

        public Usuario LoginEmailSenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthClinicContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Email = u.Email,
                    Senha = u.Senha,
                    IdTipoDeUsuario = u.IdTipoDeUsuario,
                    TipoDeUsuario = new TipoDeUsuario
                    {
                        IdTipoDeUsuario = u.TipoDeUsuario!.IdTipoDeUsuario,
                        Nome = u.TipoDeUsuario.Nome
                    }
                }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }

                }
                    return null!;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
