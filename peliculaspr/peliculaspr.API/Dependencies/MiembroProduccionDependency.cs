using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class MiembroProduccionDependency
    {
        public static void AddMiembroProduccionDependency(this IServiceCollection services)
        {
            services.AddScoped<IMiembroProduccionRepository, MiembroProduccionRepository>();
            services.AddTransient<IMiembroProduccionService, MiembroProduccionService>();
        }
    }
}
