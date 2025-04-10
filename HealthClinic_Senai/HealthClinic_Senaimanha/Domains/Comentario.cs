using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_Senaimanha.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; }

        [Column(TypeName ="VARCHAR(300)")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        public bool Exibir {  get; set; }

        [Required(ErrorMessage ="Consulta é obrigatório")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }



    }
}
