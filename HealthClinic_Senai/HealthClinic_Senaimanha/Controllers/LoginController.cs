using HealthClinic_Senaimanha.Domains;
using HealthClinic_Senaimanha.Interfaces;
using HealthClinic_Senaimanha.Repositories;
using HealthClinic_Senaimanha.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HealthClinic_Senaimanha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método de login, buscando email e senha do usuário
        /// </summary>
        /// <param name="usuario">Email e Senha do usuário</param>
        /// <returns>Token do usuário</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.LoginEmailSenha(usuario.Email!, usuario.Senha!);

                if(usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha inválidos!");
                }

                //Lógica do token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role,usuarioBuscado.TipoDeUsuario!.Nome!)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-health-clinic-senai-manha"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "HealthClinic_Senaimanha",
                        audience: "HealthClinic_Senaimanha",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: creds
                        );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
