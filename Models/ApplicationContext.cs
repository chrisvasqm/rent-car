using Microsoft.EntityFrameworkCore;
using RentCar.Views.Model;

namespace RentCar.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<FuelType> FuelTypes { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Commission> Commissions { get; set; }

        public DbSet<WorkShift> WorkShifts { get; set; }

        public DbSet<PersonType> PersonTypes { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<FuelAmounts> FuelAmountses { get; set; }

        public DbSet<Inspection> Inspections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }
    }
}