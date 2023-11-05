using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Interfaces.Notification;
using Notification.Application.Services.Notification;
using Notification.Application.Services.Notification.Dto;

namespace Notification.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<INotificationService, SmsNotificationService>();
            services.AddSingleton<INotificationService, EmailNotificationService>();
            services.AddSingleton<INotificationService, PushNotificationService>();
            services.AddValidations();
            return services;
        }
        private static void AddValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidator<NotificationRequestDto>, NotificationRequestDtoValidator>();
        }
    }
}
