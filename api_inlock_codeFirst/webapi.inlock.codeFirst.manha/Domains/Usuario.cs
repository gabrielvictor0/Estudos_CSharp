using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Senha obrigatoria!")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 200 caracteres")]
        public string? Senha { get; set; }

        //Referencia da chave estrangeira (Tabela de TipoUsuario)

        [Required(ErrorMessage ="Tipo do usuario obrigatorio!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
