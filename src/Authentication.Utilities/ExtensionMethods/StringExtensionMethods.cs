using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Utilities.ExtensionMethods
{
  public static class StringExtensionMethods
  {
    public static bool HasValue(this string str) => !string.IsNullOrEmpty(str);
  }
}
