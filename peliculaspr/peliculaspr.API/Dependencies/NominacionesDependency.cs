using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class NominacionesDependency
    {
        public static void AddNominacioneDependency(this IServiceCollection services)
        {
            services.AddScoped<INominacionesRepository, NominacionesRepository>();
            services.AddTransient<INominacionesService, NominacionesService>();
        }
    }
}
