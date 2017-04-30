using System;
using Authentication.Core.Contracts;

namespace Authentication.Database.EntityModels
{
  public abstract class Entity<TEntity> : IEntity
  {
    public TEntity Id { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
  }
}
