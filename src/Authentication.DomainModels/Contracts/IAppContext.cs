using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.DomainModels.Contracts
{
  public interface IAppContext
  {
    IAppSettings AppSettings { get; }

    IAppUser AppUser { get; }
  }
}
