using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Common
{
  public interface ITrackedPersistedEntity
  {
    bool IsNew { get; }

    DateTime? DateCreated { get; set; }

    DateTime? DateUpdated { get; set; }
  }

  public interface ITrackedPersistedEntity<TId> : ITrackedPersistedEntity
  {
    TId Id { get; set; }
  }

  public abstract class TrackedPersistedEntity<TId> : ITrackedPersistedEntity<TId>
  {
    public TId Id { get; set; }

    public bool IsNew => EqualityComparer<TId>.Default.Equals(this.Id, default(TId));

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
  }
}
