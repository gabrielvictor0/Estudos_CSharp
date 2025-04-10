using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }


        [Required(ErrorMessage ="O nome do jogo é obrigatório!")]
        public string Nome { get; set; }

        public string Descricao { get; set; }


        [Required(ErrorMessage ="O valor do jogo é obrigatório!")]
        public double Valor { get; set; }


        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime DataLancamento { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}
