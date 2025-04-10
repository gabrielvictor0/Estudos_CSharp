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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastrar paciente
        /// </summary>
        /// <param name="paciente">paciente que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return Ok("Paciente cadastrado com sucesso!");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        /// <summary>
        /// EndPoint que aciona o método de listar todos pacientes
        /// </summary>
        /// <returns>Lista com todos pacientes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.ListarTodos());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar paciente por ID
        /// </summary>
        /// <param name="id">ID do pacienteque será listado</param>
        /// <returns>Paciente que contém o ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById (Guid id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar paciente por ID
        /// </summary>
        /// <param name="id">ID do paciente que será atualizado</param>
        /// <param name="paciente">Paciente atualizado</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id,Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);

                return Ok("Paciente atualizado com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar paciente por ID
        /// </summary>
        /// <param name="id">ID do paciente que será deletado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);

                return Ok("Paciente deletado com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

    }
}
