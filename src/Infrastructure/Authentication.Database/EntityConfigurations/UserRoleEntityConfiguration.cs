using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.PersistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserRoleEntityConfiguration : EntityTypeConfiguration<UserRole>
  {
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
      builder.ToTable(nameof(DatabaseContext.UserRoles));
    }
  }
}