using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Contracts
{
  public interface IFormResult
  {
    bool Success { get; }

    string ErrorMessage { get; }
  }
}
