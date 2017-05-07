﻿using Authentication.Domain;
using Authentication.PresistenceModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database
{
  public abstract class EntityTypeConfiguration<TEntity>
    where TEntity : class, IPersistedEntity
  {
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
  }
}
