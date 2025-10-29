using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;
using MyMediator.Types;

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



    }
}
