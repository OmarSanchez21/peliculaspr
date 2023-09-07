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
    public class ActorRepository : Core.RepositorioBase<MActor>, IActorsRepository
    {
        private readonly peliscontext _actorRepository;
        private readonly ILogger<ActorRepository> _logger;
        public ActorRepository(peliscontext context, ILogger<ActorRepository> ilooger) : base(context) 
        {
            this._actorRepository = context;
            this._logger = ilooger;
        }
        public override void Save(MActor entity)
        {
           if(this.Exists(cd => cd.Nombre == entity.Nombre))
            {
                throw new ActorDataExceptions("Este Actor ya esta registrado");
            }

            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MActor entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MActor entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MActor> GetEntities()
        {
            return this._actorRepository.Actor.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MActor GetEntity(int id)
        {
            return this._actorRepository.Actor.FirstOrDefault(cd => cd.idactor == id && !cd.IsDeleted);
        }

    }

}
