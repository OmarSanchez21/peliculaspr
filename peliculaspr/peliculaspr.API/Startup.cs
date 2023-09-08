using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using peliculaspr.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using peliculaspr.API.Dependencies;

namespace peliculaspr.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Context//
            services.AddDbContext<peliscontext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("PelisContext")));


            //Dependencies
            services.AddActorDependecy();
            services.AddBandaSonoraDependency();
            services.AddCriticoDependey();
            services.AddEquipoProduccionDependency();
            services.AddFilmacionesDependency();
            services.AddLocalizacionesFilmacionesDependency();
            services.AddMiembroProduccionDependency();
            services.AddNominacioneDependency();
            services.AddPeliculaDependency();
            services.AddPersonajeDependency();
            services.AddPremioDependency();
            services.AddReseñaDependency();
            services.AddVersionesFormatoDependency();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "peliculaspr.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "peliculaspr.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
