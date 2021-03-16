using MenuApp.PaymentService.EntityFramework.Data;
using MenuApp.PaymentService.EntityFramework.Repository;
using MenuApp.PaymentService.Logic.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MenuApp.PaymentService.EntityFramework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseNpgsql(connectionString);
            });

            services.AddTransient<IForecastRepository, ForecastRepository>();
            
            return services;
        }
    }
}