using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Allocations.Mvc.Models
{
    public class EmployeeGridViewModel 
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Cognome")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Data di nascita")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("Mansione")]
        public string Role { get; set; }

    }
}
