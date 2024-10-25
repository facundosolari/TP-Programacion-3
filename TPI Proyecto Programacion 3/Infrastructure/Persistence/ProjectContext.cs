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
    public DbSet<Admin> Admins { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Appartment> Appartments { get; set; }
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relación Owner -> Buildings (One-to-Many)
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Buildings)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId)
            .OnDelete(DeleteBehavior.Cascade); // Si se elimina el Owner, también se eliminan los edificios.

        // Relación Building -> Appartments (One-to-Many)
        modelBuilder.Entity<Building>()
            .HasMany(b => b.Appartments)
            .WithOne(a => a.Building)
            .HasForeignKey(a => a.BuildingId)
            .OnDelete(DeleteBehavior.Cascade); // Si se elimina el Building, también se eliminan los departamentos.

        // Relación Appartment -> Tenant (One-to-One)
        modelBuilder.Entity<Appartment>()
            .HasOne(a => a.Tenant)
            .WithOne(t => t.Appartment)
            .HasForeignKey<Appartment>(a => a.TenantId)
            .OnDelete(DeleteBehavior.SetNull); // Si se elimina el Tenant, el departamento no se elimina, pero el TenantId queda en null.

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        // Identificar departamentos (Appartments) que pierden a su Tenant
        var apartmentsWithoutTenant = ChangeTracker.Entries<Appartment>()
            .Where(e => e.State == EntityState.Modified && e.Entity.TenantId == null);

        // Actualizar la propiedad IsAvailable a true en estos Appartments
        foreach (var entry in apartmentsWithoutTenant)
        {
            entry.Entity.IsAvailable = true;
        }

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var apartmentsWithoutTenant = ChangeTracker.Entries<Appartment>()
            .Where(e => e.State == EntityState.Modified && e.Entity.TenantId == null);

        foreach (var entry in apartmentsWithoutTenant)
        {
            entry.Entity.IsAvailable = true;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

}
