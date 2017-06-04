using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Core.RequestHandlers.Contracts
{
  public interface IFormResult
  {
    bool Success { get; }

    string ErrorMessage { get; }
  }
}
