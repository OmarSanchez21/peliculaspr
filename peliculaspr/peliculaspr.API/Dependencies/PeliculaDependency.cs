using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class PeliculaDependency
    {
        public static void AddPeliculaDependency(this IServiceCollection services)
        {
            services.AddScoped<IPeliculaRepository, PeliculaRepository>();
            services.AddTransient<IPeliculaService, PeliculaService>();
        }
    }
}
