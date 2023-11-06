using Notification.Common.Enums;

namespace Notification.Application.Services.Notification.Dto
{
    public class NotificationRequestDto
    {
        public NotificationServiceEnum NotificationService { get; set; }
        public string? Recipient { get; set; }
        public string? Message { get; set; }
    }
}
