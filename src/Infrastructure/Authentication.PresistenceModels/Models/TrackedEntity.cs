using System;

namespace Authentication.PresistenceModels.Models
{
  public interface ITrackedEntity : IEntity
  {
    DateTime? DateCreated { get; set; }

    DateTime? DateUpdated { get; set; }
  }

  public interface ITrackedEntity<TEntity> : ITrackedEntity
  {
    TEntity Id { get; set; }
  }

  public abstract class TrackedEntity<TEntity> : Entity<TEntity>, ITrackedEntity<TEntity>
  {
    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
  }
}