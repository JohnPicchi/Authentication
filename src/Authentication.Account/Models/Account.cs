using System;
using System.Collections.Generic;
using Authentication.Domain;
using Authentication.User;


namespace Authentication.Account.Models
{
  public class Account : Entity<Guid>
  {
    private readonly IUserFactory userFactory;
    private readonly IUserRepository userRepository;

    private User.Models.User user;

    public Account(IUserFactory userFactory, IUserRepository userRepository)
    {
      this.userFactory = userFactory;
      this.userRepository = userRepository;
    }

    public string Username { get; set; }

    public string Password { get; set; }

    public Properties Properties { get; set; } = new Properties();

    public User.Models.User User
    {
      get => user ?? (user = this.IsNew
               ? userFactory.Create()
               : null);   //TODO

      set => user = value;
    }

    public IList<Token> Tokens { get; set; } = new List<Token>();

    public bool IsAuthenticated { get; private set; }

    public bool Authenticate(string password)
    {
      if (Properties.Locked)
        return false;

      if (VerifyPassword(password))
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

    private bool VerifyPassword(string password) => BCrypt.Net.BCrypt.Verify(password, Password);

    public bool ValidateToken(string token, TokenKind tokenKind)
    {
      return false;
    }
  }
}