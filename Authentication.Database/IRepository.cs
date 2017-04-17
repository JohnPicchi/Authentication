using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authentication.Database.EntityModels;

namespace Authentication.Database
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
