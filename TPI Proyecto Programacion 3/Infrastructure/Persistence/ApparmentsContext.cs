using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppartmentsContext: DbContext
    {
        public AppartmentsContext(DbContextOptions<BuildingsContext> options) : base(options) { }
    
        public DbSet<Appartment> Appartments { get; set; }
    }
}
