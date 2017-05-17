using System;

namespace Authentication.PresistenceModels
{
  public interface IEntity { }

  public interface IEntity<TEntity> : IEntity
  {
    TEntity Id { get; set; }
  }

  public abstract class Entity<TEntity> : IEntity<TEntity>
  {
    public TEntity Id { get; set; }
  }
}
