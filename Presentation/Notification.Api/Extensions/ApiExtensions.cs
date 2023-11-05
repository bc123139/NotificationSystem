using Notification.Api.Middlewares;
using Notification.Common.Options;

namespace Notification.Api.Extensions
{
    public static class ApiExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger(option =>
            {
                option.RouteTemplate = SwaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(SwaggerOptions.UiEndPoint, SwaggerOptions.Description);
            });
        }
        public static void UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
