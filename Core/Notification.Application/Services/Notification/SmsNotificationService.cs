using Microsoft.Extensions.Logging;
using Notification.Application.Interfaces.Notification;

namespace Notification.Application.Services.Notification
{
    public class SmsNotificationService : INotificationService
    {
        private readonly ILogger<SmsNotificationService> _logger;
        public SmsNotificationService(ILogger<SmsNotificationService> logger)
        {
            _logger = logger;
        }
        public void SendNotification(string message)
        {
            _logger.LogInformation($"Sms Notification: {message}");
        }
    }
}
