using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.PersistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class RoleEntityConfiguration : EntityTypeConfiguration<Role>
  {
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.ToTable(nameof(DatabaseContext.Roles));
    }
  }
}