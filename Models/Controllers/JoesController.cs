using Microsoft.AspNetCore.Mvc;
using GiJoeApi.Models;

namespace GiJoeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JoesController : ControllerBase
{
    private static List<Joe> joes = new();

    [HttpGet]
    public List<Joe> GetAllJoes()
    {
        return joes;
    }

    [HttpPost]
        public IActionResult AddJoe(Joe newJoe)
    {
        joes.Add(newJoe);
        return CreatedAtAction(
            nameof (GetJoeByName),
            new { name = newJoe.Name },
            newJoe
            );    
    }
    [HttpGet("{name}")]
   public ActionResult<Joe> GetJoeByName(string name)
    {
        var joe = joes.FirstOrDefault(j =>
        j.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (joe == null)
        {
            return NotFound();
        }
        return joe;
    }

    [HttpDelete("{name}")]
public IActionResult DeleteJoe(string name)
{
    var joe = joes.FirstOrDefault(j =>
        j.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (joe == null)
    {
        return NotFound($"Joe '{name}' not found.");
    }

    joes.Remove(joe);
 return Ok($"Joe '{name}' has been removed.");
}

[HttpPut("{name}")]
    public IActionResult UpdateJoe(string name, Joe updatedJoe)
{
    var joe = joes.FirstOrDefault(j =>
        j.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (joe == null)
    {
        return NotFound($"Joe '{name}' not found.");
    }

    joe.Name = updatedJoe.Name;
    joe.Specialty = updatedJoe.Specialty;

    return Ok(joe);
}
}