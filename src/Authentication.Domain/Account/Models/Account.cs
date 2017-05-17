using System;
using System.Collections.Generic;

namespace Authentication.Domain.Account.Models
{
  public class Account
  {

    #region Properties

    public string Id { get; set; }

    public string Password { get; set; }

    public AccountProperties Properties { get; set; }

    public IEnumerable<Token> Tokens { get; set; }

    public bool IsAuthenticated { get; private set; }

    #endregion Properties


    public bool Authenticate(string password)
    {
      if (Properties.Locked)
        return false;

      if (password == Password)
      {
        Properties.FailedLoginAttempts = 0;
        if (false)
        {
          //TODO
        }
        else
        {
          Properties.LastLogin = Properties.CurrentLogin;
          Properties.CurrentLogin = DateTime.UtcNow;
          IsAuthenticated = true;
          return true;
        }
      }

      Properties.FailedLoginAttempts += 1;
      if (Properties.FailedLoginAttempts >= 5)    //TODO: Failed Login # needs to be added to DB
        Properties.Locked = true;
      
      return false;
    }

    public bool ValidateToken(string token, TokenKind tokenKind)
    {
      return false;
    }
  }
}