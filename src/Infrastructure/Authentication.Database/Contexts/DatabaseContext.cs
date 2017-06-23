using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Authentication.Database.Contexts
{
  public class DatabaseContext : BaseDatabaseContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.AddConfiguration(new AccountConfiguration());
      //modelBuilder.AddConfiguration(new AccountPropertiesConfiguration());
      //modelBuilder.AddConfiguration(new AccountTokenConfiguration());
      //modelBuilder.AddConfiguration(new UserConfiguration());
      //modelBuilder.AddConfiguration(new AccountClaimConfiguration());
      //modelBuilder.AddConfiguration(new AccountLockConfiguration());
    }
  }
}
