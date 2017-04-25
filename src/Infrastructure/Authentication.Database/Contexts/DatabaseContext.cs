using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Database.EntityModelConfigurations;
using Authentication.DomainModels.Contracts;
using Authentication.DomainModels.Models;
using Authentication.Repository.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using AppContext = Authentication.DomainModels.Models.AppContext;

namespace Authentication.Database.Contexts
{
  internal class DatabaseContext : BaseDatabaseContext
  {
    private IAppSettings appSettings;

    public DatabaseContext(IAppSettings appSettings)
    {
      this.appSettings = appSettings;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(appSettings.DbConnectionString, builder =>
      {
        builder.EnableRetryOnFailure();
      });
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Claim> Claims { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.AddConfiguration(new UserEntityConfiguration());
      modelBuilder.AddConfiguration(new ClaimEntityConfiguration());
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

      var appSettings = new AppSettings();
      configuration.GetSection("AppSettings").Bind(appSettings);
      return new DatabaseContext(appSettings);
    }
  }
}
