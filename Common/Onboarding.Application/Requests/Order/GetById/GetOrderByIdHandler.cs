using MediatR;
using Onboarding.Infrastructure.Repository;
using Onboarding.Domain.Enums;
using Onboarding.Application.Results;
using Microsoft.Extensions.Logging;
using Onboarding.Domain.Exceptions;

namespace Onboarding.Application.Requests.Orders
{
    public class GetOrderByIdHandler
        : IRequestHandler<GetOrderByIdRequest, EntityResult<GetOrderByIdDto>>
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<GetOrderByIdHandler> _logger;

        public GetOrderByIdHandler(IOrderRepository repository, ILogger<GetOrderByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<EntityResult<GetOrderByIdDto>> Handle(
            GetOrderByIdRequest request,
            CancellationToken cancellationToken
        )
        {
            var order = await _repository.GetOrderById(request.Id);

            if (order is null)
            {
                _logger.LogInformation($"Order not found: {request.Id}");

                throw new NotFoundException("Order not found with requested id:", $"{request.Id}");
            }

            _logger.LogInformation($"Order fetched: {order!.Id}");

            return new EntityResult<GetOrderByIdDto>(
                new GetOrderByIdDto
                {
                    Id = order.Id,
                    Number = order.Number.HasValue ? order.Number.Value : null,
                    Cicle = order.Cicle,
                    InternalContractCode = order.InternalContractCode,
                    Status = Enum.GetName(typeof(OrderStatus), order.Status) ?? string.Empty,
                    Account = order.Account,
                    CreatedAt = order.CreatedAt
                },
                StatusCode.Ok
            );
        }
    }
}
