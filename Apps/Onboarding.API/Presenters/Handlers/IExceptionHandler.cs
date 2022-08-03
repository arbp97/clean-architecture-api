using Microsoft.AspNetCore.Mvc.Filters;

namespace Onboarding.API.Presenters.Handlers
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
