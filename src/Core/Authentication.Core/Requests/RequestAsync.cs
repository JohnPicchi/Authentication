using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.Requests
{
  public class RequestAsync<TReturn> : IRequest<TReturn>
  {
    private readonly IRequestHandler<TReturn> requestHandler;

    public RequestAsync(IRequestHandler<TReturn> requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public Task<TReturn> HandleAsync() => requestHandler.HandleAsync();
  }

  public class RequestAsync<TReturn, TRequest> : IRequest<TReturn, TRequest>
  {
    private readonly IRequestHandler<TRequest, TReturn> requestHandler;

    public RequestAsync(IRequestHandler<TRequest, TReturn> requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public Task<TReturn> HandleAsync(TRequest request) => requestHandler.HandleAsync(request);
  }
}