using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiJoeApi.Data;
using GiJoeApi.Models;

namespace GiJoeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JoesController(AppDbContext context)
        {
            _context = context;
        }

       [HttpGet]
        public async Task<IActionResult> GetAllJoes([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
       {
         var totalCount = await _context.Characters.CountAsync();

         var joes = await _context.Characters
           .Skip((page - 1) * pageSize)
           .Take(pageSize)
           .ToListAsync();

           return Ok(new
         {
           totalCount,
           page,
           pageSize,
           data = joes
         });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJoeById(int id)
        {
            var joe = await _context.Characters.FindAsync(id);

            if (joe == null) return NotFound();

            return Ok(joe);
        }

        [HttpPost]
        public async Task<IActionResult> AddJoe(Character newJoe)
        {
        var exists = await _context.Characters
           .AnyAsync(c => c.Name.ToLower() == newJoe.Name.ToLower());
 
         if (exists)
        {
           return BadRequest("Character already exists.");
        }

            _context.Characters.Add(newJoe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJoeById), new { id = newJoe.Id }, newJoe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJoe(int id, Character updatedJoe)
        {
            var existingJoe = await _context.Characters.FindAsync(id);

            if (existingJoe == null)
            {
              return NotFound();
            }  

            existingJoe.Name = updatedJoe.Name;
            existingJoe.PlaceOfBirth = updatedJoe.PlaceOfBirth;
            existingJoe.Specialty = updatedJoe.Specialty;

            await _context.SaveChangesAsync();

            return Ok(existingJoe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoe(int id)
        {
            var joe = await _context.Characters.FindAsync(id);

            if (joe == null) 
            {
                return NotFound();
            }
            _context.Characters.Remove(joe);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
           var results = await _context.Characters
              .Where(c => c.Name.ToLower().Contains(name.ToLower()))
              .ToListAsync();

            if (results.Count == 0)
            {
              return NotFound("No characters found.");
            }

              return Ok(results);
        }
        [HttpGet("specialty/{specialty}")]
        public async Task<IActionResult> GetBySpecialty(string specialty)
        {
            var results = await _context.Characters
              .Where(c => c.Specialty.ToLower() == specialty.ToLower())
              .ToListAsync();

            if (!results.Any())
            {
              return NotFound("No characters found with that specialty.");
            }

              return Ok(results);
        }
    }
}