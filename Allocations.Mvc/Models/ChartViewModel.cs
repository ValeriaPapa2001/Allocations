using Microsoft.AspNetCore.Mvc.Rendering;

namespace Allocations.Mvc.Models
{
    public class ChartViewModel
    {
        public int IdEmployee { get; set; }
        public List<SelectListItem> Employees;
    }

}
