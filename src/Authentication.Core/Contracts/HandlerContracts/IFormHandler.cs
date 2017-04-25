using Authentication.Core.Handlers.FormHandlers;

namespace Authentication.Core.Contracts.HandlerContracts
{
  public interface IFormHandler<TForm> : IHandler<TForm, IFormResult>
  {

  }
}
