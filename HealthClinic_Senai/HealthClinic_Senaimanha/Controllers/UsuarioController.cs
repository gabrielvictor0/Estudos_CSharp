using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;
using HealthClinic_Senaimanha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_Senaimanha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro de usuario
        /// </summary>
        /// <param name="usuario">Usuario que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok("Usuario cadastrado");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar usuário pelo ID
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return Ok("Usuario deletado com sucesso!");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar usuário pelo ID
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuario">Usuário atualizado</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Usuario usuario)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuario);

                return Ok("Usuario atualizado com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar usuário por ID
        /// </summary>
        /// <param name="id">ID do usuário que será listado</param>
        /// <returns>Usuário que contém o ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar todos usuários
        /// </summary>
        /// <returns>Lista com todos usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
