using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class ReseñaDependency
    {
        public static void AddReseñaDependency(this IServiceCollection services)
        {
            services.AddTransient<IReseñaRepository, ReseñaRepository>();
            services.AddScoped<IReseñaService, ReseñaService>();
        }
    }
}
