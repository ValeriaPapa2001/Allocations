using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Allocations.Mvc.Models.CustomerModel
{
    public class EditCustomerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nome"), Required(ErrorMessage = "Nome obbligatorio")]
        public string Name { get; set; }
        [DisplayName("Città"), Required(ErrorMessage = "Città obbligatorio")]

        public string City { get; set; }
        [DisplayName("Regione"), Required(ErrorMessage = "Regione obbligatoria")]

        public string Region { get; set; }
        [DisplayName("Provincia"), Required(ErrorMessage = "Provincia obbligatoria")]

        public string District { get; set; }
        [DisplayName("Dimensione"), Required(ErrorMessage = "Dimensione obbligatoria")]
        public string Dimension { get; set; }
    }
}
       