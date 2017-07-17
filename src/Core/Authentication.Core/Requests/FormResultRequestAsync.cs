using System.Threading.Tasks;
using Authentication.Core.RequestHandlers.Contracts;
using Authentication.Core.RequestHandlers.FormHandlers.Contracts;
using Authentication.Core.Requests.Contracts;

namespace Authentication.Core.Requests
{
  public class FormResultRequestAsync<TForm> : IFormResultRequestAsync<TForm>
  {
    private readonly IFormHandlerAsync<TForm> requestHandler;

    public FormResultRequestAsync(IFormHandlerAsync<TForm> requestHandler)
    {
      this.requestHandler = requestHandler;
    }

    public Task<IFormResult> HandleAsync(TForm request) => requestHandler.HandleAsync(request);
  }
}
