using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class ProjectDB : DbContext
{
    public ProjectDB(DbContextOptions<ProjectDB> options) : base(options)
    {

    }

  

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Appartment> Appartments { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Owner>()
    //        .HasKey(o => o.Id);

    //    modelBuilder.Entity<Owner>()
    //        .Property(o => o.Id)
    //        .ValueGeneratedOnAdd();
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        // Este es un ejemplo de cómo configurar SQLite. Asegúrate de que esta línea no se ejecute cuando
    //        // uses el servicio en tu aplicación.
    //        optionsBuilder.UseSqlite("Data Source=ProjectDB.db");
    //    }
    //}
}
