using MediatR;
using Onboarding.Application.Results;

namespace Onboarding.Application.Requests.Order
{
    public class CreateOrderRequest : IRequest<EntityResult<CreateOrderDto>>
    {
        public string Account { get; set; }
        public int InternalContractCode { get; set; }
    }
}
