using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain
{
  public interface IDomainEntity { }

  public abstract class Entity <TEntity> : IDomainEntity
  {
    public TEntity Id { get; set; }

    public bool IsNew => Comparer<TEntity>.Default.Compare(default(TEntity), Id) == 0;
  }
}
