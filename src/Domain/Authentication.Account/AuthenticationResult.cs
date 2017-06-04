using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Account
{
  public enum AuthenticationStatus
  {
    Fail = 0,
    MultiFactor = 1,
    Sucess = 2,
  }

  public interface IAuthenticationResult
  {
    AuthenticationStatus Status { get; }
    
    string ErrorMessage { get; }
  }

  public class AuthenticationResult : IAuthenticationResult
  {

    public AuthenticationStatus Status { get; set; }

    public string ErrorMessage { get; set; }

    public static IAuthenticationResult Success => new AuthenticationResult { Status = AuthenticationStatus.Sucess };

    public static IAuthenticationResult MultiFactor => new AuthenticationResult { Status = AuthenticationStatus.MultiFactor};

    public static IAuthenticationResult Fail(string message) => new AuthenticationResult {Status = AuthenticationStatus.Fail, ErrorMessage = message};
  }
}