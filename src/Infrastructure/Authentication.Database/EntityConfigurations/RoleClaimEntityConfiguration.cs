using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class RoleClaimEntityConfiguration : EntityTypeConfiguration<IdentityRoleClaim<Guid>>
  {
    public override void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
      builder.ToTable(nameof(DatabaseContext.RoleClaims));
    }
  }
}