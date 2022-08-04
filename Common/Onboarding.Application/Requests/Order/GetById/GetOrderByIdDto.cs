namespace Onboarding.Application.Requests.Order
{
    public class GetOrderByIdDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Cicle { get; set; }
        public int InternalContractCode { get; set; }
        public string Status { get; set; }
        public string Account { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
