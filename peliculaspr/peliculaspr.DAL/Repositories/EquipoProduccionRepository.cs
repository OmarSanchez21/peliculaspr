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
    public class EquipoProduccionRepository : Core.RepositorioBase<MEquipoProduccion>, IEquipoProduccionRepository
    {
        private readonly peliscontext _equipoprod;
        private readonly ILogger<EquipoProduccionRepository> logger;
        public EquipoProduccionRepository(peliscontext equipoprod, ILogger<EquipoProduccionRepository> logger) : base(equipoprod)
        {
           this._equipoprod = equipoprod;
            this.logger = logger;
        }
        public override void Save(MEquipoProduccion entity)
        {
            if (this.Exists(cd => cd.NombreMiembro == entity.NombreMiembro))
            {
                throw new EquipoProduccionDataExceptions("Este equipo de produccion ya esta registrado");
            }
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(MEquipoProduccion entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(MEquipoProduccion entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<MEquipoProduccion> GetEntities()
        {
            return this._equipoprod.EquipoProduccion.Where(cd => !cd.IsDeleted).ToList();
        }
        public override MEquipoProduccion GetEntity(int id)
        {
            return this._equipoprod.EquipoProduccion.FirstOrDefault(cd => cd.idequipo == id && !cd.IsDeleted);
        }
    }
}
