using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain
{
  public interface IDomainEntity
  {
    bool IsNew { get; }

    bool IsDirty { get; set; }
  }

  public interface IDomainEntity<TEntity> : IDomainEntity
  {
    TEntity Id { get; }
  }

  public abstract class DomainEntity <TEntity> : IDomainEntity<TEntity>
  {
    public TEntity Id { get; set; }

    public bool IsNew => Comparer<TEntity>.Default.Compare(default(TEntity), Id) == 0;

    public virtual bool IsDirty { get; set; }
  }
}
