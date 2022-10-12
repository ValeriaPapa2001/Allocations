using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allocations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL _logic;
        public EmployeeController(IEmployeeBL logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _logic.GetAllEmployeesAlphabeticOrderAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _logic.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound("Employee not found");
            return Ok(employee);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }
            var result = await _logic.InsertEmployeeAsync(employee);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot insert employee: {result.Message}");
            }
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }
            if (id != employee.Id)
            {
                return BadRequest("Employee's ids don't matcht");
            }

            var result = await _logic.UpdateEmployeeAsync(employee);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot update employee: {result.Message}");
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            var result = await _logic.DeleteEmployeeAsync(id);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot delete employee: {result.Message}");

            }
            return Ok();
        }


    }
}
