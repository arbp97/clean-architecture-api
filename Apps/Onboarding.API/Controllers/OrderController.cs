using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.Requests.Orders;
using Onboarding.API.Presenters;
using System.Net.Mime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MediatR;

namespace Onboarding.API.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPresenter _presenter;

        public OrderController(IMediator mediator, IPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Create a new order.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateOrderDto))]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var result = _presenter.GetResult(await _mediator.Send(request));
            JObject responseObject = JsonConvert.DeserializeObject<JObject>(
                JsonConvert.SerializeObject(result)
            );

            var id = responseObject["Value"]["Id"];

            Response.Headers.Add("location", $"{Request.Path}/{id}");
            return result;
        }

        /// <summary>
        /// Fetch an existing order.
        /// </summary>
        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderByIdDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            return _presenter.GetResult(await _mediator.Send(new GetOrderByIdRequest { Id = id }));
        }

        /// <summary>
        /// Fetch all existing orders.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllOrderDto>))]
        public async Task<IActionResult> GetAllOrder()
        {
            return _presenter.GetResult(await _mediator.Send(new GetAllOrderRequest { }));
        }
    }
}
