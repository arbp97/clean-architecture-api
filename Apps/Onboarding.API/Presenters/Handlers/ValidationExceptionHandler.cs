using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;
using System.Text;

namespace Onboarding.API.Presenters.Handlers
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            StringBuilder detail = new StringBuilder();

            foreach (var failure in exception!.Errors)
            {
                detail.AppendLine(
                    string.Format(
                        "Property: {0}, Error: {1}",
                        failure.PropertyName,
                        failure.ErrorMessage
                    )
                );
            }

            return SetResult(
                context,
                StatusCodes.Status400BadRequest,
                "Parameter validation error.",
                detail.ToString()
            );
        }
    }
}
