﻿using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposUsuarioRepositoty : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepositoty()
        {
            _eventContext= new EventContext();
        }
        public void Atualizar(Guid id, TiposUsuario tipoUsuarioAtualizado)
        {
            TiposUsuario usuarioBuscado = _eventContext.TiposUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;
            }

            _eventContext.TiposUsuario.Update(usuarioBuscado!);

            _eventContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TiposUsuario.FirstOrDefault(u => u.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario usuarioBuscado = _eventContext.TiposUsuario.Find(id)!;

            _eventContext.TiposUsuario.Remove(usuarioBuscado);

            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _eventContext.TiposUsuario.ToList();
        }
    }
}
