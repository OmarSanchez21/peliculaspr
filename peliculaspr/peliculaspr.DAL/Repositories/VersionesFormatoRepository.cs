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
    public class VersionesFormatoRepository : Core.RepositorioBase<MVersionesFormato>, IVersionesFormatoRepository
    {
        private readonly peliscontext _peliscontext;
        private readonly ILogger<VersionesFormatoRepository> _logger;
        public VersionesFormatoRepository(peliscontext context, ILogger<VersionesFormatoRepository> logger): base(context) 
        {
            _peliscontext = context;
            _logger = logger;
        }
        public override void Save(MVersionesFormato entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MVersionesFormato entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MVersionesFormato entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MVersionesFormato> GetEntities()
        {
            return this._peliscontext.VersionesFormato.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MVersionesFormato GetEntity(int id)
        {
            return this._peliscontext.VersionesFormato.FirstOrDefault(cd => cd.idversiones == id && !cd.IsDeleted);
        }

    }
}
