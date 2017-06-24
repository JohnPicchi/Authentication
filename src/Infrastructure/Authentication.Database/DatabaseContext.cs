using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Database.EntityConfigurations;
using Authentication.Domain.PersistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Authentication.Database
{
  public class DatabaseContext : DbContext
  {
    private IDbContextTransaction currentTransaction;

    public DatabaseContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<UserClaim> UserClaims { get; set; }

    public DbSet<UserLogin> UserLogins { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<UserToken> UserTokens { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<RoleClaim> RoleClaims { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
