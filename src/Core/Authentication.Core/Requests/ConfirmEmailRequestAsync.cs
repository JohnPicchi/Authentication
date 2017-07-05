using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.Requests
{
  public class ConfirmEmailRequestAsync : IRequestAsync<GenericResult>
  {
    private readonly ConfirmEmailRequestHandlerAsync requestHandler;

    public ConfirmEmailRequestAsync(ConfirmEmailRequestHandlerAsync requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public async Task<GenericResult> HandleAsync() => await requestHandler.HandleAsync();
  }
}