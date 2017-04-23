using Authentication.Core.Handlers.FormHandlers;

namespace Authentication.Core.Contracts.HandlerContracts
{
  public interface IFormHandler<TForm>
  {
    IFormResult Handle(TForm form);
  }
}
