using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Database.EntityModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database
{
  public abstract class EntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity
  {
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
  }
}
