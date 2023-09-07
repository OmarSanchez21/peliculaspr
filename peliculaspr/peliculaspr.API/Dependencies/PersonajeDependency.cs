using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class PersonajeDependency
    {
        public static void AddPersonajeDependency(this IServiceCollection services)
        {
            services.AddScoped<IPersonajeRepository, PersonajeRepository>();
            services.AddTransient<IPersonajeService, PersonajeService>();
        }
    }
}
