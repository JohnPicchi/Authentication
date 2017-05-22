﻿using System.Collections.Generic;

namespace Authentication.Core.Requests.Contracts
{
  public interface IFormResult
  {
    bool Success { get; }

    IList<string> ErrorMessages { get; }
  }
}
