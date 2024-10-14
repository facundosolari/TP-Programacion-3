using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class OwnerDbContext : DbContext
{
    public OwnerDbContext(DbContextOptions<OwnerDbContext> options) : base(options) { }

    public DbSet<Owner> Owners { get; set; }
}
