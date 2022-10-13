using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Allocations.Mvc.Models
{
    public class CreateTimeSheetViewModel
    {
        public int TimesheetId { get; set; }

        [DisplayName("Data dell'attività"), Required(ErrorMessage = "Data attività obbligatoria")]
        public DateTime StartActivity { get; set; }

        [DisplayName("Ore"), Required(ErrorMessage = "Ore obbligatorie")]
        public decimal HourActivity { get; set; }

        [DisplayName("Dipendente"), Required(ErrorMessage = "Dipendente obbligatorio")]
        public int EmployeeId { get; set; }

        
        [DisplayName("Cliente"), Required(ErrorMessage = "Cliente obbligatorio")]
        public int CustomerId { get; set; }

        [DisplayName("Attività"), Required(ErrorMessage = "Attività obbligatoria")]
        public string ActivityName { get; set; }

        [DisplayName("Commessa"), Required(ErrorMessage = "Commessa obbligatoria")]
        public int JobId { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        public IEnumerable<SelectListItem> Activities { get; set; }
        public IEnumerable<SelectListItem> Job { get; set; }

    }
}
