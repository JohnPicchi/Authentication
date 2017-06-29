using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserEntityConfiguration : EntityTypeConfiguration<User.Models.User>
  {
    public override void Configure(EntityTypeBuilder<User.Models.User> builder)
    {
      builder.ToTable(nameof(DatabaseContext.Users));
    }
  }
}