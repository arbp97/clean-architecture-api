using MediatR;
using Onboarding.Infrastructure.Repository;
using Onboarding.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace Onboarding.Application.Request.Order
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderDto>
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<CreateOrderHandler> _logger;

        public CreateOrderHandler(IOrderRepository repository, ILogger<CreateOrderHandler> logger)
        {
            _repository = repository;
            _logger = logger;
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
                _logger.LogInformation($"Order created: {result.ToString()}");
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
            }

            return new CreateOrderDto { Id = order.Id };
        }
    }
}
