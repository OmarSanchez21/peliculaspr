using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class VersionesFormatoDependency
    {
        public static void AddVersionesFormato(this IServiceCollection services)
        {
            services.AddScoped<IVersionesFormatoRepository, VersionesFormatoRepository>();
            services.AddTransient<IVersionesFormatoService, VersionesFormatoService>();
        }
    }
}
