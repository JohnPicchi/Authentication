﻿using System;
using System.Collections.Generic;
using System.Text;
using Authentication.User.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.User.Stores
{
  public interface IRoleStore : 
    IQueryableRoleStore<Role>, 
    IRoleStore<Role>, 
    IDisposable,
    IRoleClaimStore<Role>
  {
  }
}
