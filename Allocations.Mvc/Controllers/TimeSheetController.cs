using Allocations.Core.Entities;
using Allocations.Mvc.DataContracts;
using Allocations.Mvc.Models;
using Allocations.Mvc.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Allocations.Mvc.Controllers
{
    public class TimesheetsController : Controller
    {
        private ApiClient _client;
        private WcfClient _client1;

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

        public async Task<IActionResult> Create()
        {
            CreateTimeSheetViewModel model = new CreateTimeSheetViewModel();
            model.Employees = await GetEmployeeBySelection();
            model.Activities = await GetActivityBySelection();
            model.Customers = await GetCustomerBySelection();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTimeSheetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeSheet = new TimeSheetContract
                {
                    Id = model.Id,
                    IdEmployee = model.IdEmployee,
                    IdJob = model.JobId,
                    IdActivity = model.IdActivity,
                    StartActivity = model.StartActivity,
                    HourActivity = model.HourActivity
                };
                bool result = await _client.InsertTimeSheet(timeSheet);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Impossibile inserire il nuovo timesheet.");
                }
            }
            model.Employees = await GetEmployeeBySelection();
            model.Activities = await GetActivityBySelection();
            model.Customers = await GetCustomerBySelection();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var timeSheet = await _client.GetTimeSheet(id);
            if (timeSheet == null)
            {
                return RedirectToAction("Index");
            }

            EditTimeSheetViewModel model = new EditTimeSheetViewModel
            {
                Id = timeSheet.Id,
                StartActivity = timeSheet.StartActivity,
                IdActivity = timeSheet.IdActivity,
                HourActivity = timeSheet.HourActivity,
                JobId = timeSheet.IdJob,
                IdEmployee = timeSheet.IdEmployee,

            };
            model.Employees = await GetEmployeeBySelection();
            model.Activities = await GetActivityBySelection();
            model.Customers = await GetCustomerBySelection();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTimeSheetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeSheet = await _client.GetTimeSheet(model.Id);
                if (timeSheet == null)
                {
                    return RedirectToAction("Index");
                }

                timeSheet.IdEmployee = model.IdEmployee;
                timeSheet.Id = model.Id;
                timeSheet.StartActivity = model.StartActivity;
                timeSheet.IdActivity = model.IdActivity;
                timeSheet.HourActivity = model.HourActivity;
                timeSheet.IdJob = model.JobId;

                var result = await _client.UpdateTimeSheet(timeSheet);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Impossibile aggiornare il timesheet");
                }
            }
            model.Employees = await GetEmployeeBySelection();
            model.Activities = await GetActivityBySelection();
            model.Customers = await GetCustomerBySelection();
            return View(model);
        }

        private async Task<IEnumerable<SelectListItem>> GetEmployeeBySelection()
        {
            IEnumerable<EmployeeContract> employees = await _client.GetAllEmployees();
            var items = employees.Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString()
            }).ToList();
            items.Insert(0, new SelectListItem("Seleziona", ""));
            return items;

        }
        private async Task<IEnumerable<SelectListItem>> GetActivityBySelection()
        {

            IEnumerable<ActivityContract> activities = await _client.GetAllActivities();
            var item = activities.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            }).ToList();
            item.Insert(0, new SelectListItem("Seleziona", ""));
            return item;
        }

        private async Task<IEnumerable<SelectListItem>> GetCustomerBySelection()
        {
            IEnumerable<Customer> customers = await _client1.GetAllCustomers();
            var items = customers.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            items.Insert(0, new SelectListItem("Seleziona", ""));
            return items;

        }



    }
}



