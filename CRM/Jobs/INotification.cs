using Abp.Notifications;

namespace CRM.Jobs
{
    public interface INotification
    {
        void Notify(NotificationData data);
    }
}
