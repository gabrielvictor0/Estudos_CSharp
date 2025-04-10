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
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepository;

        public ComentarioController()
        {
            _comentarioRepository = new ComentarioRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro de comentário
        /// </summary>
        /// <param name="comentario">Comentário que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentarioRepository.Cadastrar(comentario);

                return Ok("Comentario cadastrado com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar comentário por ID
        /// </summary>
        /// <param name="comentario">Comentário atualizado</param>
        /// <param name="id">ID do comentário atualizado</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Comentario comentario, Guid id)
        {
            try
            {
                _comentarioRepository.Atualizar(comentario, id);

                return Ok("Comentario atualizado com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar comentário por ID
        /// </summary>
        /// <param name="id">ID do comentário buscado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);

                return Ok("Comentario deletado com sucesso!");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar comentário por ID
        /// </summary>
        /// <param name="id">ID do comentário buscado</param>
        /// <returns>Comentário que contém o ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentarioRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
