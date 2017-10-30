using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.FormHandlers.Account;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.Requests
{
  public class ConfirmEmailRequest : IRequest<GenericResult>
  {
    private readonly ConfirmEmailRequestHandler requestHandler;

    public ConfirmEmailRequest(ConfirmEmailRequestHandler requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public async Task<GenericResult> HandleAsync() => await requestHandler.HandleAsync();
  }
}