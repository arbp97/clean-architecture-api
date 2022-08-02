using MediatR;
using Onboarding.Infrastructure.Repository;
using Onboarding.Domain.Enums;

namespace Onboarding.Application.Request.Order
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderDto>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderDto> Handle(
            CreateOrderRequest request,
            CancellationToken cancellationToken
        )
        {
            // Null fields are populated on DB insert (see OnboardingDbContext)
            Domain.Entities.Order order = new Domain.Entities.Order
            {
                Id = Guid.NewGuid(),
                Account = request.Account,
                InternalContractCode = request.InternalContractCode,
                Status = OrderStatus.CREATED
            };

            order.Cicle = order.Id.ToString();

            try
            {
                var result = await _repository.CreateOrder(order);

                return new CreateOrderDto { Id = result.Id };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
