using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class EquipoProduccionDependency
    {
        public static void AddEquipoProduccionDependency(this IServiceCollection services)
        {
            services.AddScoped<IEquipoProduccionRepository, EquipoProduccionRepository>();
            services.AddTransient<IEquipoProduccionService, EquipoProduccionService>();
        }
    }
}
