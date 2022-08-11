using MediatR;
using Onboarding.Domain.Enums;
using Microsoft.Extensions.Logging;
using Onboarding.Application.Results;
using Onboarding.Infrastructure.Repository;

namespace Onboarding.Application.Requests.Orders
{
    public class GetAllOrderHandler
        : IRequestHandler<GetAllOrderRequest, EntityResult<IEnumerable<GetAllOrderDto>>>
    {
        public IOrderRepository _repository;
        public ILogger<GetAllOrderHandler> _logger;

        public GetAllOrderHandler(IOrderRepository repository, ILogger<GetAllOrderHandler> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<EntityResult<IEnumerable<GetAllOrderDto>>> Handle(
            GetAllOrderRequest request,
            CancellationToken cancellationToken
        )
        {
            var orderList = await _repository.GetAllOrders();
            var orderListDto = new List<GetAllOrderDto>();

            foreach (var order in orderList)
            {
                orderListDto.Add(
                    new GetAllOrderDto
                    {
                        Id = order.Id,
                        Number = order.Number.HasValue ? order.Number.Value : null,
                        Cicle = order.Cicle,
                        InternalContractCode = order.InternalContractCode,
                        Status = Enum.GetName(typeof(OrderStatus), order.Status) ?? string.Empty,
                        Account = order.Account,
                        CreatedAt = order.CreatedAt
                    }
                );
            }

            _logger.LogInformation("Fetched all orders.");

            return new EntityResult<IEnumerable<GetAllOrderDto>>(orderListDto, StatusCode.Ok);
        }
    }
}
