using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authentication.Database.EntityConfigurations;
using Authentication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Authentication.Database.Contexts
{
  public class DatabaseContext : BaseDatabaseContext
  {
    public DatabaseContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
    {
    }

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
  }
}
