using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Common;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace Authentication.Database
{
  public class DatabaseContext : IdentityUserContext<User.Models.User, Guid>
  {
    private IDbContextTransaction currentTransaction;

    public DatabaseContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
    {

    }

    public DbSet<UserAddress> UserAddresses { get; set; }

    //public DbSet<User.Models.User> Users { get; set; }
    ////
    //// Summary:
    ////     Gets or sets the Microsoft.EntityFrameworkCore.DbSet`1 of User claims.
    //public DbSet<IdentityUserClaim<Guid>> UserClaims { get; set; }
    //
    //public DbSet<IdentityUserLogin<Guid>> UserLogins { get; set; }
    //
    //public DbSet<IdentityUserToken<Guid>> UserTokens { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //Run ASP.Net's EF identity configuration
      base.OnModelCreating(modelBuilder);

      //Override any ASP.Net EF identity configuration shit 
      //we don't like, like the table names.
      typeof(EntityTypeConfiguration<>).GetTypeInfo()
        .Assembly.GetTypes()
        .Where(t => !t.GetTypeInfo().IsAbstract && t.GetTypeInfo().IsClass)
        .Where(t => t.GetTypeInfo().BaseType.Name.StartsWith(typeof(EntityTypeConfiguration<>).Name))
        .Select(t => Activator.CreateInstance(t) as IEntityConfiguration)
        .ToList()
        .ForEach(i => i.Configure(modelBuilder));
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
      ChangeTracker.Entries<ITrackedPersistedEntity>()
        .Where(e => e.State is EntityState.Added || e.State is EntityState.Modified)
        .ToList()
        .ForEach(e =>
        {
          if (e.State == EntityState.Added)
          {
            e.Entity.DateCreated = DateTime.UtcNow;
            e.Entity.DateUpdated = DateTime.UtcNow;
          }
          else
            e.Entity.DateUpdated = DateTime.UtcNow;
        });
    }
  }

  //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
  //{
  //  public DatabaseContext CreateDbContext(string[] args)
  //  {
  //    var configuration = new ConfigurationBuilder()
  //      .AddJsonFile(@"~\appsettings.json", optional: true, reloadOnChange: true)
  //      .AddEnvironmentVariables()
  //      .Build();
  //
  //    var optionsBuilder = new DbContextOptionsBuilder();
  //    optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Authentication.Dev; Trusted_Connection = True;");
  //    return new DatabaseContext(optionsBuilder.Options);
  //  }
  //}
}
