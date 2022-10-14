using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Allocations.Mvc.Models
{
    public class CreateTimeSheetViewModel
    {
        public int Id { get; set; }

        [DisplayName("Data dell'attività"), Required(ErrorMessage = "Data attività obbligatoria")]
        public DateTime StartActivity { get; set; }

        [DisplayName("Ore"), Required(ErrorMessage = "Ore obbligatorie")]
        public TimeSpan HourActivity { get; set; }

        [DisplayName("Dipendente"), Required(ErrorMessage = "Dipendente obbligatorio")]
        public int IdEmployee { get; set; }

        
        [DisplayName("Cliente"), Required(ErrorMessage = "Cliente obbligatorio")]
        public int IdCustomer { get; set; }

        [DisplayName("Attività"), Required(ErrorMessage = "Attività obbligatoria")]
        public int IdActivity { get; set; }

        [DisplayName("Commessa"), Required(ErrorMessage = "Commessa obbligatoria")]
        public int JobId { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        public IEnumerable<SelectListItem> Activities { get; set; }
        public IEnumerable<SelectListItem> Jobs { get; set; }

    }
}
