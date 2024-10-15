using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class ProjectContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Appartment> Appartments { get; set; }

    private readonly bool isTestingEnviroment;
    public ProjectContext(DbContextOptions<ProjectContext> options, bool isTestingEnviroment = false) : base(options)
    {
        this.isTestingEnviroment = isTestingEnviroment;
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Owner>()
    //        .HasKey(o => o.Id);

    //    modelBuilder.Entity<Owner>()
    //        .Property(o => o.Id)
    //        .ValueGeneratedOnAdd();
    //}

}
