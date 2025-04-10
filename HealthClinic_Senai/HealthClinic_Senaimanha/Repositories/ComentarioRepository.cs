using HealthClinic_Senaimanha.Context;
using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;

namespace HealthClinic_Senaimanha.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ComentarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Comentario comentario, Guid id)
        {
            Comentario comentarioBuscado = _healthClinicContext.Comentario.Find(id)!;

            if (comentarioBuscado != null )
            {
                comentarioBuscado.Descricao = comentario.Descricao;

                comentarioBuscado.Exibir = comentario.Exibir;
            }

            _healthClinicContext.Comentario.Update(comentarioBuscado!);

            _healthClinicContext.SaveChanges();
        }

        public Comentario BuscarPorId(Guid id)
        {
            Comentario comentarioBuscado = _healthClinicContext.Comentario.FirstOrDefault(c => c.IdComentario == id)!;

            return comentarioBuscado;
        }

        public void Cadastrar(Comentario comentario)
        {
            _healthClinicContext.Comentario.Add(comentario);

            _healthClinicContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Comentario comentarioBuscado = _healthClinicContext.Comentario.Find(id)!;

            _healthClinicContext.Comentario.Remove(comentarioBuscado);

            _healthClinicContext.SaveChanges();
        }
    }
}
