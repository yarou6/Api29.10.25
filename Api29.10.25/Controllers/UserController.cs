using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api29._10._25.CQRS.Command;
using MyMediator.Interfaces;
using MyMediator.Types;
using Api29._10._25.CQRS.DTO;
namespace Api29._10._25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDTO user)
        {
            await mediator.SendAsync(new RegistreUserCommand() { User = user });
            return Ok();
        }


    }
}
