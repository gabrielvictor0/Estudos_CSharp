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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro de médico
        /// </summary>
        /// <param name="medico">Médico que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);

                return Ok("Medico cadastrado com sucesso!");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar todos médicos
        /// </summary>
        /// <returns>Lista com todos médicos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.ListarTodos());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }


        /// <summary>
        /// EndPoint que aciona o método de listar médico por ID
        /// </summary>
        /// <param name="id">ID do médico que será listado</param>
        /// <returns>Médico que contém ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar método por ID
        /// </summary>
        /// <param name="medico">Médico atualizado</param>
        /// <param name="id">ID do médico que será atualizado</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Medico medico, Guid id)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);

                return Ok("Medico atualizado com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar médico por ID
        /// </summary>
        /// <param name="id">ID do médico que será deletado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);

                return Ok("Medico deletado com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }


    }
}
