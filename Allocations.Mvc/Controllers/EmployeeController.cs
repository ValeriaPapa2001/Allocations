using Allocations.Mvc.Utils;
using Microsoft.AspNetCore.Mvc;
using Allocations.Mvc.Models;

namespace Allocations.Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApiClient _client;
        public EmployeeController(ApiClient client)
        {
            _client = client;
        }

    }
}