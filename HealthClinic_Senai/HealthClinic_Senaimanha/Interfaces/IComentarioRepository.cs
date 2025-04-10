using HealthClinic_Senaimanha.Domains;

namespace HealthClinic_Senaimanha.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);

        void Atualizar(Comentario comentario, Guid id);

        void Deletar(Guid id);

        Comentario BuscarPorId(Guid id);
    }
}
