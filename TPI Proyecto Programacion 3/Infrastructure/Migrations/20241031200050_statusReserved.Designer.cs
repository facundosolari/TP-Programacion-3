﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20241031200050_statusReserved")]
    partial class statusReserved
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Domain.Entities.Appartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bathrooms")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pictures")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<float>("Rating")
                        .HasColumnType("REAL");

                    b.Property<int>("Rooms")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Appartments");
                });

            modelBuilder.Entity("Domain.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("BackYard")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Garage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ubication")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppartmentId");

                    b.HasIndex("TenantId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppartmentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantID")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("VisitDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ReservationID");

                    b.HasIndex("AppartmentID");

                    b.HasIndex("TenantID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Domain.Entities.Owner", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.ToTable("Users", t =>
                        {
                            t.Property("Photo")
                                .HasColumnName("Owner_Photo");
                        });

                    b.HasDiscriminator().HasValue("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Tenant", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<int?>("AppartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.HasIndex("AppartmentId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.Appartment", b =>
                {
                    b.HasOne("Domain.Entities.Building", "Building")
                        .WithMany("Appartments")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Domain.Entities.Building", b =>
                {
                    b.HasOne("Domain.Entities.Owner", "Owner")
                        .WithMany("Buildings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.HasOne("Domain.Entities.Appartment", "Appartment")
                        .WithMany("Ratings")
                        .HasForeignKey("AppartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appartment");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Domain.Entities.Appartment", "Appartment")
                        .WithMany()
                        .HasForeignKey("AppartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appartment");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.Tenant", b =>
                {
                    b.HasOne("Domain.Entities.Appartment", "Appartment")
                        .WithOne("Tenant")
                        .HasForeignKey("Domain.Entities.Tenant", "AppartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Appartment");
                });

            modelBuilder.Entity("Domain.Entities.Appartment", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.Building", b =>
                {
                    b.Navigation("Appartments");
                });

            modelBuilder.Entity("Domain.Entities.Owner", b =>
                {
                    b.Navigation("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}
