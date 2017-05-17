using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  public class AccountConfiguration : EntityTypeConfiguration<Account>
  {
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
      builder.Property(p => p.Id)
        .IsRequired(true)
        .HasMaxLength(64)
        .IsUnicode(false);

      builder.Property(p => p.Password)
        .IsRequired(true)
        .HasMaxLength(64)
        .IsUnicode(false);

      builder.HasOne(p => p.Properties)
        .WithOne(p => p.Account);

      builder.HasOne(p => p.User)
        .WithOne(p => p.Account);

      builder.HasMany(p => p.Tokens)
        .WithOne(p => p.Account)
        .HasForeignKey(p => p.AccountId);

      builder.HasMany(p => p.Claims)
        .WithOne(p => p.Account)
        .HasForeignKey(p => p.AccountId);
    }
  }
}
