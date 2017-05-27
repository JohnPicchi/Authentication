using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authentication.Domain;
using Authentication.PresistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Authentication.Database.Contexts
{
  public abstract class BaseDatabaseContext : DbContext
  {
    public override int SaveChanges()
    {
      SetEntityTimeStamps();
      return base.SaveChanges();
    }

    private void SetEntityTimeStamps()
    {
      ChangeTracker.Entries<ITrackedEntity>()
        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
        .ToList()
        .ForEach(e =>
        {
          if (e.State == EntityState.Added)
            e.Entity.DateCreated = DateTime.UtcNow;
          else
            e.Entity.DateUpdated = DateTime.UtcNow;
        });
    }
  }
}
