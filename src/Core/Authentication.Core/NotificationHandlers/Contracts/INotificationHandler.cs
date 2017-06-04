using System.Threading.Tasks;

namespace Authentication.Core.NotificationHandlers.Contracts
{
  public interface INotificationHandler<TMessage>
  {
    void Handle(TMessage message);
  }

  public interface INotificationHandlerAsync<TMessage>
  {
    Task HandleAsync(TMessage message);
  }
}