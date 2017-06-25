using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.PersistenceModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserRoleEntityConfiguration : EntityTypeConfiguration<IdentityUserRole<Guid>>
  {
    public override void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
      builder.ToTable(nameof(DatabaseContext.UserRoles));
    }
  }
}