using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserAddressEntityConfiguration : EntityTypeConfiguration<UserAddress>
  {
    public override void Configure(EntityTypeBuilder<UserAddress> builder)
    {
      builder.ToTable(nameof(DatabaseContext.UserAddresses));

      builder.HasOne(p => p.User)
        .WithMany(p => p.Address)
        .HasForeignKey(p => p.UserId)
        .IsRequired(true);

      builder.HasIndex(p => p.UserId);

      builder.HasKey(p => new { p.Id, p.UserId });

      builder.Property(p => p.Country)
        .HasMaxLength(256)
        .IsRequired(true);

      builder.Property(p => p.AddressLine1)
        .HasMaxLength(256)
        .IsRequired(true);

      builder.Property(p => p.AddressLine2)
        .HasMaxLength(256)
        .IsRequired(false);

      builder.Property(p => p.Description)
        .HasMaxLength(256)
        .IsRequired(false);

      builder.Property(p => p.StateProvinceRegion)
        .HasMaxLength(256)
        .IsRequired(true);

      builder.Property(p => p.PostalCode)
        .HasMaxLength(64)
        .IsRequired(false);
    }
  }
}
