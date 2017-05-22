using System;
using System.Linq;
using Authentication.Core.Models.Contracts;
using Authentication.Database.Contexts;
using Authentication.PresistenceModels;

namespace Authentication.Database
{
  public abstract class Repository<TEntity> : IDisposable
    where TEntity : class, IEntity
  {
    private readonly Lazy<DatabaseContext> databaseContext;

    protected Repository(IApplicationSettings applicationSettings)
    {
      databaseContext = new Lazy<DatabaseContext>(() => new DatabaseContext(applicationSettings));
    }

    protected virtual void Remove(TEntity entity)
    {
      databaseContext.Value.Set<TEntity>().Remove(entity);
      databaseContext.Value.SaveChanges();
    }

    protected virtual TEntity Add(TEntity entity)
    {
      var persistedEntity = databaseContext.Value.Set<TEntity>().Add(entity).Entity;
      databaseContext.Value.SaveChanges();
      return persistedEntity;
    }

    protected virtual TEntity Find(params object[] keyValues)
    {
      return databaseContext.Value.Set<TEntity>().Find(keyValues);
    }

    protected virtual IQueryable<TEntity> Query()
    {
      return databaseContext.Value.Set<TEntity>();
    }
    
    protected virtual int Count() => databaseContext.Value.Set<TEntity>().Count();

    public virtual void Dispose() => databaseContext.Value.Dispose();
  }
}