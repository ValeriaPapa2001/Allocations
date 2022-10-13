using Allocations.Mvc.Models;
using Allocations.Mvc.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Allocations.Mvc.Controllers
{
    public class TimesheetsController : Controller
    {
        private ApiClient _client;

        public TimesheetsController(ApiClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var timesheets = await _client.GetAllTimeSheets();
            var models = timesheets.Select(x => new TimeSheetGridViewModel
            {
                Id = x.Id,
                EmployeeName = x.Employee.FirstName + x.Employee.LastName,
                StartActivity = x.StartActivity,
                HourActivity = x.HourActivity, //da vedere la questione del decimal
                ActivityName = x.Activity.Description,
                JobName = x.Job.Description,
                CustomerName = x.Customer.Name,
            });

            return View(models);
        }



    }
}