using Microsoft.Extensions.Logging;
using peliculaspr.DAL.Context;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;

namespace peliculaspr.DAL.Repositories
{
    public class BandaSonoraRepository : Core.RepositorioBase<MBandaSonora>, IBandaSonoraRepository
    {
        private readonly peliscontext peliscontext;
        private readonly ILogger<BandaSonoraRepository> _logger;
        public BandaSonoraRepository(peliscontext context, ILogger<BandaSonoraRepository> logger) : base(context)
        {
            this.peliscontext = context;
            this._logger = logger;
        }
        public override void Save(MBandaSonora entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Remove(MBandaSonora entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MBandaSonora> GetEntities()
        {
            return this.peliscontext.BandaSonora.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MBandaSonora GetEntity(int id)
        {
            return this.peliscontext.BandaSonora.FirstOrDefault(cd => cd.idbanda == id && !cd.IsDeleted);
        }
    }
}

