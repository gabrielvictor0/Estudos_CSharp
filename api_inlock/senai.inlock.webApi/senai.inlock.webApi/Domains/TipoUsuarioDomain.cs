using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage ="O titulo do tipo de usuario é obrigatório!")]
        public string Titulo { get; set; }
    }
}
