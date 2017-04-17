using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Authentication.Core
{
  public class AppSettings : IAppSettings
  {
    private const string APP_SETTINGS_SECTION = "AppSettings";

    public AppSettings(IConfigurationRoot configuration)
    {
      configuration.GetSection(APP_SETTINGS_SECTION).Bind(this);
    }

    public string DbConnectionString { get; set; }
  }
}
