using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authentication.Core.Contracts;
using Authentication.Database.Contexts;

namespace Authentication.Database
{
  public class Repository : IRepository
  {
    private readonly Lazy<DatabaseContext> databaseContext;

    public Repository()
    {

    }

    public void Remove<TEntity>(TEntity entity)
      where TEntity : class, IEntity
    {
      databaseContext.Value.Set<TEntity>()
        .Remove(entity);

      databaseContext.Value.SaveChanges();
    }

    public TEntity Add<TEntity>(TEntity entity)
      where TEntity : class, IEntity
    {
      var result = databaseContext.Value.Set<TEntity>()
        .Add(entity)
        .Entity;

      databaseContext.Value.SaveChanges();
      return result;
    }

    public TEntity Get<TEntity>(params object[] keyValues)
      where TEntity : class, IEntity
    {
      return databaseContext.Value.Set<TEntity>()
        .Find(keyValues);
    }

    public IQueryable<TEntity> Query<TEntity>()
      where TEntity : class, IEntity
    {
      return databaseContext.Value.Set<TEntity>().AsQueryable();
    }

    public int Count<TEntity>()
      where TEntity : class, IEntity
    {
      return databaseContext.Value.Set<TEntity>()
        .Count();
    }

    public void Dispose()
    {
      databaseContext.Value.Dispose();
    }
  }
}
