﻿using Domain.Entities;
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
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>()
            .HasOne(b => b.Owner)
            .WithMany(o => o.Property)
            .HasForeignKey(b => b.OwnerId);
    }

}
