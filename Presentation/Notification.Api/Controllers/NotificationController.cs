using Microsoft.AspNetCore.Mvc;
using Notification.Application.Interfaces.Notification;
using Notification.Application.Services.Notification.Dto;

namespace Notification.Api.Controllers
{

    public class NotificationController : BaseController<NotificationController>
    {
        private readonly IEnumerable<INotificationService> _notificationServices;
        public NotificationController(IEnumerable<INotificationService> notificationServices)
        {
            _notificationServices = notificationServices;
        }

        [HttpPost(nameof(SendNotification))]
        public async Task<ActionResult> SendNotification([FromBody] NotificationRequestDto request)
        {
            var service = _notificationServices.FirstOrDefault(c => c.NotificationService == request.NotificationService);
            if (service is null)
            {
                return BadRequest("Invalid notification service.");
            }
            service.SendNotification(request.Recipient,request.Message);
            return Ok("Notification sent successfully.");
        }
    }
}
