using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Authentication.PresistenceModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Authentication.Database.Contexts
{
  public abstract class BaseDatabaseContext : DbContext
  {
    private IDbContextTransaction currentTransaction;

    public void BeginTransaction()
    {
      if (currentTransaction != null)
        currentTransaction = Database.BeginTransaction(IsolationLevel.ReadCommitted);
    }

    public async Task CommitTransactionAsync()
    {
      try
      {
        await SaveChangesAsync();
        currentTransaction?.Commit();
      }
      catch
      {
        RollbackTransaction();
        throw;
      }
      finally
      {
        if (currentTransaction != null)
        {
          currentTransaction.Dispose();
          currentTransaction = null;
        }
      }
    }

    public void RollbackTransaction()
    {
      try
      {
        currentTransaction?.Rollback();
      }
      finally
      {
        if (currentTransaction != null)
        {
          currentTransaction.Dispose();
          currentTransaction = null;
        }
      }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      SetEntityTimeStamps();
      return base.SaveChangesAsync(cancellationToken);
    }

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
