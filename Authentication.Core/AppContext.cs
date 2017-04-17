using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Core
{
  public class AppContext
  {
    private static IAppSettings defaultAppSettings;

    public AppContext(IAppSettings appSettings)
    {

    }

    public static IAppSettings AppSettings
    {
      get
      {
        if (defaultAppSettings == null)
          throw new System.ArgumentException("Default AppSettings cannot be null.");

        return defaultAppSettings;
      }
      set
      {
        if (defaultAppSettings == null)
          defaultAppSettings = value;
      }
    }
  }
}
