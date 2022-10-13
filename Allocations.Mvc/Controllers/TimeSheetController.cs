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

    }
}