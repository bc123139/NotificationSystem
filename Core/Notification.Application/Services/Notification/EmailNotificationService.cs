using Microsoft.Extensions.Logging;
using Notification.Application.Interfaces.Notification;
using Notification.Common.Enums;

namespace Notification.Application.Services.Notification
{
    public class EmailNotificationService : INotificationService
    {
        private readonly ILogger<EmailNotificationService> _logger;
        public NotificationServiceEnum NotificationService => NotificationServiceEnum.Email;
        public EmailNotificationService(ILogger<EmailNotificationService> logger)
        {
            _logger = logger;
        }
        public void SendNotification(string recipient,string message)
        {
            _logger.LogInformation($"Email Sent to {recipient}: {message}");
        }
    }
}
