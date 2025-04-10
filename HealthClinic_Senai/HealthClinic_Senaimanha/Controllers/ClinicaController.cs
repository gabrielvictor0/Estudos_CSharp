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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro de clinica
        /// </summary>
        /// <param name="novaClinica">Clinica que será cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return Ok("Clinica cadastrada!");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar clinica por ID
        /// </summary>
        /// <param name="id">ID da clinica atualizada</param>
        /// <param name="clinica">Clinica atualizada</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Clinica clinica)
        {
            try
            {
                _clinicaRepository.Atualizar(id, clinica);

                return Ok("Clinica atualizada");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar clinica por ID
        /// </summary>
        /// <param name="id">ID da clinica buscada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);

                return Ok("Clinica deletada com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar todas clinicas
        /// </summary>
        /// <returns>Lista com todas clinicas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clinicaRepository.ListarTodos());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

    }
}
