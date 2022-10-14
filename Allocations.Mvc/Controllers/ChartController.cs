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
            ChartModel model = new ChartModel
            {
                Employees = list
            };
            return View(model);
        }

        public async Task<IActionResult> ActivityChart(int id)
        {
            var timeSheets = (await _client.GetMonthlyTimesheetByEmployeeId(id)).GroupBy(x => x.IdActivity);
            IList<ChartModel> list = new List<ChartModel>();
            foreach (var t in timeSheets)
            {
                list.Add(new AxisChartModel { x = t.Key, y = t.Sum(x => x.HourActivity) });
            }
            return PartialView("_ActivityChart", list);

        }

        public async Task<IActionResult> ChartByCustomer(int id)
        {
            var timesheets = (await _client.GetMonthlyTimesheetByEmployeeId(id)).GroupBy(x => x.Customer.Name);
            IList<ChartModel> list = new List<ChartModel>();
            foreach (var t in timesheets)
            {
                list.Add(new AxisChartModel { x = t.Key, y = t.Sum(x => x.HourActivity) });
            }
            return PartialView("_ChartByCustomer", list);
        }
    }

}

