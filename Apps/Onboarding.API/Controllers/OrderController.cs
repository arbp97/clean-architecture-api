using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.Request.Order;
using Onboarding.Application.Results;
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
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var result = await _mediator.Send(request);
            return new JsonResult(result.Entity) { StatusCode = (int)result.StatusCode };
        }
    }
}
