using System;
using System.Linq;

namespace Authentication.Domain
{
  public interface IRepository<TEntity> : IDisposable
    where TEntity: class
  {
    void Remove(TEntity entity);

    TEntity Add(TEntity entity);

    TEntity Get(params object[] keyValues);

    IQueryable Query();

    int Count();
  }
}
