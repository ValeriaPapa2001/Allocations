using Allocations.Api.Models;
using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using Microsoft.AspNetCore.Mvc;

namespace Allocations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _logic;
        public UserController(IUserBL logic)
        {
            _logic = logic;
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _logic.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _logic.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CudResult))]
        public async Task<IActionResult> CheckLogin([FromBody] UserModel model)
        {
            var result = await _logic.CheckLoginAsync(model.Email, model.Password);
            return Ok(result);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            var result = await _logic.RegisterNewAccount(model.Email, model.Password);
            if (result.Success)
            {
                var user = await _logic.GetUserByEmailAsync(model.Email);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);

        }
    }
}
