using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.Request.Order;
using MediatR;

namespace Onboarding.API.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateOrderDto))]
        public async Task<ActionResult<CreateOrderDto>> CreateOrder(
            [FromBody] CreateOrderRequest request
        )
        {
            return await _mediator.Send(request);
        }
    }
}
