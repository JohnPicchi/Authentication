using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.Requests
{
  public class FormResultRequest<TForm> : IFormResultRequest<TForm>
  {
    private readonly IFormHandler<TForm> requestHandler;

    public FormResultRequest(IFormHandler<TForm> requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public Task<IFormResult> HandleAsync(TForm request) => requestHandler.HandleAsync(request);
  }
}
