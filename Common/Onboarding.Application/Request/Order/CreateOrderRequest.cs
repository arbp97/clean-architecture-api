using MediatR;

namespace Onboarding.Application.Request.Order
{
    public class CreateOrderRequest : IRequest<CreateOrderDto>
    {
        public string Account { get; set; }
        public int InternalContractCode { get; set; }
    }
}
