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
    public class PremioRepository : Core.RepositorioBase<MPremio>, IPremioRepository
    {
        private readonly peliscontext _premiorepository;
        private readonly ILogger<IPremioRepository> _logger;
        public PremioRepository(peliscontext context, ILogger<PremioRepository> ilogger) : base(context)
        {
            _premiorepository = context;
            _logger = ilogger;
        }
        public override void Save(MPremio entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MPremio entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MPremio entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MPremio> GetEntities()
        {
            return this._premiorepository.premios.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MPremio GetEntity(int id)
        {
            return this._premiorepository.premios.FirstOrDefault(cd => cd.idpremios == id && !cd.IsDeleted);
        }
    }
}
