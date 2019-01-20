using Microsoft.EntityFrameworkCore;

namespace RentCar.Models
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }
    }}