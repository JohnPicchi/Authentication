using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels;
using Authentication.PresistenceModels.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  public class AccountLockConfiguration : EntityTypeConfiguration<AccountLock>
  {
    public override void Configure(EntityTypeBuilder<AccountLock> builder)
    {

      builder.HasOne(p => p.Account)
        .WithMany(p => p.Locks)
        .HasForeignKey(p => p.AccountId)
        .IsRequired(true);

      builder.Property(p => p.Kind)
        .IsRequired(true);

      builder.Property(p => p.Message)
        .IsUnicode(false)
        .IsRequired(false);

      builder.Property(p => p.DateCreated)
        .IsRequired(true);
    }
  }
}
