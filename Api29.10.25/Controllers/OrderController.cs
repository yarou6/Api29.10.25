using Api29._10._25.CQRS.Command;
using Api29._10._25.CQRS.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;

namespace Api29._10._25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMediator mediator;
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("new")]
        public async Task<ActionResult> NewOrder(OrderDTO order)
        {
            await mediator.SendAsync(new NewOrderCommand() { Order = order });
            return Ok();
        }
    }
}
