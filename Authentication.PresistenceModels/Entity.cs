using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.PresistenceModels
{
  public interface IPersistedEntity
  {
    DateTime DateCreated { get; set; }

    DateTime? DateUpdated { get; set; }
  }

  public interface IPersistedEntity<TEntity> : IPersistedEntity
  {
    TEntity Id { get; set; }
  }

  public abstract class PersistedEntity<TEntity> : IPersistedEntity<TEntity>
  {
    public TEntity Id { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
  }
}
