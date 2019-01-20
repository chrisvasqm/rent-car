using Microsoft.EntityFrameworkCore;

namespace RentCar.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }
    }}