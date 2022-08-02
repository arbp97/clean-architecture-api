namespace Onboarding.Application.Request.Order
{
    public class CreateOrderRequest
    {
        public string Account { get; set; }
        public int InternalContractCode { get; set; }
    }
}
