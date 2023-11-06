using Microsoft.Extensions.Logging;
using Notification.Application.Interfaces.Notification;
using Notification.Common.Enums;

namespace Notification.Application.Services.Notification
{
    public class PushNotificationService : INotificationService
    {
        private readonly ILogger<PushNotificationService> _logger;
        public NotificationServiceEnum NotificationService => NotificationServiceEnum.PushNotification;
        public PushNotificationService(ILogger<PushNotificationService> logger)
        {
            _logger = logger;
        }
        public void SendNotification(string recipient, string message)
        {
            _logger.LogInformation($"Push Notification Sent to {recipient} Device : {message}");
        }
    }
}
