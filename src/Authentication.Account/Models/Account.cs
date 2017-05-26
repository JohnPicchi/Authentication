using System;
using System.Collections.Generic;
using Authentication.Domain;
using Authentication.User;


namespace Authentication.Account.Models
{
  public class Account : Entity<Guid>
  {
    private readonly IAccountRepository accountRepository;
    private readonly IUserFactory userFactory;
    private readonly IUserRepository userRepository;

    private User.Models.User user;
    private Properties properties;
    private IList<Token> tokens;

    public Account(
      IAccountRepository accountRepository, 
      IUserFactory userFactory, 
      IUserRepository userRepository)
    {
      this.accountRepository = accountRepository;
      this.userFactory = userFactory;
      this.userRepository = userRepository;
    }

    public string Username { get; set; }

    public string Password { get; set; }

    public Properties Properties
    {
      get => properties ?? (properties = this.IsNew
               ? new Properties()
               : accountRepository.AccountProperties(this.Id));

      set => properties = value;
    } 

    public User.Models.User User
    {
      get => user ?? (user = this.IsNew
               ? userFactory.Create()
               : null);   //TODO

      set => user = value;
    }

    public IList<Token> Tokens
    {
      get => tokens ?? (tokens = this.IsNew
               ? new List<Token>()
               : accountRepository.AccountTokens(this.Id));

      set => tokens = value;
    } 

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

    public void UpdatePassword(string password) => Password = BCrypt.Net.BCrypt.HashPassword(password);

    private bool VerifyPassword(string password) => BCrypt.Net.BCrypt.Verify(password, Password);

    public bool ValidateToken(string token, TokenKind tokenKind)
    {
      return false;
    }
  }
}