using Onboarding.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace Onboarding.API.Presenters
{
    public interface IPresenter
    {
        IActionResult GetResult<T>(EntityResult<T> result) where T : class;
    }
}
