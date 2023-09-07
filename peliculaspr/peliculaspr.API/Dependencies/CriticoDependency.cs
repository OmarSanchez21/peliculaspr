using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class CriticoDependency
    {
        public static void AddCriticoDependey(this IServiceCollection services)
        {
            services.AddScoped<ICriticoRepository, CriticoRepository>();
            services.AddTransient<ICriticoService, CriticoService>();
        }
    }
}
