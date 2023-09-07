using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;
using System.Runtime.CompilerServices;

namespace peliculaspr.API.Dependencies
{
    public static class BandaSonoraDependency
    {
        public static void AddBandaSonoraDependency(this IServiceCollection services)
        {
            services.AddScoped<IBandaSonoraRepository, BandaSonoraRepository>();
            services.AddTransient<IBandaSonoraService, BandaSonoraService>();
        }
    }
}
