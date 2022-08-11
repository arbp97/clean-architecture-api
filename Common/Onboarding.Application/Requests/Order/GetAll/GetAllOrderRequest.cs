using MediatR;
using Onboarding.Application.Results;

namespace Onboarding.Application.Requests.Orders
{
    public class GetAllOrderRequest : IRequest<EntityResult<IEnumerable<GetAllOrderDto>>> { }
}
