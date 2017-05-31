using System;
using System.Collections.Generic;
using System.Linq;
using Authentication.Core.Models.Contracts;
using Authentication.Database.Contexts;
using Authentication.PresistenceModels;

namespace Authentication.Database
{
  public abstract class Repository<TEntity> : IDisposable
    where TEntity : class, IEntity
  {
    private readonly DatabaseContext databaseContext;

    protected Repository(DatabaseContext databaseContext)
    {
      this.databaseContext = databaseContext;
    }

    protected virtual void Remove(TEntity entity)
    {
      databaseContext.Set<TEntity>().Remove(entity);
    }

    protected virtual TEntity Add(TEntity entity)
    {
      var persistedEntity =  databaseContext.Set<TEntity>().Add(entity).Entity;

      //Save changes so the DB can genereate the identity values
      databaseContext.SaveChanges();

      return persistedEntity;
    }

    protected void Save() => databaseContext.SaveChanges();

    protected virtual TEntity Find(params object[] keyValues)
    {
      return databaseContext.Set<TEntity>().Find(keyValues);
    }

    protected virtual IQueryable<TEntity> Query()
    {
      return databaseContext.Set<TEntity>();
    }
    
    protected virtual int Count() => databaseContext.Set<TEntity>().Count();

    public virtual void Dispose() => databaseContext.Dispose();
  }
}