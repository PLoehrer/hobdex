using Hobdex.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hobdex.Api.Data;

public class HobdexDbContext : DbContext
{
    public HobdexDbContext(DbContextOptions<HobdexDbContext> options) : base(options) { }

    public DbSet<Hobby> Hobbies => Set<Hobby>();
}