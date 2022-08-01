namespace Onboarding.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Cicle { get; set; }
        public int InternalContractCode { get; set; }
        public int Status { get; set; }
        public string Account { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
