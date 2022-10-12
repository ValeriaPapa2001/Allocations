using Allocations.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Allocations.Mvc.Models
{
    public class EditEmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName ("Nome"), Required (ErrorMessage = "Nome obbligatorio")]
        public string FirstName { get; set; }
        [DisplayName("Cognome"), Required(ErrorMessage = "Cognome obbligatorio")]

        public string LastName { get; set; }
        [DisplayName("Email"), Required(ErrorMessage = "Email obbligatorio")]
        [EmailAddress(ErrorMessage = "Email non valida")]
        public string Email { get; set; }
        [DisplayName("Data di nascita"), Required(ErrorMessage = "Data di nascita obbligatoria")]
        
        public DateTime BirthDate { get; set; }
        [DisplayName("Data inizio professione"), Required(ErrorMessage = "Data inizio professione obbligatoria")]

        public DateTime StartDate { get; set; }
        [DisplayName("Costo orario"), Required(ErrorMessage = "Costo orario obbligatorio")]

        public decimal HourCost { get; set; }

        [DisplayName("Mansione"), Required(ErrorMessage = "Mansione obbligatoria")]
        public int IdRole { get; set; }
        public IEnumerable<SelectListItem> Roles;
    }
}
