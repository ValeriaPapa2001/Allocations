using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allocations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBL _logic;
        public ActivityController(IActivityBL logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Activity>))]
        public async Task<IActionResult> GetAllActivities()
        {
            return Ok(await _logic.GetAllActivitiesAsync());
        }
    }
    
}
