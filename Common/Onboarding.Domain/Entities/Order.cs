using Onboarding.Domain.Enums;

namespace Onboarding.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public int? Number { get; set; } = null;
        public string Cicle { get; set; }
        public int InternalContractCode { get; set; }
        public OrderStatus Status { get; set; }
        public string Account { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
