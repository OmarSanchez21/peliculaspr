using Microsoft.Extensions.Logging;
using peliculaspr.DAL.Context;
using peliculaspr.DAL.Exceptions;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peliculaspr.DAL.Repositories
{
    public class PeliculaRepository : Core.RepositorioBase<MPelicula>, IPeliculaRepository
    {
        private readonly peliscontext _pelicularepository;
        private readonly ILogger<PeliculaRepository> _logger;
        public PeliculaRepository(peliscontext context, ILogger<PeliculaRepository> ilooger) : base(context)
        {
            _pelicularepository = context;
            _logger = ilooger;
        }
        public override void Save(MPelicula entity)
        {
            if(this.Exists(cd => cd.Titulo == entity.Titulo))
            {
                throw new PeliculaDataExceptions("Esta Pelicula ya esta registrada");
            }
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MPelicula entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MPelicula entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MPelicula> GetEntities()
        {
            return this._pelicularepository.peliculas.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MPelicula GetEntity(int id)
        {
            return this._pelicularepository.peliculas.FirstOrDefault(cd => cd.idpeliculas == id && !cd.IsDeleted);
        }
    }
}
