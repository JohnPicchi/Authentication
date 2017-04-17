using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authentication.Core.Helpers;
using Authentication.Database.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database.Contexts
{
  public abstract class BaseDatabaseContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(Core.AppContext.AppSettings.DbConnectionString, builder =>
      {
        builder.EnableRetryOnFailure();
      });
    }

    public override int SaveChanges()
    {
      SetEntityTimeStamps();
      return base.SaveChanges();
    }

    private void SetEntityTimeStamps()
    {
      ChangeTracker.Entries<IEntity>()
        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
        .ToList()
        .ForEach(e =>
        {
          if (e.State == EntityState.Added)
            e.Entity.DateCreated = Helpers.DateTime.EstNow;
          else
            e.Entity.DateUpdated = Helpers.DateTime.EstNow;
        });
    }
  }
}
