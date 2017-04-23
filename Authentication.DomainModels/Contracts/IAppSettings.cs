using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.DomainModels.Contracts
{
  public interface IAppSettings
  {
    string DbConnectionString { get; }
  }
}
