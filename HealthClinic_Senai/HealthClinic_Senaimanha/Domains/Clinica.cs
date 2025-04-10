using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_Senaimanha.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    [Index(nameof(RazaoSocial), IsUnique = true)]
    public class Clinica
    {

        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Endereço é obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome fantasia  é obrigatório")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName ="CHAR(14)")]
        [Required(ErrorMessage ="CNPJ obrigatorio")]
        public string? CNPJ { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan? HorarioAbertura { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan? HorarioFechamento { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Razao Social obrigatorio")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Telefone obrigatorio")]
        public string? Telefone { get; set; }

    }
}
