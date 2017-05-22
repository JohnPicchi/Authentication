using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Utilities.ExtensionMethods
{
  public static class StringExtensionMethods
  {
    public static bool HasValue(this string str) => !string.IsNullOrEmpty(str);

    public static string Hash(this string str) => BCrypt.Net.BCrypt.HashPassword(str);

    public static bool VerifyHash(this string hash, string str) => BCrypt.Net.BCrypt.Verify(str, hash);
  }
}
