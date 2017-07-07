using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserLoginEntityConfiguration : EntityTypeConfiguration<IdentityUserLogin<Guid>>
  {
    public override void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
    {
      builder.ToTable(nameof(DatabaseContext.UserLogins));
    }
  }
}