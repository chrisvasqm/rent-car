using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }
    }
}