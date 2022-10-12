using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Allocations.Mvc.Models
{
    public class LoginViewModel
    {
        [DisplayName("Email"), Required(ErrorMessage = "Email obbligatoria")]
        [EmailAddress(ErrorMessage = "Formato non valido")]
        public string Email { get; set; }
        [DisplayName("Password"), Required(ErrorMessage = "Password obbligatoria")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
