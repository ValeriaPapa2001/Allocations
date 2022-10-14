using Allocations.Core.BusinnessLogic;
using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allocations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TimeSheetController: ControllerBase
    {
        private readonly ITimeSheetBL _logic;
        public TimeSheetController(ITimeSheetBL logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TimeSheet>))]
        public async Task<IActionResult> GetAllTimeSheets()
        {
            return Ok(await _logic.GetAllTimeSheetsAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeSheet))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetTimeSheetById(int id)
        {
            var timeSheet = await _logic.GetTimeSheetsByIdAsync(id);
            if (timeSheet == null)
                return NotFound("TimeSheet not found");
            return Ok(timeSheet);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TimeSheet))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> InsertTimeSheet([FromBody] TimeSheet timeSheet)
        {
            if (timeSheet == null)
            {
                return BadRequest("TimeSheet is null");
            }
            var result = await _logic.InsertTimeSheetAsync(timeSheet);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot insert timeSheet: {result.Message}");
            }
            return CreatedAtAction(nameof(GetTimeSheetById), new { id = timeSheet.Id }, timeSheet);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeSheet))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> UpdateTimeSheet(int id, [FromBody] TimeSheet timeSheet)
        {
            if (timeSheet == null)
            {
                return BadRequest("TimeSheet is null");
            }
            if (id != timeSheet.Id)
            {
                return BadRequest("TimeSheet's ids don't matcht");
            }

            var result = await _logic.UpdateTimeSheetAsync(timeSheet);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot update timeSheet: {result.Message}");
            }
            return Ok(timeSheet);
        }

        [HttpGet]
        [Route("details")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TimeSheet>))]
        public async Task<IActionResult> GetAllTimesheetsDetailed()
        {
            return Ok(await _logic.GetAllTimeSheetsDetailedAsync());
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeSheet))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetailedTimesheet(int id)
        {
            TimeSheet tim = await _logic.GetTimeSheetDetailedAsync(id);
            if (tim == null)
                return NotFound();
            return Ok(tim);
        }




        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        //public async Task<IActionResult> DeleteTimeSheet(int id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest("Id is null");
        //    }
        //    var result = await _logic.DeleteTimeSheetAsync(id);
        //    if (!result.Success)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"Cannot delete timeSheet: {result.Message}");

        //    }
        //    return Ok();
        //}
    }
}
