using webapi.inlock.codeFirst.manha.Context;
using webapi.inlock.codeFirst.manha.Domains;
using webapi.inlock.codeFirst.manha.Interfaces;

namespace webapi.inlock.codeFirst.manha.Repositorys
{
    public class EstudioRepository : IEstudioRepository
    {
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudio.Find(id);

            ctx.Estudio.Remove(estudioBuscado);
        }

        public List<Estudio> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Estudio> ListarComJogos()
        {
            throw new NotImplementedException();
        }
    }
}
