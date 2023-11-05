using Microsoft.OpenApi.Models;
using Notification.Api.Filters;
using Notification.Common.Options;

namespace Notification.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = SwaggerOptions.Description, Version = "v1" });
                x.OperationFilter<HeaderFilter>();
            });
        }

        public static void ResolveSwaggerOptions(this IServiceCollection services, IConfiguration configuration)
        {
            SwaggerOptions.JsonRoute = configuration.GetSection(nameof(SwaggerOptions)).GetValue<string>(nameof(SwaggerOptions.JsonRoute))!;
            SwaggerOptions.UiEndPoint = configuration.GetSection(nameof(SwaggerOptions)).GetValue<string>(nameof(SwaggerOptions.UiEndPoint))!;
            SwaggerOptions.Description = configuration.GetSection(nameof(SwaggerOptions)).GetValue<string>(nameof(SwaggerOptions.Description))!;
        }
    }
}
