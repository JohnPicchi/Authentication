using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Repository.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityModelConfigurations
{
  internal class ClaimEntityConfiguration : EntityTypeConfiguration<Claim>
  {
    public override void Configure(EntityTypeBuilder<Claim> builder)
    {

    }
  }
}
