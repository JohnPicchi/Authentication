using System.Collections.Generic;
using Authentication.Core.RequestHandlers;

namespace Authentication.Core.Requests.Contracts
{
  public interface IFormResult
  {
    FormResultKind Result { get; }

    string ErrorMessage { get; }
  }
}
