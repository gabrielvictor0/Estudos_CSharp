using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_Senaimanha.Domains
{
    [Table(nameof(TipoDeUsuario))]
    public class TipoDeUsuario
    {
        [Key]
        public Guid IdTipoDeUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Nome obrigatorio")]
        public string? Nome { get; set; }
    }
}
