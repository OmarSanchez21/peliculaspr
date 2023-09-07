using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class PremioDependency
    {
        public static void AddPremioDependency(this IServiceCollection services)
        {
            services.AddTransient<IPremioRepository, PremioRepository>();
            services.AddScoped<IPremioService, PremioService>();
        }
    }
}
