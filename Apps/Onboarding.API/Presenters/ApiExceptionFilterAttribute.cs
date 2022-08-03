using Microsoft.AspNetCore.Mvc.Filters;
using Onboarding.API.Presenters.Base;

namespace Onboarding.API.Presenters
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
                new ExceptionHandlerBase().SetResult(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Unidentified server error occurred.",
                    ""
                );
            }

            base.OnException(context);
        }
    }
}
