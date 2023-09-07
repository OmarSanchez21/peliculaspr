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
    public class ReseñaRepository : Core.RepositorioBase<MReseña>, IReseñaRepository
    {
        private readonly peliscontext _reseñarepository;
        private readonly ILogger<ReseñaRepository> _logger;
        public ReseñaRepository(peliscontext context, ILogger<ReseñaRepository> logger) : base(context)
        {
            _reseñarepository = context;
            _logger = logger;
        }
        public override void Save(MReseña entity)
        {
            if(this.Exists(cd => cd.Resena == entity.Resena))
            {
                throw new ReseñaDataExceptions("Esta Reseña ya esta registrada");
            }
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MReseña entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MReseña entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MReseña> GetEntities()
        {
            return this._reseñarepository.Resenas.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MReseña GetEntity(int id)
        {
            return this._reseñarepository.Resenas.FirstOrDefault(cd => cd.idresena == id && !cd.IsDeleted);
        }
    }
}
