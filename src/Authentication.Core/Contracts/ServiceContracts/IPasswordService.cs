namespace Authentication.Core.Contracts.ServiceContracts
{
  public interface IPasswordService
  {
    string HashPassword(string password);

    bool Verify(string password, string passwordHash);
  }
}
