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
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            },
            {
                StatusCodes.Status400BadRequest,
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"
            },
            {
                StatusCodes.Status404NotFound,
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"
            },
            {
                StatusCodes.Status503ServiceUnavailable,
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.4"
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
