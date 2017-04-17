using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Core
{
  public interface IAppSettings
  {
    string DbConnectionString { get; }
  }
}
