using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositorys;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class JogoController : Controller
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository= new JogoRepository();
        }


        /// <summary>
        /// EndPoint que aciona o método de cadastrar objeto(jogo)
        /// </summary>
        /// <param name="novoJogo">Objeto(jogo) que será cadastrado</param>
        /// <returns> 201 (Created)</returns>
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);
                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPonit que aciona método Listar Todos
        /// </summary>
        /// <returns>Lista de objetos(jogos)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               List<JogoDomain> ListaJogo = _jogoRepository.ListarTodos();

                return Ok(ListaJogo);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar objeto(jogo)
        /// </summary>
        /// <param name="id">ID do objeto(jogo) que será deletado</param>
        /// <returns>Status Code (204)</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

    }
}
