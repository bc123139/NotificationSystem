using Microsoft.Extensions.Logging;
using Notification.Application.Interfaces.Notification;
using Notification.Common.Enums;

namespace Notification.Application.Services.Notification
{
    public class SmsNotificationService : INotificationService
    {
        private readonly ILogger<SmsNotificationService> _logger;
        public NotificationServiceEnum NotificationService => NotificationServiceEnum.Sms;
        public SmsNotificationService(ILogger<SmsNotificationService> logger)
        {
            _logger = logger;
        }
        public void SendNotification(string recipient, string message)
        {
            _logger.LogInformation($"Sms Sent to mobile number {recipient}: {message}");
        }
    }
}
