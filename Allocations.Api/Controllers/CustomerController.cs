using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allocations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerBL _logic;
        public CustomerController(ICustomerBL logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Customer>))]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await _logic.GetAllCustomersAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _logic.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound("Customer not found");
            return Ok(customer);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> InsertCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null");
            }
            var result = await _logic.InsertCustomerAsync(customer);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot insert customer: {result.Message}");
            }
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null");
            }
            if (id != customer.Id)
            {
                return BadRequest("Customer's ids don't matcht");
            }

            var result = await _logic.UpdateCustomerAsync(customer);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot update customer: {result.Message}");
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            var result = await _logic.DeleteCustomerAsync(id);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot delete customer: {result.Message}");

            }
            return Ok();
        }

    }
}
