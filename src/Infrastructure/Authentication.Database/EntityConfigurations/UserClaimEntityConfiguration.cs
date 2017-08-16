using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserClaimEntityConfiguration : EntityTypeConfiguration<IdentityUserClaim<Guid>>
  {
    public override void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
    {
      builder.ToTable(nameof(DatabaseContext.UserClaims));
    }
  }
}