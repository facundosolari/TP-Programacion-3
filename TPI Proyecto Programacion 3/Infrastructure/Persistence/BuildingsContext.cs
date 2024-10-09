using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class BuildingsContext : DbContext
{
    public BuildingsContext(DbContextOptions<BuildingsContext> options) : base(options) { }

    public DbSet<Building> Buildings { get; set; }
}