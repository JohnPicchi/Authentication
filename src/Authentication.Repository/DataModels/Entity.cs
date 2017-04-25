using System;

namespace Authentication.Repository.DataModels
{
  public class Entity<TEntity> : IEntity
  {
    public TEntity Id { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
  }
}
