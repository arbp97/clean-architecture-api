using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Onboarding.API.Presenters.Handlers
{
    public class ExceptionHandlerBase
    {
        private readonly Dictionary<int, string> _types = new Dictionary<int, string>
        {
            {
                StatusCodes.Status500InternalServerError,
                "Internal server error occurred, please contact the developer."
            },
            {
                StatusCodes.Status400BadRequest,
                "Request denied, client error detected (invalid request format)."
            },
            {
                StatusCodes.Status503ServiceUnavailable,
                "Server is currently unavailable, please try again later."
            }
        };

        public Task SetResult(ExceptionContext context, int status, string title, string detail)
        {
            ProblemDetails details = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = _types.ContainsKey(status) ? _types[status] : string.Empty,
                Detail = detail
            };

            context.Result = new ObjectResult(details) { StatusCode = status };

            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}
