using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allocations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobBL _logic;
        public JobController(IJobBL logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Job>))]
        public async Task<IActionResult> GetAllJobs()
        {
            return Ok(await _logic.GetAllJobsAsync());
        }
    }
    
}
