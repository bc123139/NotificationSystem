using Microsoft.Extensions.Logging;
using Notification.Application.Interfaces.Notification;

namespace Notification.Application.Services.Notification
{
    public class PushNotificationService : INotificationService
    {
        private readonly ILogger<PushNotificationService> _logger;
        public PushNotificationService(ILogger<PushNotificationService> logger)
        {
            _logger = logger;
        }
        public void SendNotification(string message)
        {
            _logger.LogInformation($"Push Notification: {message}");
        }
    }
}
