
using System.ComponentModel.DataAnnotations;

namespace IdentityApp_.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {

        }
        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
        [EmailAddress]
        [Display(Name = "Emaili ")]
        [Required(ErrorMessage = "Email Boş olmamalıdır")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifrə boş olmamalıdır")]
        [Display(Name = "Parol")]
        [DataType(DataType.Password)]
        [MinLength(length: 6, ErrorMessage = $"Şifrə minimum 6 simvol olmalıdır")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
