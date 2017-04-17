using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Database.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database
{
  public static class ModelBuilderExtensions
  {
    public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
      where TEntity : class, IEntity
    {
      configuration.Configure(modelBuilder.Entity<TEntity>());
    }
  }
}
