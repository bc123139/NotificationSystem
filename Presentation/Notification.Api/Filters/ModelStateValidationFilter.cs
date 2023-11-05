using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Notification.Common.Responses;

namespace Notification.Api.Filters
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        private readonly ILogger<ModelStateValidationFilter> _logger;

        public ModelStateValidationFilter(ILogger<ModelStateValidationFilter> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage)
                .ToList();
            _logger.LogError(message: string.Join(",", errors), $"Exception occured in {nameof(ModelStateValidationFilter)}");
            context.Result = new JsonResult(new Response
            {
                Errors = errors
            })
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}
