using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Account
{
  public enum AuthenticationStatus
  {
    Fail = 0,
    Sucess = 1,
    MultiFactor = 2
  }
}