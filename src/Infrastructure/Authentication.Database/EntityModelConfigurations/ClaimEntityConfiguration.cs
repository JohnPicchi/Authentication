using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Repository.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  internal class ClaimEntityConfiguration : EntityTypeConfiguration<Claim>
  {
    public override void Configure(EntityTypeBuilder<Claim> builder)
    {
      builder.HasOne(p => p.User)
        .WithMany(p => p.Claims)
        .HasForeignKey(p => p.UserId)
        .IsRequired(true);

      builder.Property(p => p.Type)
        .IsRequired(true)
        .HasMaxLength(128)
        .IsUnicode(false);

      builder.Property(p => p.Value)
        .IsRequired(true)
        .HasMaxLength(128)
        .IsUnicode(false);

      builder.Property(p => p.ValueType)
        .IsRequired(true)
        .HasMaxLength(128)
        .IsUnicode(false);

      builder.Property(p => p.Issuer)
        .IsRequired(true)
        .HasMaxLength(128)
        .IsUnicode();
    }
  }
}
