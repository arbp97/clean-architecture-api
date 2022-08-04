using MediatR;
using Onboarding.Application.Results;

namespace Onboarding.Application.Requests.Order
{
    public class GetOrderByIdRequest : IRequest<EntityResult<GetOrderByIdDto>>
    {
        public Guid Id { get; set; }
    }
}
