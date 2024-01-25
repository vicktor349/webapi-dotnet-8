using DotNet8.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Entities;

namespace DotNet8.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuperHeroController : ControllerBase
{

    private readonly DataContext _context;

    public SuperHeroController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();
        return Ok(heroes);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
        {
            return NotFound("Hero Not Found");
        }
        return Ok(hero);
    }
    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        return Ok(await _context.SuperHeroes.ToListAsync());
    }
    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
    {
        var dbHero = await _context.SuperHeroes.FindAsync(updatedHero.Id);
        if (dbHero is null)
        {
            return NotFound("Hero Not Found");
        }
        dbHero.Name = updatedHero.Name;
        dbHero.FirstName = updatedHero.FirstName;
        dbHero.LastName = updatedHero.LastName;
        dbHero.Place = updatedHero.Place;

        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }
    [HttpDelete]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
    {
        var dbHero = await _context.SuperHeroes.FindAsync(id);
        if (dbHero is null)
        {
            return NotFound("Hero Not Found");
        }

        _context.SuperHeroes.Remove(dbHero);
        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }
}