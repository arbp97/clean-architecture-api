using Onboarding.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace Onboarding.API.Presenters
{
    public class Presenter : IPresenter
    {
        public IActionResult GetResultEntity<T>(EntityResult<T> result) where T : class
        {
            return new JsonResult(result.Entity) { StatusCode = (int)result.StatusCode };
        }
    }
}
