using System.Linq;

namespace Authentication.Core.ServiceContracts
{
  public interface IRepository<TEntity>
  {
    TEntity Add(TEntity entity);

    TEntity Get(params object[] keyValues);

    IQueryable<TEntity> Query();

    int Count();

    void Remove(TEntity entity);
  }
}
