using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.Requests.Orders;
using Onboarding.API.Presenters;
using System.Net.Mime;
using MediatR;

namespace Onboarding.API.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPresenter _presenter;

        public OrderController(IMediator mediator, IPresenter presenter)
        {
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
