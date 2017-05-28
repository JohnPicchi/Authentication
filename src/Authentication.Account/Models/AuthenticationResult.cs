using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Account.Models
{
  public enum AuthenticationStatus
  {
    Fail = 0,
    Success = 1,
    MultiFactor = 2
  }

  public class AuthenticationResult
  {
    public string Message { get; set; }

    public AuthenticationStatus Status { get; set; } = AuthenticationStatus.Fail;

    public static AuthenticationResult Success => new AuthenticationResult
    {
      Status = AuthenticationStatus.Success
    };

    public static AuthenticationResult Fail => new AuthenticationResult
    {
      Status = AuthenticationStatus.Fail,
      Message = "Incorrect username and/or password."
    };
  }
}
