using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class LocalizacionesFilmacionesDependency
    {
        public static void AddLocalizacionesFilmacionesDependency(this IServiceCollection services)
        {
            services.AddScoped<ILocalizacionesFilmacionRepository, LocalizacionesFilmacionRepository>();
            services.AddTransient<ILocalizacionesFilmacionesService, LocalizacionesFilmacionesService>();
        }
    }
}
