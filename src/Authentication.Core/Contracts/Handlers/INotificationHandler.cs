namespace Authentication.Core.Contracts.Handlers
{
  public interface INotificationHandler<TMessage>
  {
    void Handle(TMessage message);
  }
}