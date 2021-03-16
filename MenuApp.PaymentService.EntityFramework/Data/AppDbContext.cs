using MenuApp.PaymentService.Logic.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.PaymentService.EntityFramework.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<WeatherForecast> Forecasts { get; set; }
    }
}