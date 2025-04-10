using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_Senaimanha.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Data de nascimento obrigatoria")]
        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Endereco obrigatorio")]
        public string? Endereco { get; set; }

        [Column(TypeName ="CHAR(11)")]
        [Required(ErrorMessage ="CPF obrigatorio")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Telefone obrigatorio")]
        public string? Telefone { get; set; }

        //referencia a tabela de usuario = FK
        [Required(ErrorMessage = "Usuario do paciente é obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
