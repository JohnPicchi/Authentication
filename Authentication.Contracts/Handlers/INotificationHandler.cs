using System;

namespace Authentication.Contracts.Handlers
{
  public interface INotificationHandler<TMessage>
  {
    void Handle(TMessage message);
  }
}