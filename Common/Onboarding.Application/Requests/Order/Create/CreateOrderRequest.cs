using MediatR;
using Onboarding.Application.Results;

namespace Onboarding.Application.Requests.Orders
{
    public class CreateOrderRequest : IRequest<EntityResult<CreateOrderDto>>
    {
        public string? Account { get; set; }
        public int InternalContractCode { get; set; }
    }
}
