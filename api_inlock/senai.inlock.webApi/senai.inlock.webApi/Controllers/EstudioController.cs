using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositorys;

namespace senai.inlock.webApi_.Controllers
{
        [Route("api/[controller]")]

        [ApiController]

        [Produces("application/json")]
    public class EstudioController : Controller
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastrar estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto(estudio) que será cadastrado</param>
        /// <returns>Status Code(204)</returns>
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        /// <summary>
        /// EndPoint que aciona o método de deletar estudio
        /// </summary>
        /// <param name="id">ID do estudio que será deletado</param>
        /// <returns> Status Code(204)</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar estudio
        /// </summary>
        /// <returns>retorna uma lista do objeto estudio</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> ListaEstudio = _estudioRepository.ListarTodos();

                return Ok(ListaEstudio);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
               
        }

        
    }
}

