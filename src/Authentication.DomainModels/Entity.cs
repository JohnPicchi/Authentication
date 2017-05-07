using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain
{
  public interface IEntity { }

  public interface IEntity<TEntity> : IEntity
  {
    TEntity Id { get; }

    bool IsNew { get; }
  }

  public class Entity<TEntity> : IEntity<TEntity>
  {
    public TEntity Id { get; set; }

    public bool IsNew => EqualityComparer<TEntity>.Default.Equals(default(TEntity), Id);
  }
}
