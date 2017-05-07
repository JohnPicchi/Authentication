using System;
using System.Collections.Generic;

namespace Authentication.Account.Models
{
  public class Account 
  {
    public string Username { get; set; }

    public string Password { get; set; }

    public IEnumerable<Token> Tokens { get; set; }

    public AccountProperties Properties { get; set; }

    public bool IsAuthenticated { get; private set; }

    public bool IsLocked { get; set; }

    public bool IsVerified { get; set; }

    public bool Authenticate(string password)
    {
      if (IsLocked)
        return false;

      if (password == Password)
      {
        Properties.FailedLoginAttempts = 0;
        Properties.LastLogin = Properties.CurrentLogin;
        Properties.CurrentLogin = DateTime.UtcNow;
        IsAuthenticated = true;
        return true;
      }

      Properties.FailedLoginAttempts += 1;
      if (Properties.FailedLoginAttempts >= 5)    //TODO: Failed Login # needs to be added to DB
        IsLocked = true;
      
      return false;
    }
  }
}