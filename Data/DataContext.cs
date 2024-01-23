using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Entities;

namespace DotNet8.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
}