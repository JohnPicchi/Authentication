﻿namespace Authentication.Contracts.Services
{
  public interface IPasswordService
  {
    string HashPassword(string password);

    bool Verify(string password, string passwordHash);
  }
}
