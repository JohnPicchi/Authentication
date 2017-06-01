using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authentication.Core.Models;
using Authentication.Core.Models.Contracts;
using Authentication.Database.EntityModelConfigurations;
using Authentication.PresistenceModels;
using Authentication.PresistenceModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Authentication.Database.Contexts
{
  public class DatabaseContext : BaseDatabaseContext
  {
    private IApplicationSettings applicationSettings;
    private ILoggerFactory loggerFactory;

    public DatabaseContext(IApplicationSettings applicationSettings, ILoggerFactory loggerFactory)
    {
      this.applicationSettings = applicationSettings;
      this.loggerFactory = loggerFactory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLoggerFactory(loggerFactory);
      optionsBuilder.UseSqlServer(applicationSettings.DbConnectionString, builder =>
      {
        builder.EnableRetryOnFailure();
      });
    }

    public DbSet<PresistenceModels.Models.Account> Accounts { get; set; }

    public DbSet<AccountProperties> AccountProperties { get; set; }

    public DbSet<AccountToken> AccountTokens { get; set; }

    public DbSet<AccountClaim> AccountClaims { get; set; }

    public DbSet<AccountLock> AccountLocks { get; set; }

    public DbSet<PresistenceModels.Models.User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.AddConfiguration(new AccountConfiguration());
      modelBuilder.AddConfiguration(new AccountPropertiesConfiguration());
      modelBuilder.AddConfiguration(new AccountTokenConfiguration());
      modelBuilder.AddConfiguration(new UserConfiguration());
      modelBuilder.AddConfiguration(new AccountClaimConfiguration());
      modelBuilder.AddConfiguration(new AccountLockConfiguration());
    }
  }
}
