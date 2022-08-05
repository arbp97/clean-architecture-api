namespace Onboarding.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Detail { get; set; }

        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        public NotFoundException(string title, string detail) : base(title)
        {
            Detail = detail;
        }
    }
}
