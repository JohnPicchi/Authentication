namespace Authentication.Contracts.Notifications
{
  public interface INotification<TMessage>
  {
    void Handle(TMessage message);
  }
}
