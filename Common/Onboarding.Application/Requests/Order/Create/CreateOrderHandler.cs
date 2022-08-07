using MediatR;
using Onboarding.Infrastructure.Repository;
using Onboarding.Domain.Enums;
using Onboarding.Domain.Entities;
using Onboarding.Application.Results;
using Microsoft.Extensions.Logging;

namespace Onboarding.Application.Requests.Orders
{
    public class CreateOrderHandler
        : IRequestHandler<CreateOrderRequest, EntityResult<CreateOrderDto>>
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<CreateOrderHandler> _logger;

        public CreateOrderHandler(IOrderRepository repository, ILogger<CreateOrderHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<EntityResult<CreateOrderDto>> Handle(
            CreateOrderRequest request,
            CancellationToken cancellationToken
        )
        {
            // Null fields are populated on DB insert (see OnboardingDbContext)
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Account = request.Account,
                InternalContractCode = request.InternalContractCode,
                Status = OrderStatus.CREATED
            };

            order.Cicle = order.Id.ToString();

            var result = await _repository.CreateOrder(order);

            _logger.LogInformation($"Order created: {result.Id}");

            return new EntityResult<CreateOrderDto>(
                new CreateOrderDto { Id = order.Id },
                StatusCode.Created
            );
        }
    }
}
