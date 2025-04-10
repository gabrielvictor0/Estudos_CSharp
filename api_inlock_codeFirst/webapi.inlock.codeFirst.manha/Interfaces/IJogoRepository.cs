using webapi.inlock.codeFirst.manha.Domains;

namespace webapi.inlock.codeFirst.manha.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();

        Jogo BuscarPorId(Guid id);

        void Cadastrar(Jogo jogo);

        void Atualizar(Guid id, Jogo jogo);

        void Deletar(Guid id);
    }
}
