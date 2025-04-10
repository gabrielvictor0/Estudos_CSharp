using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_Senaimanha.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email obrigatorio")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        //referencia a tabela TipoDeUsuario
        [Required(ErrorMessage ="Informe o tipo de usuario")]
        public Guid IdTipoDeUsuario { get; set; }

        [ForeignKey(nameof(IdTipoDeUsuario))]
        public TipoDeUsuario? TipoDeUsuario { get; set; }
    }
}
