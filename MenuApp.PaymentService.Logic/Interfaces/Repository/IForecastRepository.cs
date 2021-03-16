using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuApp.PaymentService.Logic.Entities;

namespace MenuApp.PaymentService.Logic.Interfaces.Repository
{
    public interface IForecastRepository
    {
        Task<IEnumerable<WeatherForecast>> GetALl();
    }
}