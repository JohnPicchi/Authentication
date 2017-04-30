using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  internal class UserEntityConfiguration : EntityTypeConfiguration<EntityModels.User>
  {
    public override void Configure(EntityTypeBuilder<EntityModels.User> builder)
    {

      builder.Property(p => p.FirstName)
        .HasMaxLength(32)
        .IsRequired(true)
        .IsUnicode(false);  //Map to varchar instead of nvarchar

      builder.Property(p => p.LastName)
        .HasMaxLength(32)
        .IsRequired(false)
        .IsUnicode(false);  //Map to varchar instead of nvarchar

      builder.Property(p => p.Email)
        .HasMaxLength(64)
        .IsRequired(true)
        .IsUnicode(false);

      builder.Property(p => p.Password)
        .HasMaxLength(128)
        .IsRequired(true)
        .IsUnicode(false);

      builder.Property(p => p.OpenConnectId)
        .IsRequired();

      builder.HasMany(p => p.Claims)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.UserId);
    }
  }
}
