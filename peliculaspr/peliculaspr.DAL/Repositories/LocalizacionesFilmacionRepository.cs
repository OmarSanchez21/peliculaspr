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
    public class LocalizacionesFilmacionRepository : Core.RepositorioBase<MLocalizacionesFilmacion>, ILocalizacionesFilmacionRepository
    {
        private readonly peliscontext _locaciones;
        private readonly ILogger<LocalizacionesFilmacionRepository> _logger;
        public LocalizacionesFilmacionRepository(peliscontext context, ILogger<LocalizacionesFilmacionRepository> illoger) : base(context)
        {
            _locaciones = context;
            _logger = illoger;
        }
        public override void Save(MLocalizacionesFilmacion entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MLocalizacionesFilmacion entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MLocalizacionesFilmacion entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MLocalizacionesFilmacion> GetEntities()
        {
            return this._locaciones.LocacionesFilmacion.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MLocalizacionesFilmacion GetEntity(int id)
        {
            return this._locaciones.LocacionesFilmacion.FirstOrDefault(cd => cd.idlocacion == id && !cd.IsDeleted);
        }
    }
}
