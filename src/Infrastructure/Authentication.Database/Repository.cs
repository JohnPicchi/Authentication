using System;
using System.Linq;
using Authentication.Core.Models.Contracts;
using Authentication.Core.ServiceContracts;
using Authentication.Database.Contexts;
using Authentication.PresistenceModels;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database
{
  public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IPersistedEntity
  {
    private readonly Lazy<DatabaseContext> databaseContext;

    public Repository(IApplicationSettings applicationSettings)
    {
      databaseContext = new Lazy<DatabaseContext>(() => new DatabaseContext(applicationSettings));
    }

    public void Remove(TEntity entity)
    {
      databaseContext.Value.Set<TEntity>().Remove(entity);
      databaseContext.Value.SaveChanges();
    }

    public TEntity Add(TEntity entity)
    {
      var persistedEntity = databaseContext.Value.Set<TEntity>().Add(entity).Entity;
      databaseContext.Value.SaveChanges();
      return persistedEntity;
    }

    public TEntity Get(params object[] keyValues)
    {
      return databaseContext.Value.Set<TEntity>().Find(keyValues);
    }

    public IQueryable<TEntity> Query()
    {
      return databaseContext.Value.Set<TEntity>();
    }
    
    public int Count() => databaseContext.Value.Set<TEntity>().Count();

    public void Dispose() => databaseContext.Value.Dispose();
  }
}
