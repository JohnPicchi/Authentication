using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database
{
  public interface IEntityConfiguration
  {
    void Configure(ModelBuilder builder);
  }

  public abstract class EntityTypeConfiguration<TEntity> : IEntityConfiguration
    where TEntity : class
  {
    public void Configure(ModelBuilder builder)
    {
      Configure(builder.Entity<TEntity>());
    }

    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
  }
}