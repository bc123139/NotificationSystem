using FluentValidation;

namespace Notification.Application.Services.Notification.Dto
{
    internal class NotificationRequestDtoValidator : AbstractValidator<NotificationRequestDto>
    {
        public NotificationRequestDtoValidator()
        {
            RuleFor(x => x.NotificationService).IsInEnum();
            RuleFor(x=>x.Message).NotEmpty();
            RuleFor(x=>x.Recipient).NotEmpty();
        }
    }
}
