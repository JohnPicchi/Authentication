using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Database.EntityModels
{
  public class Entity<TEntity> : IEntity
  {
    public TEntity Id { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
  }
}
