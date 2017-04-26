using Authentication.Core.Contracts.HandlerContracts;
using Authentication.Core.Handlers.RequestHandlers.FormResults;

namespace Authentication.Core.Requests
{
  public interface IFormResultRequest<TRequest> : IRequest<IFormResult, TRequest>
  {
  }

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
