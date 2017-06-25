using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.PersistenceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserEntityConfiguration : EntityTypeConfiguration<User.PersistenceModels.User>
  {
    public override void Configure(EntityTypeBuilder<User.PersistenceModels.User> builder)
    {
      builder.ToTable(nameof(DatabaseContext.Users));
    }
  }
}