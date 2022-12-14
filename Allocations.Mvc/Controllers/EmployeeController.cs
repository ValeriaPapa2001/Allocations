using Allocations.Mvc.Utils;
using Microsoft.AspNetCore.Mvc;
using Allocations.Mvc.Models;
using Allocations.Mvc.DataContracts;
using Allocations.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Allocations.Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApiClient _client;
        public EmployeeController(ApiClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _client.GetAllEmployees();
            var model = employees.Select(l => new EmployeeGridViewModel
            {
                FirstName = l.FirstName,
                LastName = l.LastName,
                Email = l.Email,
                BirthDate = l.BirthDate,
                Role = null,
            });
            return View(model);

        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _client.GetEmployee(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            DeleteEmployeeViewModel model = new DeleteEmployeeViewModel
            {
                Id = id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
            };
            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(DeleteEmployeeViewModel employee)
        {
            var result = await _client.DeleteEmployee(employee.Id);
            if (result)
            {
                return Json(new
                {
                    Success = true,
                });
            }
            return Json(new { Success = false, Message = "Impossibile eliminare il dipendente" });
            return View(employee);
        }

        public async Task<IActionResult> Create()
        {
            CreateEmployeeViewModel model = new CreateEmployeeViewModel();
            /*Da implementare*/
            return View(model);
        }

        //Da controllare l'implementazione del Details
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _client.GetEmployee(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            var model = new DetailsEmployeeViewModel
            {
                Id = id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                StartDate = employee.StartDate,
                Email = employee.Email,
                Role = employee.IdRole.ToString(),
                HourCost = employee.HourCost,

            };
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employees = await _client.GetEmployee(id);
            if (employees == null)
            {
                return RedirectToAction("Index");
            }

            EditEmployeeViewModel model = new EditEmployeeViewModel
            {
                Id = employees.Id,
                FirstName = employees.FirstName,
                LastName = employees.LastName,
                BirthDate = employees.BirthDate,
                StartDate = employees.StartDate,
                Email = employees.Email,
                IdRole = employees.IdRole,
                HourCost = employees.HourCost,

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = await _client.GetEmployee(model.Id);
                if (employee == null)
                {
                    return RedirectToAction("Index");
                }
               
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.BirthDate = model.BirthDate;
                employee.StartDate = model.StartDate;
                employee.Email = model.Email;
                employee.IdRole = model.IdRole;
                employee.HourCost = model.HourCost;
                
                
                var result = await _client.UpdateEmployee(employee);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Impossibile aggiornare il dipendente");
                }
            }
            return View(model);
        }
        //MENU A TENDINA
        //da controllare
        //identico per Activity e Job 
        private async Task<IEnumerable<SelectListItem>> BuildRole()
        {
            IEnumerable<Role> roles = await _client.GetAllRoles();
            var roleItems = roles.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            }).ToList();
            roleItems.Insert(0, new SelectListItem("Scegliere la mansione: ", ""));
            return roleItems;
        }

    }
}