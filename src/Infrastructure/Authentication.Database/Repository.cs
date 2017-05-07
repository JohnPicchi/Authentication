using System;
using System.Linq;
using Authentication.Database.Contexts;
using Authentication.Domain;

namespace Authentication.Database
{
  public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    private readonly Lazy<DatabaseContext> databaseContext;

    public void Remove(TEntity entity)
    {
      databaseContext.Value.Set<TEntity>()
        .Remove(entity);

      databaseContext.Value.SaveChanges();
    }

    public TEntity Add(TEntity entity)
    {
      var result = databaseContext.Value.Set<TEntity>()
        .Add(entity)
        .Entity;

      databaseContext.Value.SaveChanges();
      return result;
    }

    public TEntity Get(params object[] keyValues)
    {
      return databaseContext.Value.Set<TEntity>()
        .Find(keyValues);
    }

    public IQueryable Query()
    {
      return databaseContext.Value.Set<TEntity>().AsQueryable();
    }

    public int Count()
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
