using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.Requests.Order;
using Onboarding.API.Presenters;
using MediatR;

namespace Onboarding.API.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;
        private readonly IPresenter _presenter;

        public OrderController(
            ILogger<OrderController> logger,
            IMediator mediator,
            IPresenter presenter
        )
        {
            _logger = logger;
            _mediator = mediator;
            _presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateOrderDto))]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            return _presenter.GetResult(await _mediator.Send(request));
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderByIdDto))]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            return _presenter.GetResult(await _mediator.Send(new GetOrderByIdRequest { Id = id }));
        }
    }
}
