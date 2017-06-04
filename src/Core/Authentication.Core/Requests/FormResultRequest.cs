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
}
