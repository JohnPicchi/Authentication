using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels;
using Authentication.PresistenceModels.Models;
using Authentication.Utilities.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  internal class AccountClaimConfiguration : EntityTypeConfiguration<AccountClaim>
  {
    public override void Configure(EntityTypeBuilder<AccountClaim> builder)
    {
      builder.HasOne(p => p.Account)
        .WithMany(p => p.Claims)
        .HasForeignKey(p => p.AccountId)
        .IsRequired(true);

      builder.Property(p => p.Type)
        .IsRequired(true)
        .HasMaxLength(Helper.MaxLength.ClaimType)
        .IsUnicode(false);

      builder.Property(p => p.Value)
        .IsRequired(true)
        .HasMaxLength(Helper.MaxLength.ClaimValue)
        .IsUnicode(false);

      builder.Property(p => p.ValueType)
        .IsRequired(true)
        .HasMaxLength(Helper.MaxLength.ClaimValueType)
        .IsUnicode(false);

      builder.Property(p => p.Issuer)
        .IsRequired(true)
        .HasMaxLength(Helper.MaxLength.ClaimIssuer)
        .IsUnicode(false);
    }
  }
}
