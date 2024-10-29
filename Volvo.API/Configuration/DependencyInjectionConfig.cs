using Volvo.API.Data;
using Volvo.API.Data.Repositories;
using Volvo.API.Domain.Contracts.Repositories;
using Volvo.API.Domain.Contracts.Services;
using Volvo.API.Domain.Contracts.Transactions;
using Volvo.API.Service;


namespace Volvo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<ITruckService, TruckService>();
        }
    }
}
