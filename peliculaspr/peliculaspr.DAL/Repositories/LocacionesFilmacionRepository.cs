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
    public class LocacionesFilmacionRepository : Core.RepositorioBase<MLocacionesFilmacion>, ILocacionesFilmacionRepository
    {
        private readonly peliscontext _locaciones;
        private readonly ILogger<LocacionesFilmacionRepository> _logger;
        public LocacionesFilmacionRepository(peliscontext context, ILogger<LocacionesFilmacionRepository> illoger) : base(context)
        {
            _locaciones = context;
            _logger = illoger;
        }
        public override void Save(MLocacionesFilmacion entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MLocacionesFilmacion entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MLocacionesFilmacion entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MLocacionesFilmacion> GetEntities()
        {
            return this._locaciones.locacionesFilmacions.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MLocacionesFilmacion GetEntity(int id)
        {
            return this._locaciones.locacionesFilmacions.FirstOrDefault(cd => cd.idlocacion == id && !cd.IsDeleted);
        }
    }
}
