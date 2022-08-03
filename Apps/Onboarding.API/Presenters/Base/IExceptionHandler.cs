using Microsoft.AspNetCore.Mvc.Filters;

namespace Onboarding.API.Presenters.Base
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
