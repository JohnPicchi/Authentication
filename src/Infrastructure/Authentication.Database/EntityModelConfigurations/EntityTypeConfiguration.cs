using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  internal abstract class EntityTypeConfiguration<TEntity>
    where TEntity : class
  {
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
  }
}
