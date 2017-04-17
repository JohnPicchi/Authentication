using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Database.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database.Contexts
{
  internal class DatabaseContext : BaseDatabaseContext
  {
    public DbSet<User> Users { get; set; }

    public DbSet<Claim> Claims { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
  }
}
