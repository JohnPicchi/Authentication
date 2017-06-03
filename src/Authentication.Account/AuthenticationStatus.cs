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

  public interface IAuthenticationResult
  {
    AuthenticationStatus Status { get; }
    
    string Message { get; }
  }

  public class AuthenticationResult : IAuthenticationResult
  {

    public AuthenticationStatus Status { get; set; }

    public string Message { get; set; }

    public static IAuthenticationResult Success => new AuthenticationResult { Status = AuthenticationStatus.Sucess };

    public static IAuthenticationResult Fail(string message) => new AuthenticationResult {Status = AuthenticationStatus.Fail, Message = message};
  }
}