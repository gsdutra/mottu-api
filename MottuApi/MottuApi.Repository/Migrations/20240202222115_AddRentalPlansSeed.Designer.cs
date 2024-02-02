﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MottuApi.Repository;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MottuApi.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240202222115_AddRentalPlansSeed")]
    partial class AddRentalPlansSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MottuApi.Model.DeliveryPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CnhImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CnhType")
                        .HasColumnType("integer");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("DeliveryPeople");
                });

            modelBuilder.Entity("MottuApi.Model.Motorcycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModelId")
                        .IsUnique();

                    b.ToTable("Motorcycles");
                });

            modelBuilder.Entity("MottuApi.Model.MotorcycleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MotorcycleModels");
                });

            modelBuilder.Entity("MottuApi.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddresDestination")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddresOrigin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Situation")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MottuApi.Model.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MotorcycleId")
                        .HasColumnType("integer");

                    b.Property<int>("RentalPlanId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MotorcycleId")
                        .IsUnique();

                    b.HasIndex("RentalPlanId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("MottuApi.Model.RentalPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DailyFinePercentage")
                        .HasColumnType("integer");

                    b.Property<int>("DailyPrice")
                        .HasColumnType("integer");

                    b.Property<int>("Days")
                        .HasColumnType("integer");

                    b.Property<int>("ExtraDayPrice")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("RentalsPlan");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DailyFinePercentage = 20,
                            DailyPrice = 3000,
                            Days = 7,
                            ExtraDayPrice = 5000
                        },
                        new
                        {
                            Id = 2,
                            DailyFinePercentage = 40,
                            DailyPrice = 2800,
                            Days = 15,
                            ExtraDayPrice = 5000
                        },
                        new
                        {
                            Id = 3,
                            DailyFinePercentage = 60,
                            DailyPrice = 2200,
                            Days = 30,
                            ExtraDayPrice = 5000
                        });
                });

            modelBuilder.Entity("MottuApi.Model.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bearer")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("MottuApi.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -100,
                            Email = "admin@admin.com",
                            IsAdmin = true,
                            Password = "$2a$11$uLXF/MIWB7sFfvip5vhbWuAvn3fDFGrI7W8utMSefn2MIeToHHVGm"
                        });
                });

            modelBuilder.Entity("MottuApi.Model.DeliveryPerson", b =>
                {
                    b.HasOne("MottuApi.Model.User", "User")
                        .WithOne("DeliveryPerson")
                        .HasForeignKey("MottuApi.Model.DeliveryPerson", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MottuApi.Model.Motorcycle", b =>
                {
                    b.HasOne("MottuApi.Model.MotorcycleModel", "Model")
                        .WithOne("Motorcycle")
                        .HasForeignKey("MottuApi.Model.Motorcycle", "ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("MottuApi.Model.Rental", b =>
                {
                    b.HasOne("MottuApi.Model.Motorcycle", "Motorcycle")
                        .WithOne("Rental")
                        .HasForeignKey("MottuApi.Model.Rental", "MotorcycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MottuApi.Model.RentalPlan", "RentalPlan")
                        .WithOne("Rental")
                        .HasForeignKey("MottuApi.Model.Rental", "RentalPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MottuApi.Model.User", "User")
                        .WithOne("Rental")
                        .HasForeignKey("MottuApi.Model.Rental", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorcycle");

                    b.Navigation("RentalPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MottuApi.Model.Session", b =>
                {
                    b.HasOne("MottuApi.Model.User", "User")
                        .WithOne("Session")
                        .HasForeignKey("MottuApi.Model.Session", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MottuApi.Model.Motorcycle", b =>
                {
                    b.Navigation("Rental")
                        .IsRequired();
                });

            modelBuilder.Entity("MottuApi.Model.MotorcycleModel", b =>
                {
                    b.Navigation("Motorcycle")
                        .IsRequired();
                });

            modelBuilder.Entity("MottuApi.Model.RentalPlan", b =>
                {
                    b.Navigation("Rental");
                });

            modelBuilder.Entity("MottuApi.Model.User", b =>
                {
                    b.Navigation("DeliveryPerson")
                        .IsRequired();

                    b.Navigation("Rental")
                        .IsRequired();

                    b.Navigation("Session")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
