using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Core.Contracts.Handlers;
using Authentication.Core.Contracts.Notifications;

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
}
