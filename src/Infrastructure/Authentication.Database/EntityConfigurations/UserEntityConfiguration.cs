using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserEntityConfiguration : EntityTypeConfiguration<User.Models.User>
  {
    public override void Configure(EntityTypeBuilder<User.Models.User> builder)
    {
      builder.ToTable(nameof(DatabaseContext.Users));

      builder.HasMany(p => p.Address)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.UserId);

      builder.Property(p => p.FirstName)
        .HasMaxLength(Helper.MaxLength.FirstName)
        .IsRequired(false);

      builder.Property(p => p.LastName)
        .HasMaxLength(Helper.MaxLength.LastName)
        .IsRequired(false);
    }
  }
}