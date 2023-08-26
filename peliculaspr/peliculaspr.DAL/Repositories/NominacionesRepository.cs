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
    public class NominacionesRepository : Core.RepositorioBase<MNominaciones>, INominacionesRepository
    {
        private readonly peliscontext _nominacionesrepository;
        private readonly ILogger<NominacionesRepository> _logger;
        public NominacionesRepository(peliscontext context, ILogger<NominacionesRepository> ilogger) : base(context)
        {
            _nominacionesrepository = context;
            _logger = ilogger;
        }
        public override void Save(MNominaciones entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MNominaciones entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override List<MNominaciones> GetEntities()
        {
            return this._nominacionesrepository.nominaciones.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MNominaciones GetEntity(int id)
        {
            return this._nominacionesrepository.nominaciones.FirstOrDefault(cd => cd.idnominaciones == id && !cd.IsDeleted);
        }
    }
}
