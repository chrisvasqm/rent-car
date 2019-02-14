﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCar.Models;

namespace RentCar.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190214021246_AddInspectionsTable")]
    partial class AddInspectionsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentCar.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<byte>("StatusId");

                    b.Property<int?>("StatusId1");

                    b.HasKey("Id");

                    b.HasIndex("StatusId1");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("RentCar.Models.FuelAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FuelAmount");
                });

            modelBuilder.Entity("RentCar.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<byte>("StatusId");

                    b.Property<int?>("StatusId1");

                    b.HasKey("Id");

                    b.HasIndex("StatusId1");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("RentCar.Models.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("EmployeeId");

                    b.Property<byte>("FuelAmountId");

                    b.Property<int?>("FuelAmountId1");

                    b.Property<bool>("HasCarJack");

                    b.Property<bool>("HasGlassBreaks");

                    b.Property<bool>("HasReplacementTire");

                    b.Property<bool>("IsFirstTireGood");

                    b.Property<bool>("IsFourthTireGood");

                    b.Property<bool>("IsScratched");

                    b.Property<bool>("IsSecondTireGood");

                    b.Property<bool>("IsThirdTireGood");

                    b.Property<byte>("StatusId");

                    b.Property<int?>("StatusId1");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FuelAmountId1");

                    b.HasIndex("StatusId1");

                    b.HasIndex("VehicleId");

                    b.ToTable("Inspections");
                });

            modelBuilder.Entity("RentCar.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("ModelId");

                    b.Property<byte>("StatusId");

                    b.Property<int?>("StatusId1");

                    b.HasKey("Id");

                    b.HasIndex("StatusId1");

                    b.ToTable("Models");
                });

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

            modelBuilder.Entity("RentCar.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("BrandId");

                    b.Property<int?>("BrandId1");

                    b.Property<string>("ChassisNumber");

                    b.Property<string>("Description");

                    b.Property<byte>("FuelTypeId");

                    b.Property<int?>("FuelTypeId1");

                    b.Property<string>("LicensePlate");

                    b.Property<byte>("ModelId");

                    b.Property<int?>("ModelId1");

                    b.Property<string>("MotorNumber");

                    b.Property<byte>("StatusId");

                    b.Property<int?>("StatusId1");

                    b.Property<byte>("VehicleTypeId");

                    b.Property<int?>("VehicleTypeId1");

                    b.HasKey("Id");

                    b.HasIndex("BrandId1");

                    b.HasIndex("FuelTypeId1");

                    b.HasIndex("ModelId1");

                    b.HasIndex("StatusId1");

                    b.HasIndex("VehicleTypeId1");

                    b.ToTable("Vehicles");
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

            modelBuilder.Entity("RentCar.Views.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreditCard")
                        .IsRequired();

                    b.Property<double>("CreditLimit");

                    b.Property<string>("IdentificationCard")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte>("PersonTypeId");

                    b.Property<int?>("PersonTypeId1");

                    b.Property<byte>("StatusId");

                    b.Property<int?>("StatusId1");

                    b.HasKey("Id");

                    b.HasIndex("PersonTypeId1");

                    b.HasIndex("StatusId1");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RentCar.Views.Model.Commission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Commissions");
                });

            modelBuilder.Entity("RentCar.Views.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<byte>("CommissionId");

                    b.Property<int?>("CommissionId1");

                    b.Property<string>("IdentificationCard");

                    b.Property<string>("Name");

                    b.Property<byte>("StatusId");

                    b.Property<int?>("StatusId1");

                    b.Property<byte>("WorkShiftId");

                    b.Property<int?>("WorkShiftId1");

                    b.HasKey("Id");

                    b.HasIndex("CommissionId1");

                    b.HasIndex("StatusId1");

                    b.HasIndex("WorkShiftId1");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RentCar.Views.Model.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PersonTypes");
                });

            modelBuilder.Entity("RentCar.Views.Model.WorkShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("RentCar.Models.Brand", b =>
                {
                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");
                });

            modelBuilder.Entity("RentCar.Models.FuelType", b =>
                {
                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");
                });

            modelBuilder.Entity("RentCar.Models.Inspection", b =>
                {
                    b.HasOne("RentCar.Views.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RentCar.Models.FuelAmount", "FuelAmount")
                        .WithMany()
                        .HasForeignKey("FuelAmountId1");

                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");

                    b.HasOne("RentCar.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RentCar.Models.Model", b =>
                {
                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");
                });

            modelBuilder.Entity("RentCar.Models.Vehicle", b =>
                {
                    b.HasOne("RentCar.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId1");

                    b.HasOne("RentCar.Models.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeId1");

                    b.HasOne("RentCar.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId1");

                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");

                    b.HasOne("RentCar.Models.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId1");
                });

            modelBuilder.Entity("RentCar.Models.VehicleType", b =>
                {
                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");
                });

            modelBuilder.Entity("RentCar.Views.Model.Client", b =>
                {
                    b.HasOne("RentCar.Views.Model.PersonType", "PersonType")
                        .WithMany()
                        .HasForeignKey("PersonTypeId1");

                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");
                });

            modelBuilder.Entity("RentCar.Views.Model.Employee", b =>
                {
                    b.HasOne("RentCar.Views.Model.Commission", "Commission")
                        .WithMany()
                        .HasForeignKey("CommissionId1");

                    b.HasOne("RentCar.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId1");

                    b.HasOne("RentCar.Views.Model.WorkShift", "WorkShift")
                        .WithMany()
                        .HasForeignKey("WorkShiftId1");
                });
#pragma warning restore 612, 618
        }
    }
}
