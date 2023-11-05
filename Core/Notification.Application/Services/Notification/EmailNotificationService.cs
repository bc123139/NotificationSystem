using Microsoft.Extensions.Logging;
using Notification.Application.Interfaces.Notification;

namespace Notification.Application.Services.Notification
{
    public class EmailNotificationService : INotificationService
    {
        private readonly ILogger<EmailNotificationService> _logger;
        public EmailNotificationService(ILogger<EmailNotificationService> logger)
        {
            _logger = logger;
        }
        public void SendNotification(string message)
        {
            _logger.LogInformation($"Email Notification: {message}");
        }
    }
}
