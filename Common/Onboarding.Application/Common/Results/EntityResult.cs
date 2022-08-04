using Onboarding.Domain.Enums;

namespace Onboarding.Application.Results
{
    public class EntityResult<T> where T : class
    {
        private T? Entity;
        private string? Message;
        private StatusCode StatusCode;

        public EntityResult(T entity, StatusCode statusCode)
        {
            Entity = entity;
            StatusCode = statusCode;
        }

        public EntityResult(string message, StatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public T? GetEntity()
        {
            return Entity;
        }

        public string? GetMessage()
        {
            return Message;
        }

        public StatusCode GetStatusCode()
        {
            return StatusCode;
        }
    }
}
