using System;
using System.Collections.Generic;
using System.Text;
using Authentication.PresistenceModels;
using Authentication.Utilities.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  internal class UserConfiguration : EntityTypeConfiguration<User>
  {
    public override void Configure(EntityTypeBuilder<User> builder)
    {
      builder.Property(p => p.FirstName)
        .HasMaxLength(Helper.MaxLength.FirstName)
        .IsRequired(false)
        .IsUnicode(false);  //Map to varchar instead of nvarchar

      builder.Property(p => p.LastName)
        .HasMaxLength(Helper.MaxLength.LastName)
        .IsRequired(false)
        .IsUnicode(false);  //Map to varchar instead of nvarchar

      builder.Property(p => p.Email)
        .HasMaxLength(Helper.MaxLength.Email)
        .IsRequired(false)
        .IsUnicode(false);

      builder.Property(p => p.PhoneNumber)
        .HasMaxLength(Helper.MaxLength.PhoneNumber)
        .IsRequired(false)
        .IsUnicode(false);

      builder.HasOne(p => p.Account)
        .WithOne(p => p.User)
        .HasForeignKey<User>(p => p.AccountId);
    }
  }
}
