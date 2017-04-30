using System;
using System.Linq;

namespace Authentication.Core.Contracts
{
  public interface IRepository : IDisposable
  {
    void Remove<TEntity>(TEntity entity)
      where TEntity : class, IEntity;

    TEntity Add<TEntity>(TEntity entity)
      where TEntity : class, IEntity;

    TEntity Get<TEntity>(params object[] keyValues)
      where TEntity : class, IEntity;

    IQueryable<TEntity> Query<TEntity>()
      where TEntity : class, IEntity;

    int Count<TEntity>()
      where TEntity : class, IEntity;
  }
}
