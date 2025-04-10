using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;
using HealthClinic_Senaimanha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_Senaimanha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro de Especialidade
        /// </summary>
        /// <param name="especialidade">Especialidade que será cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);

                return Ok("Especialidade cadastrada com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar todas especialidades
        /// </summary>
        /// <returns>Lista com todas especialidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeRepository.ListarTodas());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar especialidade por ID
        /// </summary>
        /// <param name="especialidade">Especialidade atualizada</param>
        /// <param name="id">ID da especialidade que será atualizada</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Especialidade especialidade, Guid id)
        {
            try
            {
                _especialidadeRepository.Atualizar(id, especialidade);

                return Ok("Especialidade atualizad com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar especialidade por ID
        /// </summary>
        /// <param name="id">ID da especialidade que será deletada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);

                return Ok("Especialidade deletada com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
