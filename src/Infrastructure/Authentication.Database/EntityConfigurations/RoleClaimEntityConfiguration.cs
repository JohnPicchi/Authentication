using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.PersistenceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class RoleClaimEntityConfiguration : EntityTypeConfiguration<RoleClaim>
  {
    public override void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
      builder.ToTable(nameof(DatabaseContext.RoleClaims));
    }
  }
}