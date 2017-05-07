using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain;
using Authentication.PresistenceModels;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database
{
  public static class ModelBuilderExtensions
  {
    internal static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
      where TEntity : class, IPersistedEntity
    {
      configuration.Configure(modelBuilder.Entity<TEntity>());
    }
  }
}
