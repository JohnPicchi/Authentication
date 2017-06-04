using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database
{
  public static class ModelBuilderExtensions
  {
    internal static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
      where TEntity : class, IEntity
    {
      configuration.Configure(modelBuilder.Entity<TEntity>());
    }
  }
}
