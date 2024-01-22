using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_DotNet8.Entities;

namespace DotNet8.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuperHeroController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
    {
        var heroes = new List<SuperHero>(){
            new SuperHero {
                Id = 1,
                Name = "Spiderman",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            }
        };
        return Ok(heroes);
    }
}