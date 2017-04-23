namespace Authentication.Core.Contracts.HandlerContracts
{
  public interface INotificationHandler<TMessage> : IHandler<TMessage>
    where TMessage: INotification
  {

  }

  public interface INotification
  {
    
  }
}
