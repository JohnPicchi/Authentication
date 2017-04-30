using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Database.EntityModelConfigurations;
using Authentication.Domain.ModelContracts;
using Authentication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Claim = Authentication.Database.EntityModels.Claim;
using User = Authentication.Database.EntityModels.User;

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

      var applicationSettings = new ApplicationSettings();
      configuration.GetSection("AppSettings").Bind(applicationSettings);
      return new DatabaseContext(applicationSettings);
    }
  }
}
