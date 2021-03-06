﻿using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.RequestHandlers.FormHandlers.Contracts
{
  public interface IFormHandlerAsync<TRequest> : IRequestHandlerAsync<TRequest, IFormResult>
  {

  }
}
