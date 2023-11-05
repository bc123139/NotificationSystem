using Microsoft.AspNetCore.Mvc;
using Notification.Application.Interfaces.Notification;
using Notification.Application.Services.Notification.Dto;

namespace Notification.Api.Controllers
{

    public class NotificationController : BaseController<NotificationController>
    {
        private readonly Dictionary<string, INotificationService> _notificationServices;
        public NotificationController(IEnumerable<INotificationService> notificationServices)
        {
            _notificationServices = notificationServices.ToDictionary(service => service.GetType().Name);
        }

        [HttpPost(nameof(SendNotification))]
        public async Task<ActionResult> SendNotification([FromBody] NotificationRequestDto request)
        {
            if (!_notificationServices.TryGetValue(request.ServiceName, out var notificationService))
            {
                return BadRequest("Invalid notification service.");
            }
            notificationService.SendNotification(request.Message);
            return Ok("Notification sent successfully.");
        }
    }
}
