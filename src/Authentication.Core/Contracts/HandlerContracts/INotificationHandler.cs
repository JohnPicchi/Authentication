namespace Authentication.Core.Contracts.HandlerContracts
{
  public interface INotificationHandler<TMessage> : IRequestHandler<TMessage>
    where TMessage: INotification
  {

  }

  public interface INotification
  {
    
  }
}