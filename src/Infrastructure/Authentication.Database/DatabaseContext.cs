using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Database.EntityConfigurations;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Authentication.Database
{
  public class DatabaseContext : IdentityDbContext<User.Models.User, Role, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, UserLogin, IdentityRoleClaim<Guid>, UserToken>
  {
    private IDbContextTransaction currentTransaction;

    public DatabaseContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.AddConfiguration(new RoleClaimEntityConfiguration());
      modelBuilder.AddConfiguration(new RoleEntityConfiguration());
      modelBuilder.AddConfiguration(new UserClaimEntityConfiguration());
      modelBuilder.AddConfiguration(new UserEntityConfiguration());
      modelBuilder.AddConfiguration(new UserLoginEntityConfiguration());
      modelBuilder.AddConfiguration(new UserRoleEntityConfiguration());
      modelBuilder.AddConfiguration(new UserTokenEntityConfiguration());
    }

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
      //SetEntityTimeStamps();
      return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
      //SetEntityTimeStamps();
      return base.SaveChanges();
    }

    //private void SetEntityTimeStamps()
    //{
    //  ChangeTracker.Entries<ITrackedEntity>()
    //    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
    //    .ToList()
    //    .ForEach(e =>
    //    {
    //      if (e.State == EntityState.Added && e.Entity.DateCreated == null)
    //        e.Entity.DateCreated = DateTime.UtcNow;
    //      else
    //        e.Entity.DateUpdated = DateTime.UtcNow;
    //    });
    //}
  }
}
