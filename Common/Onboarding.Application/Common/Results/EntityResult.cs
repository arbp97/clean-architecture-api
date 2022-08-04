namespace Onboarding.Application.Results
{
    public class EntityResult<T> where T : class
    {
        public T? Entity { get; set; }
        public StatusCode StatusCode { get; set; }
    }
}
