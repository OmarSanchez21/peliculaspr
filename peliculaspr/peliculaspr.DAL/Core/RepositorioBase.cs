using Microsoft.EntityFrameworkCore;
using peliculaspr.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace peliculaspr.DAL.Core
{
    public abstract class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly peliscontext context;
        private DbSet<TEntity> myEntities;
        public RepositorioBase(peliscontext context)
        {
            this.context = context;
            this.myEntities = this.context.Set<TEntity>();
            
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myEntities.Any(filter);
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.myEntities.ToList();
        }


        public virtual TEntity GetEntity(int id)
        {
            return this.myEntities.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            this.myEntities.Remove(entity);
        }

        public virtual void Remove(TEntity[] entities)
        {
            this.myEntities.RemoveRange(entities);
        }

        public virtual void Save(TEntity entity)
        {
            this.myEntities.Add(entity);
        }

        public virtual void Save(TEntity[] entities)
        {
            this.context.AddRange(entities);
        }

        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.myEntities.Update(entity);
        }

        public virtual void Update(TEntity[] entities)
        {
            this.myEntities.UpdateRange(entities);
        }
    }

}
