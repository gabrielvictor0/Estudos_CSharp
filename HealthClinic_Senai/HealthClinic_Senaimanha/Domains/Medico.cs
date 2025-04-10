using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_Senaimanha.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="CRM obrigatorio")]
        public string? CRM { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Endereço é obrigatório")]
        public string? Endereco { get; set;}

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="CPF é obrigatório")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Telefone  é obrigatório")]
        public string? Telefone { get; set; }

        //FK

        [Required(ErrorMessage = "Informe a clinica do medico")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        [Required(ErrorMessage = "Usuario obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage ="Informe a especialidade do médico")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

    }
}
