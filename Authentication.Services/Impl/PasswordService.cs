using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Authentication.Core.Contracts;
using Authentication.Database;

namespace Authentication.Services
{
  public class PasswordService : IPasswordService
  {
    private IRepository repository;

    public PasswordService(IRepository repository)
    {
      this.repository = repository;
    }

    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, string passwordHash) => BCrypt.Net.BCrypt.Verify(password, passwordHash);
  }
}
