using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels;
using Authentication.PresistenceModels.Models;
using Authentication.Utilities.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  public class AccountTokenConfiguration : EntityTypeConfiguration<AccountToken>
  {
    public override void Configure(EntityTypeBuilder<AccountToken> builder)
    {
      builder.HasOne(p => p.Account)
        .WithMany(p => p.Tokens)
        .HasForeignKey(p => p.AccountId)
        .IsRequired(true);

      builder.Property(p => p.DateCreated)
        .IsRequired(true);

      builder.Property(p => p.ExpirationDate)
        .IsRequired(true);

      builder.Property(p => p.Kind)
        .IsRequired(true);

      builder.Property(p => p.Value)
        .HasMaxLength(Helper.MaxLength.AccountToken)
        .IsRequired(true);
    }
  }
}
