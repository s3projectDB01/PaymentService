using System.Collections.Generic;
using System.Threading.Tasks;
using MenuApp.PaymentService.EntityFramework.Data;
using MenuApp.PaymentService.Logic.Entities;
using MenuApp.PaymentService.Logic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.PaymentService.EntityFramework.Repository
{
    public class ForecastRepository : IForecastRepository
    {
        private readonly AppDbContext _db;
        
        public ForecastRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<WeatherForecast>> GetALl()
        {
            return await _db.Forecasts.ToArrayAsync();
        }
    }
}