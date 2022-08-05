using Microsoft.AspNetCore.Mvc.Filters;
using Onboarding.Domain.Exceptions;

namespace Onboarding.API.Presenters.Handlers
{
    public class NotFoundExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            return SetResult(
                context,
                StatusCodes.Status404NotFound,
                "Resource not found.",
                $"{exception!.Message} {exception!.Detail}"
            );
        }
    }
}
