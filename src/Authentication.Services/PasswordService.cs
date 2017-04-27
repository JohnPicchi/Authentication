using Authentication.Core.Contracts.Services;

namespace Authentication.Services
{
  public class PasswordService : IPasswordService
  {
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, string passwordHash) => BCrypt.Net.BCrypt.Verify(password, passwordHash);
  }
}
