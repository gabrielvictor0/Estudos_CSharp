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
    public class TipoDeUsuarioController : ControllerBase
    {
        private ITipoDeUsuario _tipoDeUsuarioRepository;

        public TipoDeUsuarioController()
        {
            _tipoDeUsuarioRepository = new TipoDeUsuarioRepository();  
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastrar tipo de usuario
        /// </summary>
        /// <param name="tipoDeUsuario">Tipo de usuario que será cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoDeUsuario tipoDeUsuario)
        {
            try
            {
                _tipoDeUsuarioRepository.Cadastrar(tipoDeUsuario);

                return Ok("Tipo de usuario cadastrado com sucesso!");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
