using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  public class AccountPropertiesConfiguration : EntityTypeConfiguration<AccountProperties>
  {
    public override void Configure(EntityTypeBuilder<AccountProperties> builder)
    {
      builder.HasOne(p => p.Account)
        .WithOne(p => p.Properties)
        .HasForeignKey<AccountProperties>(p => p.AccountId)
        .IsRequired(true);

      builder.Property(p => p.FailedLoginAttempts)
        .IsRequired(false);

      builder.Property(p => p.CurrentLoginDateTime)
        .IsRequired(false);

      builder.Property(p => p.LastLoginDateTime)
        .IsRequired(false);

      builder.Property(p => p.PasswordResetRequired)
        .IsRequired(false);

      builder.Property(p => p.OpenConnectId)
        .IsRequired(false);
    }
  }
}
