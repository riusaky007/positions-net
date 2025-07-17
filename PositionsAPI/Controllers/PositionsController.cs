using Microsoft.AspNetCore.Mvc;
using PositionsAPI.Models;
using PositionsAPI.Services;

namespace PositionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionsService _positionsService;

        public PositionsController(IPositionsService positionsService)
        {
            _positionsService = positionsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetAllPositions()
        {
            var positions = await _positionsService.GetAllPositions();
            return Ok(positions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPositionById(int id)
        {
            var position = await _positionsService.GetPositionById(id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }

        [HttpPost]
        public async Task<ActionResult<Position>> CreatePosition([FromBody] Position position)
        {
            try
            {
                var createdPosition = await _positionsService.CreatePosition(position);
                return CreatedAtAction(nameof(GetPositionById), new { id = createdPosition.PositionId }, createdPosition);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(int id, [FromBody] Position position)
        {
            if (id != position.PositionId)
            {
                return BadRequest("ID mismatch");
            }

            try
            {
                var updatedPosition = await _positionsService.UpdatePosition(position);
                return Ok(updatedPosition);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            var result = await _positionsService.DeletePosition(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}