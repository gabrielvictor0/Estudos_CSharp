using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage ="O Email do usuário é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        public string Senha { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
