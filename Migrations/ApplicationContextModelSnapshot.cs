﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCar.Models;

namespace RentCar.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentCar.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("RentCar.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<byte>("StatusId");

                    b.Property<int?>("StatusId1");

                    b.HasKey("Id");

                    b.HasIndex("StatusId1");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("RentCar.Models.VehicleType", b =>
                {
                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");
                });
#pragma warning restore 612, 618
        }
    }
}
