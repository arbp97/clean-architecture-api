using MediatR;
using Onboarding.Application.Results;

namespace Onboarding.Application.Requests.Orders
{
    public class GetOrderByIdRequest : IRequest<EntityResult<GetOrderByIdDto>>
    {
        public Guid Id { get; set; }
    }
}
