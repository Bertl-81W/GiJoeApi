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
    public void AddJoe(Joe newJoe)
    {
        joes.Add(newJoe);
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
}