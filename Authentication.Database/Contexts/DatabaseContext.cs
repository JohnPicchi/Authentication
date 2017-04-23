using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Database.EntityModelConfigurations;
using Authentication.DomainModels.Contracts;
using Authentication.Repository.DataModels;
using Microsoft.EntityFrameworkCore;
using AppContext = Authentication.DomainModels.Models.AppContext;

namespace Authentication.Database.Contexts
{
  internal class DatabaseContext : BaseDatabaseContext
  {
    private readonly IAppSettings appSettings;

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
}
