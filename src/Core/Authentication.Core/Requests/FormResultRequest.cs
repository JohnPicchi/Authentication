using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.Requests
{
  public class FormResultRequest<TForm> :  IFormResultRequest<TForm>
  {
    private readonly IFormResultRequestHandler<TForm> requestHandler;

    public FormResultRequest(IFormResultRequestHandler<TForm> requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public IFormResult Handle(TForm request) => requestHandler.Handle(request);
  }

  public class FormResultRequestAsync<TForm> : IFormResultRequestAsync<TForm>
  {
    private readonly IFormResultRequestHandlerAsync<TForm> requestHandler;

    public FormResultRequestAsync(IFormResultRequestHandlerAsync<TForm> requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public Task<IFormResult> HandleAsync(TForm request) => requestHandler.HandleAsync(request);
  }
}
