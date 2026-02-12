using Microsoft.AspNetCore.Mvc;
using GiJoeApi.Models;
using GiJoeApi.Services;

namespace GiJoeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JoesController : ControllerBase
    {
        private readonly GiJoeService _giJoeService;

        public JoesController(GiJoeService giJoeService)
        {
            _giJoeService = giJoeService;
        }

        [HttpGet]
        public IActionResult GetAllJoes()
        {
            var joes = _giJoeService.GetAll();
            return Ok("Yo Joe!");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetJoeById(int id)
        {
            return Ok($"Joe #{id}");
        }

        [HttpGet("by-name/{name}")]
        public ActionResult<Joe> GetJoeByName(string name)
        {
            var joe = _giJoeService.GetByName(name);

            if (joe == null)
            {
                return NotFound();
            }

            return Ok(joe);
        }

        [HttpPost]
        public IActionResult AddJoe(Joe newJoe)
        {
            _giJoeService.Add(newJoe);

            return CreatedAtAction(
                nameof(GetJoeByName),
                new { name = newJoe.Name },
                newJoe
            );
        }

        [HttpPut("{name}")]
        public IActionResult UpdateJoe(string name, Joe updatedJoe)
        {
            var success = _giJoeService.Update(name, updatedJoe);

            if (!success)
            {
                return NotFound($"Joe '{name}' not found.");
            }

            return Ok($"Joe '{name}' has been updated.");
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteJoe(string name)
        {
            var success = _giJoeService.Delete(name);

            if (!success)
            {
                return NotFound($"Joe '{name}' not found.");
            }

            return Ok($"Joe '{name}' has been removed.");
        }

        [HttpGet("external")]
        public async Task<ActionResult<List<Joe>>> GetExternalJoes()
        {
            var joes = await _giJoeService.GetExternalJoesAsync();
            return Ok(joes);
        }
    }
}
