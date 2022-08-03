using Microsoft.AspNetCore.Mvc.Filters;

namespace Onboarding.API.Presenters
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
