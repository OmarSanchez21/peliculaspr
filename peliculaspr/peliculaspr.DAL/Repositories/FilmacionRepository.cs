using Microsoft.Extensions.Logging;
using peliculaspr.DAL.Context;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peliculaspr.DAL.Repositories
{
    public class FilmacionRepository : Core.RepositorioBase<MFilmaciones>, IFilmacionRepository
    {
        private readonly peliscontext _fimalcion;
        private readonly ILogger<FilmacionRepository> _logger;
        public FilmacionRepository(peliscontext context, ILogger<FilmacionRepository> ilogger) : base(context)
        {
            _fimalcion = context;
            _logger = ilogger;
        }
        public override void Save(MFilmaciones entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Remove(MFilmaciones entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MFilmaciones> GetEntities()
        {
            return this._fimalcion.filmaciones.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MFilmaciones GetEntity(int id)
        {
            return this._fimalcion.filmaciones.FirstOrDefault(cd => cd.idfilmacion == id && !cd.IsDeleted);
        }
    }
}
