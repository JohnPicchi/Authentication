﻿using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Database.EntityConfigurations
{
  public class UserLoginEntityConfiguration : EntityTypeConfiguration<UserLogin>
  {
    public override void Configure(EntityTypeBuilder<UserLogin> builder)
    {
    }
  }
}