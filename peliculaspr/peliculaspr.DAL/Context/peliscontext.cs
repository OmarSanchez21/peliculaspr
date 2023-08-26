using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using peliculaspr.DAL.Models;

namespace peliculaspr.DAL.Context
{
    public class peliscontext : DbContext
    {
        public peliscontext() { 
        
        }

        public peliscontext(DbContextOptions<peliscontext> options) : base(options)
        {

        }
        public DbSet<MActor> actors { get; set; }
        public DbSet<MBandaSonora> banda { get; set; }
        public DbSet<MCritico> criticos { get; set; }
        public DbSet<MEquipoProduccion> producciones { get; set;}
        public DbSet<MFilmaciones> filmaciones { get;set; }
        public DbSet<MLocacionesFilmacion> locacionesFilmacions { get; set; }
        public DbSet<MMiembroProduccion> miembroProduccions { get; set; }
        public DbSet<MNominaciones> nominaciones { get; set; }
        public DbSet<MPelicula> peliculas { get; set; }
        public DbSet<MPersonaje> personajes { get; set; }
        public DbSet<MPremio> premios { get; set; }
        public DbSet<MReseña> reseñas { get; set; }
        public DbSet<MVersionesFormato> versionesFormatos { get; set; }

    }
}
