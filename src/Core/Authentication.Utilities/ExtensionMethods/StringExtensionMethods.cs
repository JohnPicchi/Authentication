using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Utilities.ExtensionMethods
{
  public static class StringExtensionMethods
  {
    public static bool HasValue(this string self) => !string.IsNullOrEmpty(self);

    public static Guid ToGuid(this string self) => new Guid(self);
  }
}
