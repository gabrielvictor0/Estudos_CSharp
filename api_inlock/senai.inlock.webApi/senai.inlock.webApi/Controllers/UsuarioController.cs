using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositorys;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/controller")]

    [ApiController]

    [Produces("application/json")]
    public class UsuarioController : Controller
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPost]

    }
}
