using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class ActorDependency
    {
        public static void AddActorDependecy(this IServiceCollection services)
        {
            services.AddScoped<IActorsRepository, ActorRepository>();
            services.AddTransient<IActorService, ActorService>();
        }
    }
}
