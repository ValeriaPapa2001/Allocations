using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Allocations.Mvc.Models.CustomerModel
{
    public class CustomerGridViewModel 
    {
            public int Id { get; set; }

            [Required]
            [DisplayName("Nome")]

            public string Name { get; set; }
            [Required]
            [DisplayName("Città")]

            public string City { get; set; }
            [Required]
            [DisplayName("Regione")]

            public string Region { get; set; }
            [Required]
            [DisplayName("Provincia")]

            public string Province { get; set; }
            [Required]
            [DisplayName("Dimensione")]

            public string Dimension { get; set; }

        }
    }



