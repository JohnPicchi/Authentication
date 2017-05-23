using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Core.Models;
using Authentication.Core.Models.Contracts;
using Authentication.Database.EntityModelConfigurations;
using Authentication.PresistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;


namespace Authentication.Database.Contexts
{
  internal class DatabaseContext : BaseDatabaseContext
  {
    private IApplicationSettings applicationSettings;

    public DatabaseContext(IApplicationSettings applicationSettings)
    {
      this.applicationSettings = applicationSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(applicationSettings.DbConnectionString, builder =>
      {
        builder.EnableRetryOnFailure();
      });
    }

    public DbSet<PresistenceModels.Account> Accounts { get; set; }

    public DbSet<AccountProperties> AccountProperties { get; set; }

    public DbSet<AccountToken> AccountTokens { get; set; }

    public DbSet<PresistenceModels.User> Users { get; set; }

    public DbSet<Claim> Claims { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.AddConfiguration(new AccountConfiguration());
      modelBuilder.AddConfiguration(new AccountPropertiesConfiguration());
      modelBuilder.AddConfiguration(new AccountTokenConfiguration());
      modelBuilder.AddConfiguration(new UserConfiguration());
      modelBuilder.AddConfiguration(new ClaimConfiguration());
    }
  }

  //Used by Migrations
  internal class DbContextFactory : IDbContextFactory<DatabaseContext>
  {
    public DatabaseContext Create(DbContextFactoryOptions options) => Create(options.ContentRootPath, options.EnvironmentName);

    private DatabaseContext Create(string basePath, string env)
    {
      var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
        .SetBasePath(basePath)
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{env}.json", true)
        .AddEnvironmentVariables();
      var configuration = builder.Build();

      var applicationSettings = new ApplicationSettings();
      configuration.GetSection("AppSettings").Bind(applicationSettings);
      return new DatabaseContext(applicationSettings);
    }
  }
}
