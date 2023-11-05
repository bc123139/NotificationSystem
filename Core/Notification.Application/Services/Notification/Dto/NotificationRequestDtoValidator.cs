using FluentValidation;

namespace Notification.Application.Services.Notification.Dto
{
    internal class NotificationRequestDtoValidator : AbstractValidator<NotificationRequestDto>
    {
        public NotificationRequestDtoValidator()
        {
            RuleFor(x => x.ServiceName).NotEmpty();
            RuleFor(x=>x.Message).NotEmpty();
        }
    }
}
