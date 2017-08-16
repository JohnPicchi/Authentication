using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserTokenEntityConfiguration : EntityTypeConfiguration<IdentityUserToken<Guid>>
  {
    public override void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
    {
      builder.ToTable(nameof(DatabaseContext.UserTokens));
    }
  }
}