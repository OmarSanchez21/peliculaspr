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
    public class MiembroProduccionRepository : Core.RepositorioBase<MMiembroProduccion>, IMiembroProduccionRepository
    {
        private readonly peliscontext _miembro;
        private readonly ILogger<MiembroProduccionRepository> _logger;
        public MiembroProduccionRepository(peliscontext context, ILogger<MiembroProduccionRepository> ilogger) : base(context)
        {
            _miembro = context;
            _logger = ilogger;
        }
        public override void Save(MMiembroProduccion entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MMiembroProduccion entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MMiembroProduccion entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MMiembroProduccion> GetEntities()
        {
            return this._miembro.MiembroProduccion.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MMiembroProduccion GetEntity(int id)
        {
            return this._miembro.MiembroProduccion.FirstOrDefault(cd => cd.idmiembro == id && !cd.IsDeleted);
        }
    }
}
