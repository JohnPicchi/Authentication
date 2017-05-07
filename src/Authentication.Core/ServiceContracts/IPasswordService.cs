﻿namespace Authentication.Core.ServiceContracts
{
  public interface IPasswordService
  {
    string HashPassword(string password);

    bool Verify(string password, string passwordHash);
  }
}
