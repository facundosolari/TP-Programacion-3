using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Infrastructure.Persistence;

public class ProjectContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Appartment> Appartments { get; set; }
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar la herencia de User
        modelBuilder.Entity<User>()
            .HasDiscriminator<UserType>("UserType")
            .HasValue<Owner>(UserType.Owner)
            .HasValue<Tenant>(UserType.Tenant)
            .HasValue<Admin>(UserType.Admin);

        // Configuración para Owner y su lista de Buildings
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Property)
            .WithOne()
            .HasForeignKey(b => b.OwnerId);

        // Configuración para Building y su lista de Appartments
        modelBuilder.Entity<Building>()
            .HasMany(b => b.Appartments)
            .WithOne()
            .HasForeignKey(a => a.BuildingId);

        // Configuración para Appartment y su Tenant
        modelBuilder.Entity<Appartment>()
            .HasOne(a => a.Tenant)
            .WithOne()
            .HasForeignKey<Appartment>(a => a.TenantId);

        // Configuración para la tabla de Users, Buildings y Appartments
        modelBuilder.Entity<User>()
            .ToTable("Users");

        modelBuilder.Entity<Building>()
            .ToTable("Buildings");

        modelBuilder.Entity<Appartment>()
            .ToTable("Appartments");

        base.OnModelCreating(modelBuilder);
    }
    */
}
