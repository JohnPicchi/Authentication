using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels;
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

      builder.Property(p => p.CreationTime)
        .IsRequired(true);

      builder.Property(p => p.ExpirationTime)
        .IsRequired(true);

      builder.Property(p => p.Kind)
        .IsRequired(true);

      builder.Property(p => p.Value)
        .IsRequired(true);
    }
  }
}
