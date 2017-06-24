using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain.PersistenceModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserClaimEntityConfiguration : EntityTypeConfiguration<UserClaim>
  {
    public override void Configure(EntityTypeBuilder<UserClaim> builder)
    {
    }
  }
}