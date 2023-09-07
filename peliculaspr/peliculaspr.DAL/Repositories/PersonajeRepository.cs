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
    public class PersonajeRepository : Core.RepositorioBase<MPersonaje>, IPersonajeRepository
    {
        private readonly peliscontext _personajerepository;
        private readonly ILogger<PersonajeRepository> _logger;
        public PersonajeRepository(peliscontext context, ILogger<PersonajeRepository> ilooger) : base(context)
        {
            _personajerepository = context;
            _logger = ilooger;
        }
        public override void Save(MPersonaje entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MPersonaje entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MPersonaje entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MPersonaje> GetEntities()
        {
            return this._personajerepository.Personaje.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MPersonaje GetEntity(int id)
        {
            return this._personajerepository.Personaje.FirstOrDefault(cd => cd.idpersonaje == id && !cd.IsDeleted);
        }
    }
}
