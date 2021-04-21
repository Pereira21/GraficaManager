using DevIO.Business.Notifications;
using System.Collections.Generic;

namespace DevIO.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
