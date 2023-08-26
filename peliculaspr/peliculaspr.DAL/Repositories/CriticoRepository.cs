using Microsoft.Extensions.Logging;
using peliculaspr.DAL.Context;
using peliculaspr.DAL.Core;
using peliculaspr.DAL.Exceptions;
using peliculaspr.DAL.Interfaces;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peliculaspr.DAL.Repositories
{
    public class CriticoRepository : Core.RepositorioBase<MCritico>, ICriticoRepository
    {
        private readonly peliscontext _criticorepository;
        private readonly ILogger<CriticoRepository> _logger;
        public CriticoRepository(peliscontext context, ILogger<CriticoRepository> logger ) : base(context)
        {
            this._criticorepository = context;
            this._logger = logger;
        }
        public override void Save(MCritico entity)
        {
            if (this.Exists(cd => cd.Nombre == entity.Nombre))
            {
                throw new CriticoDataExceptions("Este Critico ya esta registrado");
            }
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MCritico entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MCritico entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MCritico> GetEntities()
        {
            return this._criticorepository.criticos.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MCritico GetEntity(int id)
        {
            return this._criticorepository.criticos.FirstOrDefault(cd => cd.idcritico == id && !cd.IsDeleted);
        }
    }
}
