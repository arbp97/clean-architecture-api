using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Onboarding.API.Presenters
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
                @"Request denied, client error detected (malformed request syntax, 
                invalid request message framing, deceptive request routing)."
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
                Type = _types.ContainsKey(status) ? _types[status] : "",
                Detail = detail
            };

            context.Result = new ObjectResult(details) { StatusCode = status };

            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}
