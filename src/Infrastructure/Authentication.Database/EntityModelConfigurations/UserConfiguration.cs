using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  internal class UserConfiguration : EntityTypeConfiguration<User>
  {
    public override void Configure(EntityTypeBuilder<User> builder)
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

      builder.Property(p => p.PhoneNumber)
        .HasMaxLength(32)
        .IsRequired(false)
        .IsUnicode(false);

      builder.HasOne(p => p.Account)
        .WithOne(p => p.User)
        .HasForeignKey<User>(p => p.AccountId);
    }
  }
}
