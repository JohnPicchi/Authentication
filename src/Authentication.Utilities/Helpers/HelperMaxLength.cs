using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Utilities.Helpers
{
  public static partial class Helper
  {
    public struct MaxLength
    {
      public const int AccountToken = 256;

      public const int Email = 256;
      public const int Password = 256;
      public const int FirstName = 128;
      public const int LastName = 128;
      public const int PhoneNumber = 32;

      public const int ClaimType = 256;
      public const int ClaimValue = 256;
      public const int ClaimValueType = 256;
      public const int ClaimIssuer = 256;
    }
  }
}
