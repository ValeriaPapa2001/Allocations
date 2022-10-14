using Allocations.Mvc.Models;
using Allocations.Mvc.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Allocations.Mvc.Controllers
{
    public class ChartController : Controller
    {
        private readonly ChartClient _client;

        public ChartController(ChartClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Chart()
        {
            var employee = await _client.GetEmployees();
            var list = new List<SelectListItem>();
            foreach (var e in employee)
            {
                list.Add(new SelectListItem { Text = e.FirstName + " " + e.LastName, Value = e.EmployeeId.ToString() });
            }
            ChartViewModel model = new ChartViewModel
            {
                Employees = list
            };
            return View(model);
        }

        
        }

    }
}

        