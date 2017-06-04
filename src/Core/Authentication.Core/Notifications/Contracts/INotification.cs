using System.Threading.Tasks;

namespace Authentication.Core.Notifications.Contracts
{
  public interface INotification<TMessage>
  {
    void Handle(TMessage message);
  }

  public interface INotificationAsync<TMessage>
  {
    Task HandleAsync(TMessage message);
  }
}
