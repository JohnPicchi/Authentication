using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Core.NotificationHandlers.Contracts;
using Authentication.Core.Notifications.Contracts;

namespace Authentication.Core.Notifications
{
  public class Notification<TMessage> : INotification<TMessage>
  {
    private readonly INotificationHandler<TMessage> notificationHandler;

    public Notification(INotificationHandler<TMessage> notificationHandler)
    {
      this.notificationHandler = notificationHandler;
    }

    public void Handle(TMessage message) => notificationHandler.Handle(message);
  }

  public class NotificationAsync<TMessage> : INotificationAsync<TMessage>
  {
    private readonly INotificationHandlerAsync<TMessage> notificationHandler;

    public NotificationAsync(INotificationHandlerAsync<TMessage> notificationHandler)
    {
      this.notificationHandler = notificationHandler;
    }

    public Task HandleAsync(TMessage message) => notificationHandler.HandleAsync(message);
  }
}
