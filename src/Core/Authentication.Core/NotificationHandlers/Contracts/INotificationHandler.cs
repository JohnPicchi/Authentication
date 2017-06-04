namespace Authentication.Core.NotificationHandlers.Contracts
{
  public interface INotificationHandler<TMessage>
  {
    void Handle(TMessage message);
  }
}