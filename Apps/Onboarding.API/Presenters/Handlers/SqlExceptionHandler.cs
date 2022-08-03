using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace Onboarding.API.Presenters.Handlers
{
    public class SqlExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as SqlException;

            return SetResult(
                context,
                StatusCodes.Status503ServiceUnavailable,
                "Database connection failed.",
                exception!.Message
            );
        }
    }
}
