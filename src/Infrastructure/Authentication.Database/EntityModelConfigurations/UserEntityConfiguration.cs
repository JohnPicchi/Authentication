using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Repository.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  internal class UserEntityConfiguration : EntityTypeConfiguration<User>
  {
    public override void Configure(EntityTypeBuilder<User> builder)
    {

    }
  }
}
