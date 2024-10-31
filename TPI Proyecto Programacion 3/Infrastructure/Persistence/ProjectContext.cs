using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ProjectContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Appartment> Appartments { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Buildings)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Building>()
            .HasMany(b => b.Appartments)
            .WithOne(a => a.Building)
            .HasForeignKey(a => a.BuildingId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appartment>()
            .HasOne(a => a.Tenant)
            .WithOne(t => t.Appartment)
            .HasForeignKey<Tenant>(t => t.AppartmentId) 
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Appartment)
            .WithMany()
            .HasForeignKey(r => r.AppartmentID);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Tenant)
            .WithMany()
            .HasForeignKey(r => r.TenantID);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.Appartment)
            .WithMany(a => a.Ratings) 
            .HasForeignKey(r => r.AppartmentId) 
            .OnDelete(DeleteBehavior.Cascade); 

        base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        var apartmentsWithoutTenant = ChangeTracker.Entries<Appartment>()
            .Where(e => e.State == EntityState.Modified && e.Entity.TenantId == null);

        foreach (var entry in apartmentsWithoutTenant)
        {
            entry.Entity.IsAvailable = true;
        }

        return base.SaveChanges();
    }
}
