using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserEntityConfiguration : EntityTypeConfiguration<User>
  {
    public override void Configure(EntityTypeBuilder<User> builder)
    {
    }
  }
}