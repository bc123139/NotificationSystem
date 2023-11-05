using Microsoft.OpenApi.Models;
using Notification.Common.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Notification.Api.Filters
{
    public class HeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = ApplicationConstants.ApiKey,
                In = ParameterLocation.Header,
                Required = false

            });
        }
    }
}
