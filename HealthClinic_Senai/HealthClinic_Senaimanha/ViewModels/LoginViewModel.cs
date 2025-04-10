using System.ComponentModel.DataAnnotations;

namespace HealthClinic_Senaimanha.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O email do usuário é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="A senha do usuário é obrigatória!")]
        public string? Senha { get; set; }
    }
}
