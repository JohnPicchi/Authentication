using Authentication.Core.Contracts;
using Authentication.Core.Contracts.Handlers;
using Authentication.Core.Contracts.Requests;

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
}
