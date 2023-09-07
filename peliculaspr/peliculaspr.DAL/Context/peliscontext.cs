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
        public DbSet<MActor> Actor { get; set; }
        public DbSet<MBandaSonora> BandaSonora { get; set; }
        public DbSet<MCritico> Critico { get; set; }
        public DbSet<MEquipoProduccion> EquipoProduccion { get; set;}
        public DbSet<MFilmaciones> Filmaciones { get;set; }
        public DbSet<MLocalizacionesFilmacion> LocacionesFilmacion { get; set; }
        public DbSet<MMiembroProduccion> MiembroProduccion { get; set; }
        public DbSet<MNominaciones> Nominaciones { get; set; }
        public DbSet<MPelicula> Pelicula { get; set; }
        public DbSet<MPersonaje> Personaje { get; set; }
        public DbSet<MPremio> Premios { get; set; }
        public DbSet<MReseña> Resenas { get; set; }
        public DbSet<MVersionesFormato> VersionesFormato { get; set; }

    }
}
