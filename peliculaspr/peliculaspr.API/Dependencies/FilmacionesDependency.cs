﻿using Microsoft.Extensions.DependencyInjection;
using peliculaspr.BILL.Contract;
using peliculaspr.BILL.Services;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Repositories;

namespace peliculaspr.API.Dependencies
{
    public static class FilmacionesDependency
    {
        public static void AddFilmacionesDependency(this IServiceCollection services)
        {
            services.AddScoped<IFilmacionRepository, FilmacionRepository>();
            services.AddTransient<IFilmacionesService, FilmacionesService>();
        }
    }
}
