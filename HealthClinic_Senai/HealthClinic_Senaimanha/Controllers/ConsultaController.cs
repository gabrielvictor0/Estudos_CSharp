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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastrar consulta
        /// </summary>
        /// <param name="consulta">Consulta que será cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize (Roles = "Administrador")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return Ok("Consulta cadastrada com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar todas consultas
        /// </summary>
        /// <returns>Lista com todas consultas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.ListarTodos());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de listar consultas por ID
        /// </summary>
        /// <param name="id">ID da consulta buscada</param>
        /// <returns>Consulta que contém o ID buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de atualizar consulta por ID
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consulta">Consulta atualizada</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);

                return Ok("Consulta atualizada com sucesso!");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            } 
        }

        /// <summary>
        /// EndPoint que aciona o método de deletar consulta por ID
        /// </summary>
        /// <param name="id">ID da consulta buscada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);

                return Ok("Consulta deletada com sucesso");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
