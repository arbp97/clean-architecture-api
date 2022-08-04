using Onboarding.Application.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Onboarding.API.Presenters
{
    public class Presenter : IPresenter
    {
        public IActionResult GetResult<T>(EntityResult<T> result) where T : class
        {
            // if there is no entity, there is a message to return
            var entity = result.GetEntity();
            var message = result.GetMessage();

            return new JsonResult(entity is not null ? entity : new { Message = message })
            {
                StatusCode = (int)result.GetStatusCode()
            };
        }
    }
}
