using Notification.Common.Enums;

namespace Notification.Application.Interfaces.Notification
{
    public interface INotificationService
    {
        public NotificationServiceEnum NotificationService { get; }
        void SendNotification(string recipient, string message);
    }
}
