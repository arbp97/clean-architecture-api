using Microsoft.AspNetCore.Mvc.Filters;
using Onboarding.API.Presenters.Handlers;

namespace Onboarding.API.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, IExceptionHandler> _handlers;

        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> handlers)
        {
            _handlers = handlers;
        }

        public override void OnException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();

            if (_handlers.ContainsKey(exceptionType))
            {
                _handlers[exceptionType].Handle(context);
            }
            else
            {
                Console.WriteLine(context.Exception.StackTrace);

                new ExceptionHandlerBase().SetResult(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Unidentified server error occurred.",
                    $"{context.Exception.Message}"
                );
            }

            base.OnException(context);
        }
    }
}
