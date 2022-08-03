using MediatR;
using Onboarding.Infrastructure.Repository;
using Onboarding.Domain.Enums;
using Onboarding.Application.Results;
using Microsoft.Extensions.Logging;

namespace Onboarding.Application.Request.Order
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
            Domain.Entities.Order order = new Domain.Entities.Order
            {
                Id = Guid.NewGuid(),
                Account = request.Account,
                InternalContractCode = request.InternalContractCode,
                Status = OrderStatus.CREATED
            };

            order.Cicle = order.Id.ToString();
            StatusCode statusCode = new StatusCode();

            try
            {
                var result = await _repository.CreateOrder(order);
                _logger.LogInformation($"Order created: {result.ToString()}");
                statusCode = StatusCode.Created;
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                statusCode = StatusCode.ServiceUnavailable;
            }

            return new EntityResult<CreateOrderDto>
            {
                Entity = new CreateOrderDto { Id = order.Id },
                StatusCode = statusCode
            };
        }
    }
}
