namespace Authentication.Core.Notifications.Contracts
{
  public interface INotification<TMessage>
  {
    void Handle(TMessage message);
  }
}
