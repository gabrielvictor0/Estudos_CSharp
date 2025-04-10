using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do jogo é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage ="Descricao do jogo obrigatorio!")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage ="Data lancamento obrigatorio!")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName ="Decima(4,2)" )]
        [Required(ErrorMessage = "Preco do jogo obrigatorio!")]
        public decimal Preco { get; set; }

        //referencia da chave estrangeira (tabela de estudio)

        [Required(ErrorMessage ="Informe o estudio que produziu o jogo")]
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio Estudio { get; set; }
    }
}
